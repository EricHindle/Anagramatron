' Hindleware
' Copyright (c) 2025 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Environment
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.Script.Serialization
Imports HindlewareLib.Logging
Public Class FrmAnagrams
#Region "constants"
    Private Const PLURAL_OF As String = "plural of "
    Private Const PAST_OF As String = "simple past and past participle of "
    Private Const OBSOLETE_OF As String = "Obsolete form of "
    Private Const ALT_OF As String = "Alternative form of "
    Private Const GERUND_OF As String = "present participle and gerund of "
#End Region
#Region "variables"
    Public isStopped As Boolean
    Private bFindLargest As Boolean
    Private keyArray As Byte()
    Private WordsFound As Integer
    Private toEncryptArray As Byte()
    Private resultArray As Byte()
    Private DictWord As String
    Private TestWord As String
    Private TestChars As String
    Private TestChar As String
    Private CharPos As Integer
    Private WordLen As Integer
    Private CurrLen As Integer
    Private _language As String
    Private _languages As String() = {"en", "sco", "fr", "de", "es", "pt", "da", "nl", "ro", "la", "af", "nrm", "ca", "oc", "other"}
    Private isReferral As Boolean
    Private oAppDataPath As String
    Private oReferralText As New List(Of String)
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
        lblCopyright.Text = My.Application.Info.Copyright
        lblVersion.Text = "Version: " & My.Application.Info.Version.Major &
        "." & My.Application.Info.Version.Minor &
        "." & My.Application.Info.Version.Build &
        "." & My.Application.Info.Version.Revision
        InitialiseDecryptor()
    End Sub
    Private Sub LstWords_DoubleClick(sender As Object, e As EventArgs) Handles LstWords.DoubleClick
        If LstWords.SelectedIndex > -1 Then
            Dim sWord As String = LstWords.SelectedItem
            DisplayDefinitions(sWord, SearchWebForWord(sWord))
        End If
    End Sub
    Private Sub CmdInterrupt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInterrupt.Click
        isStopped = True
    End Sub
    Private Sub SolveCrossword(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXword.Click
        isStopped = False
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
                    TxtPattern.Text = TxtPattern.Text.Replace("/", "?")
                    lblProgress.Text = "---Start---"
                    lblProgress.Refresh()
                    WordsFound = 0
                    lblWordCount.Text = WordsFound
                    lblWordCount.Refresh()
                    LstWords.Items.Clear()
                    ClearBrowser()
                    SetButtons(False, False, True)
                    CurrLen = CInt(TxtCrosswordLength.Text)
                    Using Dictionary As New StreamReader(Path.Combine(oAppDataPath, My.Settings.CodedWordList))
                        Do Until Dictionary.EndOfStream
                            If isStopped Then
                                lblProgress.Text = "--Stopped--"
                                SetButtons(True, True, False)
                                Exit Sub
                            End If
                            toEncryptArray = Convert.FromBase64String(Dictionary.ReadLine)
                            resultArray = CTransform1.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
                            DictWord = UTF8Encoding.UTF8.GetString(resultArray)
                            DictWord = DictWord.Replace(" ", "").Replace("'", "").Replace("-", "").ToLower()
                            WordLen = DictWord.Length
                            If WordLen = CurrLen Then
                                If DictWord Like TxtPattern.Text Then
                                    LstWords.Items.Add(DictWord)
                                    LstWords.Refresh()
                                    WordsFound += 1
                                    lblWordCount.Text = WordsFound
                                End If
                            End If
                        Loop
                        Dictionary.Close()
                    End Using
                    lblProgress.Text = "---Done---"
                End If
            End If
        End If
        SetButtons(True, True, False)
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
    Private Sub FrmAnagrams_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.LogInfo("Closing", MyBase.Name)
        My.Settings.MainFormPos = SetFormPos(Me)
        My.Settings.Save()
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
    Private Sub CmdAnagClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnagClose.Click
        Me.Close()
    End Sub
    Private Sub CmdGetAnagrams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetAnagrams.Click
        isStopped = False
        Try
            Dim iMin As Integer = Val(TxtMinLen.Text) + 0
            Dim iMax As Integer = Val(TxtMaxLen.Text) + 0
            If Not ValidateText(iMin, iMax) Then Exit Sub
            isStopped = False
            SetButtons(False, False, True)
            lblProgress.Text = "---Start---"
            LstWords.Items.Clear()
            ClearBrowser()
            If iMax > TxtLetters.Text.Length Then
                iMax = CStr(TxtLetters.TextLength)
                TxtMaxLen.Text = CStr(iMax)
            End If
            WordsFound = 0
            Dim isComplete As Boolean = False
            Do Until isComplete
                For CurrLen = iMax To iMin Step -1
                    lblWordCount.Text = WordsFound
                    LstWords.Items.Add("---" & CurrLen & "---")
                    lblProgress.Text = CurrLen & " letters"
                    Me.Refresh()
                    Using Dictionary As New StreamReader(Path.Combine(oAppDataPath, My.Settings.CodedWordList))
                        Do Until Dictionary.EndOfStream
                            If isStopped Then
                                lblProgress.Text = "--Stopped--"
                                SetButtons(True, True, False)
                                ClearBrowser("Double-click a word to see definitions")
                                Exit Sub
                            End If
                            toEncryptArray = Convert.FromBase64String(Dictionary.ReadLine)
                            resultArray = CTransform1.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
                            DictWord = UTF8Encoding.UTF8.GetString(resultArray)
                            DictWord = DictWord.Replace(" ", "").Replace("'", "").Replace("-", "").ToLower()
                            WordLen = DictWord.Length
                            If WordLen = CurrLen Then
                                TestWord = DictWord
                                TestChars = TxtLetters.Text.ToLower
                                For Ct As Integer = 1 To WordLen
                                    TestChar = Mid(DictWord, Ct, 1)
                                    CharPos = InStr(TestChars, TestChar)
                                    If CharPos > 0 Then
                                        TestChars = Replace(TestChars, TestChar, "", 1, 1)
                                        TestWord = Replace(TestWord, TestChar, "", 1, 1)
                                    End If
                                Next Ct
                                If TestWord = "" Then
                                    If TxtPattern.Text = "" Or DictWord Like TxtPattern.Text Then
                                        LstWords.Items.Add(DictWord)
                                        LstWords.Refresh()
                                        WordsFound += 1
                                        lblWordCount.Text = WordsFound
                                    End If
                                End If
                            End If
                        Loop
                        Dictionary.Close()
                    End Using
                Next CurrLen
                If Not bFindLargest OrElse WordsFound > 0 Then
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
        Catch ex As Exception
            MsgBox("A program error has occurred: " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        lblProgress.Text = "---Done---"
        ClearBrowser("Double-click a word to see definitions")
        SetButtons(True, True, False)
    End Sub
    Private Sub ChkFindLargest_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFindLargest.CheckedChanged
        bFindLargest = ChkFindLargest.Checked
    End Sub
    Private Sub BtnDefine_Click(sender As Object, e As EventArgs) Handles BtnDefine.Click
        If TxtDefineWord.TextLength > 0 Then
            Dim sWord As String = TxtDefineWord.Text
            DisplayDefinitions(sWord, SearchWebForWord(sWord))
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub Initialise()
        If My.Settings.CallUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.CallUpgrade = 1
            My.Settings.Save()
        End If
        oAppDataPath = Path.Combine(GetFolderPath(SpecialFolder.CommonApplicationData), Path.Combine(My.Application.Info.CompanyName, My.Application.Info.AssemblyName))
        LogUtil.LogFolder = Path.Combine(oAppDataPath, My.Settings.LogFolder)
        LogUtil.StartLogging()
        GetFormPos(Me, My.Settings.MainFormPos)
        oReferralText.Add(PLURAL_OF)
        oReferralText.Add(PAST_OF)
        oReferralText.Add(ALT_OF)
        oReferralText.Add(OBSOLETE_OF)
        oReferralText.Add(GERUND_OF)
    End Sub
    Private Function ValidateText(iMin As Integer, iMax As Integer) As Boolean
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
    Private Sub SetButtons(_anagram As Boolean, _crossword As Boolean, _interrupt As Boolean)
        BtnInterrupt.Enabled = _interrupt
        BtnGetAnagrams.Enabled = _anagram
        BtnXword.Enabled = _crossword
    End Sub
    Private Sub ClearBrowser(Optional stext As String = "")
        WebBrowser1.Navigate("about:blank")
        WebBrowser1.Document.OpenNew(False)
        WebBrowser1.Document.Write("<HTML><body><div style='font-family:verdana'>" & stext & "</div></body></HTML>")
        WebBrowser1.Refresh()
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
#End Region
#Region "wiktionary"
    Private Sub DisplayDefinitions(ByVal sWord As String, extractDictionary As Dictionary(Of String, Object))
        LogUtil.LogInfo("Displaying definitions", MyBase.Name)
        If extractDictionary IsNot Nothing AndAlso extractDictionary.Count > 0 Then
            LoadDefinitionIntoBrowser(sWord, extractDictionary)
        Else
            Dim _propercase As String = StrConv(sWord, VbStrConv.ProperCase)
            extractDictionary = SearchWebForWord(_propercase)
            If extractDictionary IsNot Nothing AndAlso extractDictionary.Count > 0 Then
                LoadDefinitionIntoBrowser(_propercase, extractDictionary)
            Else
                ClearBrowser("No meaningful response")
            End If
        End If
    End Sub
    Private Sub LoadDefinitionIntoBrowser(sWord As String, extractDictionary As Dictionary(Of String, Object))
        Dim _html As StringBuilder = BuildDefinitionHtml(extractDictionary, sWord)
        LogUtil.LogInfo("Loading browser", MyBase.Name)
        Dim _page As String = _html.ToString
        WebBrowser1.Navigate("about:blank")
        WebBrowser1.Document.OpenNew(False)
        WebBrowser1.Document.Write(_page)
        WebBrowser1.Refresh()
    End Sub
    Private Function BuildDefinitionHtml(extractDictionary As Dictionary(Of String, Object), _word As String) As StringBuilder
        LogUtil.LogInfo("Building HTML", MyBase.Name)
        Dim _html As New StringBuilder()
        Try
            _html.Append("<HTML><body><div style='font-family:verdana'>")
            isReferral = False
            Dim _baseWord As String = AppendDefinitions(extractDictionary, _word, _html)
            ' If definition refers to the base word of the search word, also look up the base word
            If isReferral AndAlso Not String.IsNullOrEmpty(_baseWord) Then
                extractDictionary = SearchWebForWord(_baseWord)
                isReferral = False
                If extractDictionary IsNot Nothing AndAlso extractDictionary.Count > 0 Then
                    AppendDefinitions(extractDictionary, _baseWord, _html)
                End If
            End If
            ' Look up the word in Proper case
            Dim _propercase As String = StrConv(_word, VbStrConv.ProperCase)
            If _propercase <> _word Then
                extractDictionary = SearchWebForWord(_propercase)
                If extractDictionary IsNot Nothing AndAlso extractDictionary.Count > 0 Then
                    AppendDefinitions(extractDictionary, _propercase, _html)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Exception")
        End Try
        _html.Append("</div></body></HTML>")
        Return _html
    End Function
    Private Function AppendDefinitions(extractDictionary As Dictionary(Of String, Object), _word As String, _html As StringBuilder) As String
        Dim _singular As String = String.Empty
        _html.Append("<h2>").Append(_word).Append("</h2>")
        ' Get the extract for the first language in the language list that has one
        Dim _languageExtract As Object = Nothing
        For Each _language In _languages
            extractDictionary.TryGetValue(_language, _languageExtract)
            If _languageExtract IsNot Nothing Then
                Exit For
            End If
        Next
        ' If an extract has been found
        If _languageExtract IsNot Nothing Then
            For Each parts As Dictionary(Of String, Object) In _languageExtract
                GetPartOfSpeech(_html, parts)
                GetLanguage(_html, parts)
                Dim _thisExtractSinglular As String = GetDefinitions(_html, parts)
                If String.IsNullOrEmpty(_singular) Then
                    _singular = _thisExtractSinglular
                End If
            Next
        Else
            _html.Append("<h5>").Append("Not found in selected languages").Append("</h5>")
        End If
        Return _singular
    End Function
    Private Function GetDefinitions(_html As StringBuilder, parts As Dictionary(Of String, Object)) As String
        Dim _singular As String = String.Empty
        Dim _definitionsExtract As Object = Nothing
        parts.TryGetValue("definitions", _definitionsExtract)
        If _definitionsExtract IsNot Nothing Then
            _singular = BuildDefinitionList(_html, _definitionsExtract)
        End If
        Return _singular
    End Function
    Private Sub GetLanguage(_html As StringBuilder, parts As Dictionary(Of String, Object))
        Dim _lang As String = ""
        parts.TryGetValue("language", _lang)
        If _lang IsNot Nothing Then _html.Append("<h5>").Append(_lang).Append("</h5>")
    End Sub
    Private Function GetPartOfSpeech(_html As StringBuilder, parts As Dictionary(Of String, Object)) As String
        Dim _partOfSpeech As String = ""
        parts.TryGetValue("partOfSpeech", _partOfSpeech)
        If _partOfSpeech IsNot Nothing Then _html.Append("<h3>").Append(_partOfSpeech).Append("</h3>")
        Return _partOfSpeech
    End Function
    Private Function BuildDefinitionList(_html As StringBuilder, _definitionsExtract As Object) As String
        Dim _singular As String = String.Empty
        _html.Append("<ul>")
        For Each definition As Dictionary(Of String, Object) In _definitionsExtract
            Dim _definitionText As String = String.Empty
            definition.TryGetValue("definition", _definitionText)
            If Not String.IsNullOrEmpty(_definitionText) Then
                Dim _thisDefSingular As String = AddDefinitionToList(_html, definition)
                If String.IsNullOrEmpty(_singular) Then
                    _singular = _thisDefSingular
                End If
            End If
        Next
        _html.Append("</ul>")
        Return _singular
    End Function
    Private Function AddDefinitionToList(_html As StringBuilder, definition As Dictionary(Of String, Object)) As String
        Dim _definitionText As String = ""
        Dim _baseWord As String = String.Empty
        definition.TryGetValue("definition", _definitionText)
        Dim _pureText As String = Regex.Replace(_definitionText, "<.*?>", "")
        For Each _referral As String In oReferralText
            If _pureText.Trim.StartsWith(_referral) Then
                isReferral = True
                _baseWord = _pureText.Remove(0, _referral.Length)
                Exit For
            End If
        Next
        If _definitionText IsNot Nothing Then

            _html.Append("<li>").Append(Regex.Replace(_definitionText.ToString, "<.*?>", "")).Append("</li>")
        End If
        Return _baseWord.Trim(".")
    End Function
    Private Function SearchWebForWord(ByVal sWord As String) As Dictionary(Of String, Object)
        LogUtil.LogInfo("Searching web for word " & sWord, MyBase.Name)
        Dim extractDictionary As New Dictionary(Of String, Object)
        Dim _response As String = NavigateToUrl(My.Settings.wikiExtractSearch & sWord)
        If _response IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(_response) Then
                extractDictionary = GetExtractFromResponse(_response)
            End If
        End If
        Return extractDictionary
    End Function
    Public Function GetExtractFromResponse(wikipage As String) As Dictionary(Of String, Object)
        Dim extractDictionary As Dictionary(Of String, Object) = Nothing
        Try
            Dim jss As New JavaScriptSerializer()
            extractDictionary = jss.Deserialize(Of Dictionary(Of String, Object))(wikipage)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Exception")
        End Try
        Return extractDictionary
    End Function
    Private Function NavigateToUrl(pSearchString As String) As String
        Dim _response As String = String.Empty
        Try
            Dim _webClient As New WebClient With {
                .Encoding = System.Text.Encoding.GetEncoding("utf-8")
            }
            _webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64)")
            _response = _webClient.DownloadString(pSearchString)
        Catch ex As Exception
            ClearBrowser(ex.Message)
        End Try
        Return _response
    End Function

#End Region
End Class
