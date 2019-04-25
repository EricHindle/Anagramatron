Imports System.IO
Imports System.Security.Cryptography
Imports System.Text


Public Class frmAnagrams
    Public bStop As Boolean
    Dim tdes As TripleDESCryptoServiceProvider
    Dim cTransform As ICryptoTransform
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


    Private Sub cmdAnagClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnagClose.Click
        Me.Close()
    End Sub

    Private Sub cmdGetAnagrams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetAnagrams.Click
        txtDef.Text = ""
        txtDef.Enabled = False
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

            If CInt(txtMaxLen.Text) > txtLetters.Text.Length Then
                txtMaxLen.Text = CStr(txtLetters.Text.Length)
            End If
            For Me.CurrLen = txtMaxLen.Text To txtMinLen.Text Step -1
                WordsFound = 0
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
                            txtDef.Text = "Double-click a word to see definitions"
                            txtDef.Enabled = True

                            Exit Sub
                        End If
                        toEncryptArray = Convert.FromBase64String(Dictionary.ReadLine)
                        resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
                        DictWord = UTF8Encoding.UTF8.GetString(resultArray)
                        DictWord = Replace(DictWord, " ", "")
                        DictWord = Replace(DictWord, "'", "")
                        DictWord = Replace(DictWord, "-", "")
                        DictWord = LCase(DictWord)
                        WordLen = DictWord.Length
                        If WordLen = CurrLen Then
                            TestWord = DictWord
                            TestChars = txtLetters.Text.ToLower
                            For Me.Ct = 1 To WordLen
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
        txtDef.Text = "Double-click a word to see definitions"
        txtDef.Enabled = True
        cmdInterrupt.Enabled = False
        cmdGetAnagrams.Enabled = True
        btnXword.Enabled = True
    End Sub


    Private Sub cmdInterrupt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInterrupt.Click
        bStop = True
    End Sub

    Private Sub frmAnagrams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDef.Enabled = False
        Label10.Text = My.Application.Info.Copyright
        Label11.Text = "Version: " & My.Application.Info.Version.Major & _
        "." & My.Application.Info.Version.Minor & _
        "." & My.Application.Info.Version.Revision & _
        "." & My.Application.Info.Version.Build

        tdes = New TripleDESCryptoServiceProvider()

        keyArray = UTF8Encoding.UTF8.GetBytes("QzoSB6UxAQ2x95am")
        'set the secret key for the tripleDES algorithm
        tdes.Key = keyArray

        'mode of operation. there are other 4 modes. 
        'We choose ECB(Electronic code Book)
        tdes.Mode = CipherMode.ECB

        'padding mode(if any extra byte added)
        tdes.Padding = PaddingMode.ISO10126

        cTransform = tdes.CreateDecryptor()

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
                        resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
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
            sWord = txtAnagrams.SelectedText

            Dim DefsText As String = checkDictionaries(sWord)
            If DefsText.Length = 0 Then
                If sWord.EndsWith("s") And Not sWord.EndsWith("ss") Then
                    DefsText = checkDictionaries(sWord.Substring(0, sWord.Length - 1))
                End If
            End If

            If DefsText.Length = 0 Then
                DefsText = GetDefinitions(sWord)
            End If
            If DefsText.Length = 0 Then
                If sWord.EndsWith("s") And Not sWord.EndsWith("ss") Then
                    DefsText = GetDefinitions(sWord.Substring(0, sWord.Length - 1))
                End If
            End If

            If DefsText.Length > 0 Then
                txtDef.Text = DefsText

            Else
                txtDef.Text = "No definition found for " & sWord
            End If
        End If
    End Sub
    Private Function checkDictionaries(ByVal sWord As String) As String
        Dim DefsText As String = GetDefinitions(sWord, "wn")
        If DefsText.Length = 0 Then
            DefsText = GetDefinitions(sWord, "gcide")
        End If
        Return DefsText
    End Function
    Private Function GetDefinitions(ByVal sWord As String, Optional ByVal sDict As String = Nothing) As String
        Dim sDefinitions As New StringBuilder
        Dim myDictSrv As New DictService.DictServiceSoapClient("DictServiceSoap")
        Dim adefs As DictService.WordDefinition
        Try
            If sDict IsNot Nothing Then
                adefs = myDictSrv.DefineInDict(sDict, sWord)
            Else
                adefs = myDictSrv.Define(sWord)
            End If
            For Each def As DictService.Definition In adefs.Definitions
                Dim sDef As String = def.WordDefinition
                sDef = sDef.Replace(vbLf, vbCrLf)
                sDefinitions.Append(sDef).Append(vbCrLf)
            Next
        Catch ex As System.ServiceModel.EndpointNotFoundException
            sDefinitions.Append("Cannot connect to the dictionaries. Check Internet connection.").Append(vbCrLf)
        Catch ex1 As Exception
            sDefinitions.Append("Unexpected programme error:").Append(vbCrLf)
            sDefinitions.Append(ex1.Message).Append(vbCrLf)
        End Try
        Return sDefinitions.ToString
    End Function



End Class
