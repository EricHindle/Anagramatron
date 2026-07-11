' Hindleware
' Copyright (c) 2026 eric hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Environment
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports HindlewareLib.Logging
Imports HindlewareLib.Wiktionary
Public Class FrmAnagrams
#Region "variables"
    Public isStopped As Boolean
    Private isFindLargest As Boolean
    Private keyArray As Byte()
    Private iWordsFound As Integer
    Private toEncryptArray As Byte()
    Private resultArray As Byte()
    Private oDictWord As String
    Private oTestWord As String
    Private oTestChars As String
    Private oTestChar As String
    Private iCharPos As Integer
    Private iWordLen As Integer
    Private iCurrLen As Integer
    Private oLanguages As String() = {"en", "sco"}
    Private oAllLanguages As String() = {"en", "sco", "fr", "de", "es", "pt", "da", "nl", "ro", "la", "af", "nrm", "ca", "oc", "other"}
    Private isReferral As Boolean
    Private oAppDataPath As String
    Private oReferralText As New List(Of String)
    Private isLoading As Boolean
#End Region
#Region "properties"
    Dim tdes As TripleDESCryptoServiceProvider
    Dim cTransform As ICryptoTransform
    Public Property CTransform1 As ICryptoTransform
        Get
            Return CTransform2
        End Get
        Set(value As ICryptoTransform)
            CTransform2 = value
        End Set
    End Property
    Public Property CTransform2 As ICryptoTransform
        Get
            Return cTransform
        End Get
        Set(value As ICryptoTransform)
            cTransform = value
        End Set
    End Property
    Public Property Tdes1 As TripleDESCryptoServiceProvider
        Get
            Return tdes
        End Get
        Set(value As TripleDESCryptoServiceProvider)
            tdes = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub FrmAnagrams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Initialise()

        lblVersion.Text = System.String.Format(lblVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
        lblCopyright.Text = My.Application.Info.Copyright
        lblVersion.Text = "Version: " & My.Application.Info.Version.Major &
        "." & My.Application.Info.Version.Minor &
        "." & My.Application.Info.Version.Build &
        "." & My.Application.Info.Version.Revision
        LblCompany.Text = String.Format(LblCompany.Text, My.Application.Info.CompanyName)
        InitialiseDecryptor()
    End Sub
    Private Sub CmdAnagClose_Click(sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnagClose.Click
        Me.Close()
    End Sub
    Private Sub FrmAnagrams_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.MainFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub CmdGetAnagrams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetAnagrams.Click
        Try
            Dim iMin As Integer = Val(TxtMinLen.Text) + 0
            Dim iMax As Integer = Math.Min(Val(TxtMaxLen.Text) + 0, TxtLetters.Text.Length)
            TxtMaxLen.Text = CStr(iMax)
            If IsValidText(iMin, iMax) Then
                InitialiseAnagramSearch()
                Dim isComplete As Boolean = False
                Do Until isComplete
                    For iCurrLen = iMax To iMin Step -1
                        CheckWordsOfAParticularLength()
                        Application.DoEvents()
                        If isStopped Then Exit For
                    Next iCurrLen
                    If isStopped Then Exit Do
                    If Not isFindLargest OrElse iWordsFound > 0 Then
                        isComplete = True
                    Else
                        If iMax = 1 Then
                            isComplete = True
                        Else
                            iMax -= 1
                            iMin -= 1
                        End If
                    End If
                Loop
                EndOfAnagrams()
            End If
        Catch ex As Exception
            MsgBox("A program error has occurred: " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub SolveCrossword(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXword.Click
        If TxtPattern.TextLength = 0 Then
            MsgBox("You must provide a pattern with ? for missing letters", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
        Else
            If String.IsNullOrWhiteSpace(TxtCrosswordLength.Text) OrElse Not IsNumeric(TxtCrosswordLength.Text) Then
                MsgBox("You must provide a length for the required word", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
            Else
                TxtPattern.Text = Replace(TxtPattern.Text, " ", "").ToLower
                Dim regex As New RegularExpressions.Regex("[^a-zA-Z?/*]")
                If regex.IsMatch(TxtPattern.Text) = True Then
                    MsgBox("The pattern can only be letters, / * or ?", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
                Else
                    InitialiseCrosswordCheck()
                    Using oListOfWords As New StreamReader(Path.Combine(oAppDataPath, My.Settings.CodedWordList))
                        Do Until oListOfWords.EndOfStream
                            Dim oDictionaryWord As String = oListOfWords.ReadLine
                            AddMatchingWordToList(oDictionaryWord)
                            Application.DoEvents()
                            If isStopped Then
                                lblProgress.Text = "---Stopped---"
                                Exit Do
                            End If
                        Loop
                        oListOfWords.Close()
                        lblProgress.Text = "---Done---"
                    End Using
                End If
            End If
        End If
        SetButtons(True, True, False)
    End Sub
    Private Sub CmdInterrupt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInterrupt.Click
        isStopped = True
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        LstWords.Items.Clear()
        ClearBrowser()
        TxtLetters.Text = String.Empty
        TxtMaxLen.Text = String.Empty
        TxtMinLen.Text = String.Empty
        TxtPattern.Text = String.Empty
        lblProgress.Text = String.Empty
        lblWordCount.Text = String.Empty
        TxtCrosswordLength.Text = String.Empty
        TxtDefineWord.Text = String.Empty
    End Sub
    Private Sub BtnShowLog_Click(sender As Object, e As EventArgs) Handles BtnShowLog.Click
        Using _logView As New FrmLogViewer
            _logView.FormPosition = My.Settings.LogViewPos
            _logView.ZoomValue = My.Settings.logZoomValue
            _logView.IsZoomOn = My.Settings.LogZoomOn
            _logView.ShowDialog()
            My.Settings.LogViewPos = _logView.FormPosition
            My.Settings.logZoomValue = _logView.ZoomValue
            My.Settings.LogZoomOn = _logView.IsZoomOn
            My.Settings.Save()
        End Using
    End Sub
    Private Sub BtnDefine_Click(sender As Object, e As EventArgs) Handles BtnDefine.Click
        If TxtDefineWord.TextLength > 0 Then
            Dim sWord As String = TxtDefineWord.Text
            Dim _languages As String() = If(ChkLanguages.Checked, oAllLanguages, oLanguages)
            Dim oDefinitions As String = WiktionaryUtil.WordDefinitionHtml(sWord, _languages)
            DisplayPage(oDefinitions)
        End If
    End Sub
    Private Sub LstWords_DoubleClick(sender As Object, e As EventArgs) Handles LstWords.DoubleClick
        If LstWords.SelectedIndex > -1 Then
            Dim sWord As String = LstWords.SelectedItem
            Dim _languages As String() = If(ChkLanguages.Checked, oAllLanguages, oLanguages)
            Dim oDefinitions As String = WiktionaryUtil.WordDefinitionHtml(sWord, _languages)
            DisplayPage(oDefinitions)
        End If
    End Sub
    Private Sub TxtPattern_TextChanged(sender As Object, e As EventArgs) Handles TxtPattern.TextChanged
        If TxtPattern.TextLength > 0 And TxtLetters.TextLength = 0 Then
            TxtMinLen.Text = ""
            TxtMaxLen.Text = ""
            TxtCrosswordLength.Text = CStr(TxtPattern.TextLength)
        End If
    End Sub
    Private Sub TxtLetters_TextChanged(sender As Object, e As EventArgs) Handles TxtLetters.TextChanged
        TxtMinLen.Text = TxtLetters.TextLength
        TxtMaxLen.Text = TxtLetters.TextLength
        ChkFindLargest.Checked = True
    End Sub
    Private Sub TxtMinMax_TextChanged(sender As Object, e As EventArgs) Handles TxtMinLen.TextChanged, TxtMaxLen.TextChanged
        ChkFindLargest.Checked = False
    End Sub
    Private Sub ChkFindLargest_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFindLargest.CheckedChanged
        isFindLargest = ChkFindLargest.Checked
    End Sub
#End Region
#Region "subroutines"
    Private Sub Initialise()
        If My.Settings.CallUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.CallUpgrade = 1
            My.Settings.Save()
        End If
        isLoading = True
        oAppDataPath = Path.Combine(GetFolderPath(SpecialFolder.CommonApplicationData), Path.Combine(My.Application.Info.CompanyName, My.Application.Info.AssemblyName))
        LogUtil.LogFolder = Path.Combine(oAppDataPath, My.Settings.LogFolder)
        LogUtil.StartLogging()
        ChkLanguages.Checked = My.Settings.AllLanguages
        GetFormPos(Me, My.Settings.MainFormPos)
        isLoading = False
    End Sub
    Private Sub InitialiseDecryptor()
        Tdes1 = New TripleDESCryptoServiceProvider()
        keyArray = UTF8Encoding.UTF8.GetBytes("QzoSB6UxAQ2x95am")
        'set the secret key for the tripleDES algorithm
        Tdes1.Key = keyArray
        'Mode of operation. 
        'We choose ECB(Electronic code Book)
        Tdes1.Mode = CipherMode.ECB
        'Padding mode(if any extra byte added)
        Tdes1.Padding = PaddingMode.ISO10126
        CTransform1 = Tdes1.CreateDecryptor()
    End Sub
    Private Sub InitialiseAnagramSearch()
        isStopped = False
        SetButtons(False, False, True)
        lblProgress.Text = "---Start---"
        LstWords.Items.Clear()
        ClearBrowser()
        iWordsFound = 0
    End Sub
    Private Sub InitialiseCrosswordCheck()
        isStopped = False
        TxtPattern.Text = TxtPattern.Text.Replace("/", "?")
        lblProgress.Text = "---Start---"
        lblProgress.Refresh()
        iWordsFound = 0
        lblWordCount.Text = iWordsFound
        lblWordCount.Refresh()
        LstWords.Items.Clear()
        ClearBrowser()
        SetButtons(False, False, True)
        iCurrLen = CInt(TxtCrosswordLength.Text)
    End Sub
    Private Sub CheckWordsOfAParticularLength()
        lblWordCount.Text = iWordsFound
        LstWords.Items.Add("---" & iCurrLen & "---")
        lblProgress.Text = iCurrLen & " letters"
        Me.Refresh()
        Using oListOfWords As New StreamReader(Path.Combine(oAppDataPath, My.Settings.CodedWordList))
            Do Until oListOfWords.EndOfStream
                CheckWordForIsValidAnagram(oListOfWords)
            Loop
            oListOfWords.Close()
        End Using
    End Sub
    Private Function DecryptDictionaryWord(pDictionaryWord As String) As String
        Dim _word As String = String.Empty
        If Not String.IsNullOrEmpty(pDictionaryWord) Then
            toEncryptArray = Convert.FromBase64String(pDictionaryWord)
            resultArray = CTransform1.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
            _word = UTF8Encoding.UTF8.GetString(resultArray)
            _word = _word.Replace(" ", "").Replace("'", "").Replace("-", "").ToLower()
        End If
        Return _word
    End Function
    Private Sub CheckWordForIsValidAnagram(pListOfWords As StreamReader)
        Dim oDictionaryWord As String = pListOfWords.ReadLine
        oDictWord = DecryptDictionaryWord(oDictionaryWord)
        iWordLen = oDictWord.Length
        If iWordLen = iCurrLen Then
            oTestWord = oDictWord
            oTestChars = TxtLetters.Text.ToLower
            For Ct As Integer = 1 To iWordLen
                oTestChar = Mid(oDictWord, Ct, 1)
                iCharPos = InStr(oTestChars, oTestChar)
                If iCharPos > 0 Then
                    oTestChars = Replace(oTestChars, oTestChar, "", 1, 1)
                    oTestWord = Replace(oTestWord, oTestChar, "", 1, 1)
                End If
            Next Ct
            If oTestWord = "" Then
                If TxtPattern.Text = "" Or oDictWord Like TxtPattern.Text Then
                    LstWords.Items.Add(oDictWord)
                    LstWords.Refresh()
                    iWordsFound += 1
                    lblWordCount.Text = iWordsFound
                End If
            End If
        End If
    End Sub
    Private Sub AddMatchingWordToList(pDictionaryWord As String)
        oDictWord = DecryptDictionaryWord(pDictionaryWord)
        iWordLen = oDictWord.Length
        If iWordLen = iCurrLen Then
            If oDictWord Like TxtPattern.Text Then
                LstWords.Items.Add(oDictWord)
                LstWords.Refresh()
                iWordsFound += 1
                lblWordCount.Text = iWordsFound
            End If
        End If
    End Sub
    Private Sub EndOfAnagrams()
        lblProgress.Text = "---Done---"
        If isStopped Then
            lblProgress.Text = "--Stopped--"
        End If
        SetButtons(True, True, False)
        DisplayText("Double-click a word to see definitions")
    End Sub
    Private Function IsValidText(iMin As Integer, iMax As Integer) As Boolean
        Dim isValid As Boolean = True
        If iMax = 0 Or iMin = 0 Or iMin > iMax Then
            MsgBox("Invalid length value(s)", vbExclamation, "Error")
            isValid = False
        Else
            TxtLetters.Text = Replace(TxtLetters.Text, " ", "")
            If Len(TxtLetters.Text) < iMin Then
                MsgBox("Not enough letters for minimum length", vbExclamation, "Error")
                isValid = False
            End If
        End If
        Return isValid
    End Function
    Private Sub SetButtons(isAnagramButtonEnabled As Boolean, isCrosswordButtonEnabled As Boolean, isInterruptButtonEnabled As Boolean)
        BtnInterrupt.Enabled = isInterruptButtonEnabled
        BtnGetAnagrams.Enabled = isAnagramButtonEnabled
        BtnXword.Enabled = isCrosswordButtonEnabled
    End Sub
    Private Sub ClearBrowser()
        DisplayText("")
    End Sub
    Private Sub DisplayText(pText As String)
        DisplayPage("<HTML><body><div style='font-family:verdana'>" & pText & "</div></body></HTML>")
    End Sub
    Private Sub DisplayPage(pHtml)
        OpenBlankWebPage()
        WebBrowser1.Document.Write(pHtml)
        WebBrowser1.Refresh()
    End Sub
    Private Sub OpenBlankWebPage()
        WebBrowser1.Navigate("about:blank")
        WebBrowser1.Document.OpenNew(False)
    End Sub

    Private Sub BtnDonate_Click(sender As Object, e As EventArgs) Handles BtnDonate.Click
        Process.Start(My.Settings.DonationPage)
    End Sub
    Private Sub ChkLanguages_CheckedChanged(sender As Object, e As EventArgs) Handles ChkLanguages.CheckedChanged
        If Not isLoading Then
            My.Settings.AllLanguages = ChkLanguages.Checked
            My.Settings.Save()
        End If
    End Sub
#End Region
End Class
