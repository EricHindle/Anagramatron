Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.Script.Serialization
Public Class FrmAnagrams
#Region "variables"
    Public isStopped As Boolean
    Dim bFindLargest As Boolean
    Dim keyArray As Byte()
    Dim WordsFound As Integer
    Dim toEncryptArray As Byte()
    Dim resultArray As Byte()
    Dim DictWord As String
    Dim TestWord As String
    Dim TestChars As String
    Dim TestChar As String
    Dim CharPos As Integer
    Dim WordLen As Integer
    Dim CurrLen As Integer
    Dim _language As String
    Dim _languages As String() = {"en", "sco", "fr", "de", "es", "pt", "da", "nl", "ro", "la", "af", "nrm", "ca", "oc", "other"}
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
                    Using Dictionary As New StreamReader(Path.Combine(My.Settings.WordListFolder, My.Settings.CodedWordList))
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
    Private Sub CmdInterrupt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInterrupt.Click
        isStopped = True
    End Sub
    Private Sub FrmAnagrams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialise
        lblCopyright.Text = My.Application.Info.Copyright
        lblVersion.Text = "Version: " & My.Application.Info.Version.Major &
        "." & My.Application.Info.Version.Minor &
        "." & My.Application.Info.Version.Revision &
        "." & My.Application.Info.Version.Build
        InitialiseDecryptor()
    End Sub
    Private Sub Initialise()
        If My.Settings.CallUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.CallUpgrade = 1
            My.Settings.Save()
        End If
        LogUtil.LogFolder = My.Settings.LogFolder
        LogUtil.StartLogging()
    End Sub
    Private Sub SolveCrossword(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXword.Click
        isStopped = False
        If TxtPattern.TextLength = 0 Then
            MsgBox("You must provide a pattern with ? for missing letters", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
        Else
            If String.IsNullOrWhiteSpace(TxtCrosswordLength.Text) OrElse Not IsNumeric(TxtCrosswordLength.Text) Then
                MsgBox("You must provide a length for the required word", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
            Else
                TxtPattern.Text = Replace(TxtPattern.Text, " ", "")
                Dim regex As New RegularExpressions.Regex("[^a-zA-Z?*]")
                If regex.IsMatch(TxtPattern.Text) = True Then
                    MsgBox("The pattern can only be letters, * or ?", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
                Else
                    lblProgress.Text = "---Start---"
                    lblProgress.Refresh()
                    WordsFound = 0
                    lblWordCount.Text = WordsFound
                    lblWordCount.Refresh()
                    LstWords.Items.Clear()
                    ClearBrowser()
                    SetButtons(False, False, True)
                    CurrLen = CInt(TxtCrosswordLength.Text)
                    Using Dictionary As New StreamReader(Path.Combine(My.Settings.WordListFolder, My.Settings.CodedWordList))
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
            TxtMaxLen.Text = CStr(TxtPattern.TextLength)
        End If
    End Sub
    Private Sub LstWords_DoubleClick(sender As Object, e As EventArgs) Handles LstWords.DoubleClick
        If LstWords.SelectedIndex > -1 Then
            Dim sWord As String = LstWords.SelectedItem
            GetDefinitions(sWord)
        End If
    End Sub
    Private Sub TxtLetters_TextChanged(sender As Object, e As EventArgs) Handles TxtLetters.TextChanged
        TxtMinLen.Text = TxtLetters.TextLength
        TxtMaxLen.Text = TxtLetters.TextLength
        bFindLargest = True
    End Sub
    Private Sub TxtMinMax_TextChanged(sender As Object, e As EventArgs) Handles TxtMinLen.TextChanged, TxtMaxLen.TextChanged
        bFindLargest = False
    End Sub
#End Region
#Region "subroutines"
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
        WebBrowser1.DocumentText = "<HTML><body><div style='font-family:verdana'>" & stext & "</div></body></HTML>"
        WebBrowser1.Update()
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
    Public Function NavigateToUrl(pSearchString As String) As WebResponse
        Dim _webResponse As WebResponse = Nothing
        Dim request As WebRequest
        Try
            request = WebRequest.Create(pSearchString)
            ' If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials
            _webResponse = request.GetResponse()
        Catch ex As Exception
            ClearBrowser(ex.Message)
        End Try
        Return _webResponse
    End Function
    Public Function GetExtractFromResponse(pResponse As WebResponse) As Dictionary(Of String, Object)
        Dim wikipage As String
        Dim extractDictionary As Dictionary(Of String, Object) = Nothing
        Try
            Dim sr As New System.IO.StreamReader(pResponse.GetResponseStream())
            Dim jss As New JavaScriptSerializer()
            wikipage = sr.ReadToEnd
            extractDictionary = jss.Deserialize(Of Dictionary(Of String, Object))(wikipage)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Exception")
        End Try
        Return extractDictionary
    End Function
    Private Function BuildDefinitionHtml(extractDictionary As Dictionary(Of String, Object), _word As String) As StringBuilder
        Dim _html As New StringBuilder()
        Dim _languageExtract As Object = Nothing
        Try
            _html.Append("<HTML><body><div style='font-family:verdana'>")
            _html.Append("<h2>").Append(_word).Append("</h2>")
            For Each _language In _languages
                extractDictionary.TryGetValue(_language, _languageExtract)
                If _languageExtract IsNot Nothing Then
                    Exit For
                End If
            Next
            If _languageExtract IsNot Nothing Then
                For Each parts As Dictionary(Of String, Object) In _languageExtract
                    GetPartOfSpeech(_html, parts)
                    GetLanguage(_html, parts)
                    GetDefinitions(_html, parts)
                Next
            Else
                _html.Append("<h5>").Append("Not found in selected languages").Append("</h5>")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Exception")
        End Try
        _html.Append("</div></body></HTML>")
        Return _html
    End Function
    Private Shared Sub GetDefinitions(_html As StringBuilder, parts As Dictionary(Of String, Object))
        Dim _definitionsExtract As Object = Nothing
        parts.TryGetValue("definitions", _definitionsExtract)
        If _definitionsExtract IsNot Nothing Then
            BuildDefinitionList(_html, _definitionsExtract)
        End If
    End Sub
    Private Shared Sub GetLanguage(_html As StringBuilder, parts As Dictionary(Of String, Object))
        Dim _lang As String = ""
        parts.TryGetValue("language", _lang)
        If _lang IsNot Nothing Then _html.Append("<h5>").Append(_lang).Append("</h5>")
    End Sub
    Private Shared Function GetPartOfSpeech(_html As StringBuilder, parts As Dictionary(Of String, Object)) As String
        Dim _partOfSpeech As String = ""
        parts.TryGetValue("partOfSpeech", _partOfSpeech)
        If _partOfSpeech IsNot Nothing Then _html.Append("<h3>").Append(_partOfSpeech).Append("</h3>")
        Return _partOfSpeech
    End Function
    Private Shared Sub BuildDefinitionList(_html As StringBuilder, _definitionsExtract As Object)
        _html.Append("<ul>")
        For Each definition As Dictionary(Of String, Object) In _definitionsExtract
            AddDefinitionToList(_html, definition)
        Next
        _html.Append("</ul>")
    End Sub
    Private Shared Sub AddDefinitionToList(_html As StringBuilder, definition As Dictionary(Of String, Object))
        Dim _definitionText As String = ""
        definition.TryGetValue("definition", _definitionText)
        If _definitionText IsNot Nothing Then _html.Append("<li>").Append(Regex.Replace(_definitionText.ToString, "<.*?>", "")).Append("</li>")
    End Sub
    Private Sub GetDefinitions(ByVal sWord As String)
        Dim _response As WebResponse = NavigateToUrl(My.Settings.wikiExtractSearch & sWord)
        If _response IsNot Nothing Then
            Dim extractDictionary As Dictionary(Of String, Object) = GetExtractFromResponse(_response)
            If extractDictionary IsNot Nothing Then
                Dim _html As StringBuilder = BuildDefinitionHtml(extractDictionary, sWord)
                WebBrowser1.DocumentText = _html.ToString
                WebBrowser1.Update()
            Else
                ClearBrowser("No extract in response")
            End If
        Else
            ClearBrowser("No response")
        End If
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        LstWords.Items.Clear()
        ClearBrowser()
        TxtLetters.Text = ""
        TxtMaxLen.Text = ""
        TxtMinLen.Text = ""
        TxtPattern.Text = ""
        lblProgress.Text = ""
        lblWordCount.Text = ""
    End Sub

    Private Sub FrmAnagrams_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub

    Private Sub BtnShowLog_Click(sender As Object, e As EventArgs) Handles BtnShowLog.Click
        Using _log As New FrmLogViewer
            _log.ShowDialog()
        End Using
    End Sub

#End Region
End Class
