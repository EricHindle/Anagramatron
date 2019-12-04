Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.Script.Serialization

Public Class FrmAnagrams
#Region "variables"
    Public bStop As Boolean

    Dim keyArray As Byte()
    Dim WordsFound As Long
    Dim toEncryptArray As Byte()
    Dim resultArray As Byte()
    Dim DictWord As String
    Dim TestWord As String
    Dim TestChars As String
    Dim TestChar As String
    Dim CharPos As Integer
    Dim Ct As Integer
    Dim WordLen As Integer
    Dim CurrLen As Integer
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
    Private Sub CmdAnagClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnagClose.Click
        Me.Close()
    End Sub
    Private Sub cmdGetAnagrams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetAnagrams.Click
        Dim iMin As Integer
        Dim iMax As Integer
        Try
            iMax = Val(txtMaxLen.Text) + 0
            iMin = Val(txtMinLen.Text) + 0
            If iMax = 0 Or iMin = 0 Or iMin > iMax Then
                MsgBox("Invalid length value(s)", vbExclamation)
                Exit Sub
            End If
            txtLetters.Text = Replace(txtLetters.Text, " ", "")
            If Len(txtLetters.Text) < iMin Then
                MsgBox("Not enough letters for minimum length")
                Exit Sub
            End If

            bStop = False
            cmdInterrupt.Enabled = True
            cmdGetAnagrams.Enabled = False
            btnXword.Enabled = False
            Label6.Text = "---Start---"
            txtAnagrams.Text = ""
            ClearBrowser
            If CInt(txtMaxLen.Text) > txtLetters.Text.Length Then
                txtMaxLen.Text = CStr(txtLetters.Text.Length)
            End If
            WordsFound = 0
            For Me.CurrLen = txtMaxLen.Text To txtMinLen.Text Step -1

                Label7.Text = WordsFound
                txtAnagrams.Text = txtAnagrams.Text & vbCrLf & "---" & CurrLen & "---"
                Label6.Text = CurrLen & " letters"
                My.Application.DoEvents()

                Using Dictionary As New StreamReader(Path.Combine(Application.CommonAppDataPath, My.Settings.CodedWordList))

                    Do Until Dictionary.EndOfStream
                        If bStop Then
                            Label6.Text = "--Stopped--"
                            cmdInterrupt.Enabled = False
                            cmdGetAnagrams.Enabled = True
                            ClearBrowser("Double-click a word to see definitions")
                            Exit Sub
                        End If
                        toEncryptArray = Convert.FromBase64String(Dictionary.ReadLine)
                        resultArray = CTransform1.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
                        DictWord = UTF8Encoding.UTF8.GetString(resultArray)
                        DictWord = Replace(DictWord, " ", "")
                        DictWord = Replace(DictWord, "'", "")
                        DictWord = Replace(DictWord, "-", "")
                        DictWord = LCase(DictWord)
                        WordLen = DictWord.Length
                        If WordLen = CurrLen Then
                            TestWord = DictWord
                            TestChars = txtLetters.Text.ToLower
                            For Ct = 1 To WordLen
                                TestChar = Mid(DictWord, Ct, 1)
                                CharPos = InStr(TestChars, TestChar)
                                If CharPos > 0 Then
                                    TestChars = Replace(TestChars, TestChar, "", 1, 1)
                                    TestWord = Replace(TestWord, TestChar, "", 1, 1)
                                End If
                            Next Ct
                            If TestWord = "" Then
                                If txtPattern.Text = "" Or DictWord Like txtPattern.Text Then
                                    txtAnagrams.Text = txtAnagrams.Text & vbCrLf & DictWord
                                    WordsFound = WordsFound + 1
                                    Label7.Text = WordsFound
                                End If
                                My.Application.DoEvents()
                            End If
                        End If
                    Loop
                    Dictionary.Close()
                End Using
            Next CurrLen
        Catch ex As Exception
            MsgBox("A program error has occurred: " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try

        Label6.Text = "---Done---"
        ClearBrowser("Double-click a word to see definitions")
        cmdInterrupt.Enabled = False
        cmdGetAnagrams.Enabled = True
        btnXword.Enabled = True
    End Sub
    Private Sub cmdInterrupt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInterrupt.Click
        bStop = True
    End Sub
    Private Sub FrmAnagrams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label10.Text = My.Application.Info.Copyright
        Label11.Text = "Version: " & My.Application.Info.Version.Major &
        "." & My.Application.Info.Version.Minor &
        "." & My.Application.Info.Version.Revision &
        "." & My.Application.Info.Version.Build

        Tdes1 = New TripleDESCryptoServiceProvider()

        keyArray = UTF8Encoding.UTF8.GetBytes("QzoSB6UxAQ2x95am")
        'set the secret key for the tripleDES algorithm
        Tdes1.Key = keyArray

        'mode of operation. there are other 4 modes. 
        'We choose ECB(Electronic code Book)
        Tdes1.Mode = CipherMode.ECB

        'padding mode(if any extra byte added)
        Tdes1.Padding = PaddingMode.ISO10126

        CTransform1 = Tdes1.CreateDecryptor()

    End Sub
    Private Sub btnXword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXword.Click
        If txtPattern.TextLength = 0 Then
            MsgBox("You must provide a pattern with ? for missing letters", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
        Else
            txtPattern.Text = Replace(txtPattern.Text, " ", "")
            txtMinLen.Text = CStr(txtPattern.TextLength)
            txtMaxLen.Text = CStr(txtPattern.TextLength)
            Dim regex As New RegularExpressions.Regex("[^a-zA-Z?]")
            If regex.IsMatch(txtPattern.Text) = True Then
                MsgBox("The pattern can only be letters or ?", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Error")
            Else
                Label6.Text = "---Start---"
                WordsFound = 0
                Label7.Text = WordsFound
                txtAnagrams.Text = ""
                cmdInterrupt.Enabled = True
                cmdGetAnagrams.Enabled = False
                btnXword.Enabled = False
                CurrLen = CInt(txtMaxLen.Text)
                Using Dictionary As New StreamReader(Path.Combine(Application.CommonAppDataPath, My.Settings.CodedWordList))

                    Do Until Dictionary.EndOfStream
                        If bStop Then
                            Label6.Text = "--Stopped--"
                            cmdInterrupt.Enabled = False
                            cmdGetAnagrams.Enabled = True
                            Exit Sub
                        End If
                        toEncryptArray = Convert.FromBase64String(Dictionary.ReadLine)
                        resultArray = CTransform1.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
                        DictWord = UTF8Encoding.UTF8.GetString(resultArray)
                        DictWord = Replace(DictWord, " ", "")
                        DictWord = Replace(DictWord, "'", "")
                        DictWord = Replace(DictWord, "-", "")
                        DictWord = LCase(DictWord)
                        WordLen = DictWord.Length
                        If WordLen = CurrLen Then
                            If DictWord Like txtPattern.Text Then
                                txtAnagrams.Text = txtAnagrams.Text & vbCrLf & DictWord
                                WordsFound = WordsFound + 1
                                Label7.Text = WordsFound
                            End If
                            My.Application.DoEvents()
                        End If
                    Loop
                    Dictionary.Close()
                End Using

                Label6.Text = "---Done---"

            End If
        End If
        cmdInterrupt.Enabled = False
        cmdGetAnagrams.Enabled = True
        btnXword.Enabled = True
    End Sub
    Private Sub txtAnagrams_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAnagrams.MouseDoubleClick
        If txtAnagrams.TextLength > 0 Then
            Dim sWord As String
            Dim selstart As Integer = Math.Max(1, txtAnagrams.SelectionStart)
            Dim iend As Integer = txtAnagrams.Text.IndexOf(vbCrLf, selstart)
            If iend < 0 Then
                iend = txtAnagrams.Text.Length
            End If
            Dim istart As Integer = txtAnagrams.Text.Substring(0, selstart).LastIndexOf(vbCrLf)
            If istart < 0 Then
                istart = 0
            End If
            txtAnagrams.SelectionStart = istart
            txtAnagrams.SelectionLength = iend - istart
            sWord = txtAnagrams.SelectedText.Trim(vbCrLf).Trim(vbLf)
            GetDefinitions(sWord)
        End If
    End Sub

    Private Sub txtLetters_TextChanged(sender As Object, e As EventArgs) Handles txtLetters.TextChanged
        txtMinLen.Text = 2
        txtMaxLen.Text = txtLetters.TextLength
    End Sub


#End Region
#Region "subroutines"
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
    Public Function GetWikiExtractString(oText As String) As String
        Return My.Settings.wikiExtractSearch & oText
    End Function
    Public Function GetExtractFromResponse(pResponse As WebResponse) As Dictionary(Of String, Object)
        Dim wikipage As String = ""
        Dim extractDictionary As Dictionary(Of String, Object) = Nothing
        Try
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(pResponse.GetResponseStream())
            wikipage = sr.ReadToEnd
            Dim _html As New StringBuilder("<HTML>")

            Dim jss As New JavaScriptSerializer()
            extractDictionary = jss.Deserialize(Of Dictionary(Of String, Object))(wikipage)

        Catch ex As Exception
            Debug.Print(ex.Message)
            Debug.Print(wikipage)
        End Try
        Return extractDictionary
    End Function
    Private Function BuildDefinitionHtml(extractDictionary As Dictionary(Of String, Object), _word As String) As StringBuilder
        Dim _html As New StringBuilder("<HTML><h2>")
        _html.Append(_word).Append("</h2>")
        Dim languageExtract As Object = Nothing
        Dim definitionsExtract As Object = Nothing
        Dim partOfSpeech As String = ""
        Dim _language As String = ""
        Try

            If extractDictionary.ContainsKey("en") Then
                extractDictionary.TryGetValue("en", languageExtract)
            ElseIf extractDictionary.ContainsKey("other") Then
                extractDictionary.TryGetValue("other", languageExtract)
            End If
            If languageExtract IsNot Nothing Then
                For Each parts As Dictionary(Of String, Object) In languageExtract

                    If parts.ContainsKey("partOfSpeech") Then
                        parts.TryGetValue("partOfSpeech", partOfSpeech)
                        _html.Append("<h3>")
                        _html.Append(partOfSpeech).Append("</h3>")
                    End If
                    If parts.ContainsKey("language") Then
                        parts.TryGetValue("language", _language)
                        _html.Append("<h5>")
                        _html.Append(_language).Append("</h5>")
                    End If
                    If parts.ContainsKey("definitions") Then
                        parts.TryGetValue("definitions", definitionsExtract)
                        _html.Append("<ul>")

                        For Each definition As Dictionary(Of String, Object) In definitionsExtract
                            Dim definitionText As String = ""
                            definition.TryGetValue("definition", definitionText)

                            _html.Append("<li>").Append(Regex.Replace(definitionText.ToString, "<.*?>", "")).Append("</li>")
                        Next
                        _html.Append("</ul>")
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Exception")

        End Try

        _html.Append("</HTML>")
        Return _html

    End Function
    Private Sub GetDefinitions(ByVal sWord As String)
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(sWord))
        If _response IsNot Nothing Then
            Dim extractDictionary As Dictionary(Of String, Object) = GetExtractFromResponse(_response)
            Dim _html As StringBuilder = BuildDefinitionHtml(extractDictionary, sWord)
            WebBrowser1.DocumentText = _html.ToString
            WebBrowser1.Update()
        Else
            ClearBrowser("No response")
        End If

    End Sub
    Private Sub ClearBrowser(Optional stext As String = "")
        WebBrowser1.DocumentText = "<HTML>" & stext & "</HTML>"
        WebBrowser1.Update()
    End Sub
#End Region
End Class
