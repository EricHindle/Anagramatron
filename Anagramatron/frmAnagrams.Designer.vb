<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAnagrams
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAnagrams))
        Me.TxtLetters = New System.Windows.Forms.TextBox()
        Me.TxtPattern = New System.Windows.Forms.TextBox()
        Me.TxtMinLen = New System.Windows.Forms.TextBox()
        Me.TxtMaxLen = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblWordCount = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnGetAnagrams = New System.Windows.Forms.Button()
        Me.BtnInterrupt = New System.Windows.Forms.Button()
        Me.BtnAnagClose = New System.Windows.Forms.Button()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnXword = New System.Windows.Forms.Button()
        Me.BtnShowLog = New System.Windows.Forms.Button()
        Me.TxtCrosswordLength = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.LstWords = New System.Windows.Forms.ListBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TxtDefineWord = New System.Windows.Forms.TextBox()
        Me.BtnDefine = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkFindLargest = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblCompany = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtLetters
        '
        Me.TxtLetters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLetters.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLetters.Location = New System.Drawing.Point(77, 33)
        Me.TxtLetters.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLetters.Name = "TxtLetters"
        Me.TxtLetters.Size = New System.Drawing.Size(272, 27)
        Me.TxtLetters.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.TxtLetters, "Type the letters to be used in the anagrams")
        '
        'TxtPattern
        '
        Me.TxtPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPattern.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPattern.Location = New System.Drawing.Point(85, 33)
        Me.TxtPattern.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPattern.Name = "TxtPattern"
        Me.TxtPattern.Size = New System.Drawing.Size(268, 27)
        Me.TxtPattern.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.TxtPattern, "Pattern that words must match using ? for single letters, * for multiple characte" &
        "rs")
        '
        'TxtMinLen
        '
        Me.TxtMinLen.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMinLen.Location = New System.Drawing.Point(125, 65)
        Me.TxtMinLen.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMinLen.Name = "TxtMinLen"
        Me.TxtMinLen.Size = New System.Drawing.Size(40, 27)
        Me.TxtMinLen.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtMinLen, "Minimum length of words to be found")
        '
        'TxtMaxLen
        '
        Me.TxtMaxLen.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaxLen.Location = New System.Drawing.Point(125, 97)
        Me.TxtMaxLen.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMaxLen.Name = "TxtMaxLen"
        Me.TxtMaxLen.Size = New System.Drawing.Size(40, 27)
        Me.TxtMaxLen.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.TxtMaxLen, "Maximum length of words to be found")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(74, 187)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 40)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Possible" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "solutions :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Max Length :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Letters :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 36)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Pattern :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 68)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 19)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Min Length :"
        '
        'lblWordCount
        '
        Me.lblWordCount.BackColor = System.Drawing.Color.LightGray
        Me.lblWordCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWordCount.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWordCount.Location = New System.Drawing.Point(564, 153)
        Me.lblWordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWordCount.Name = "lblWordCount"
        Me.lblWordCount.Size = New System.Drawing.Size(55, 26)
        Me.lblWordCount.TabIndex = 8
        Me.lblWordCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(351, 157)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 19)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Processing"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(627, 157)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 19)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Words Found"
        '
        'BtnGetAnagrams
        '
        Me.BtnGetAnagrams.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGetAnagrams.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnGetAnagrams.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnGetAnagrams.FlatAppearance.BorderSize = 3
        Me.BtnGetAnagrams.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGetAnagrams.Location = New System.Drawing.Point(247, 66)
        Me.BtnGetAnagrams.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGetAnagrams.Name = "BtnGetAnagrams"
        Me.BtnGetAnagrams.Size = New System.Drawing.Size(92, 53)
        Me.BtnGetAnagrams.TabIndex = 4
        Me.BtnGetAnagrams.Text = "Find Anagrams"
        Me.ToolTip1.SetToolTip(Me.BtnGetAnagrams, "Click to start finding anagrams")
        Me.BtnGetAnagrams.UseVisualStyleBackColor = False
        '
        'BtnInterrupt
        '
        Me.BtnInterrupt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnInterrupt.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnInterrupt.Enabled = False
        Me.BtnInterrupt.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue
        Me.BtnInterrupt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnInterrupt.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnInterrupt.Location = New System.Drawing.Point(13, 403)
        Me.BtnInterrupt.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnInterrupt.Name = "BtnInterrupt"
        Me.BtnInterrupt.Size = New System.Drawing.Size(124, 32)
        Me.BtnInterrupt.TabIndex = 3
        Me.BtnInterrupt.Text = "Interrupt Search"
        Me.ToolTip1.SetToolTip(Me.BtnInterrupt, "Click to stop looking for anagrams")
        Me.BtnInterrupt.UseVisualStyleBackColor = False
        '
        'BtnAnagClose
        '
        Me.BtnAnagClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAnagClose.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnAnagClose.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue
        Me.BtnAnagClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAnagClose.ForeColor = System.Drawing.Color.White
        Me.BtnAnagClose.Location = New System.Drawing.Point(34, 502)
        Me.BtnAnagClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAnagClose.Name = "BtnAnagClose"
        Me.BtnAnagClose.Size = New System.Drawing.Size(83, 32)
        Me.BtnAnagClose.TabIndex = 5
        Me.BtnAnagClose.Text = "Close"
        Me.ToolTip1.SetToolTip(Me.BtnAnagClose, "Close the program")
        Me.BtnAnagClose.UseVisualStyleBackColor = False
        '
        'lblProgress
        '
        Me.lblProgress.BackColor = System.Drawing.Color.LightGray
        Me.lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProgress.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.Location = New System.Drawing.Point(438, 153)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(82, 26)
        Me.lblProgress.TabIndex = 7
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(39, 279)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'lblCopyright
        '
        Me.lblCopyright.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.Location = New System.Drawing.Point(163, 540)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(70, 15)
        Me.lblCopyright.TabIndex = 12
        Me.lblCopyright.Text = "Copyright"
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(597, 540)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(140, 15)
        Me.lblVersion.TabIndex = 13
        Me.lblVersion.Text = "version {0}.{1}.{2}"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnXword
        '
        Me.BtnXword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnXword.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnXword.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnXword.FlatAppearance.BorderSize = 3
        Me.BtnXword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnXword.Location = New System.Drawing.Point(250, 66)
        Me.BtnXword.Name = "BtnXword"
        Me.BtnXword.Size = New System.Drawing.Size(92, 53)
        Me.BtnXword.TabIndex = 2
        Me.BtnXword.Text = "Solve Crossword"
        Me.ToolTip1.SetToolTip(Me.BtnXword, "Enter a pattern and find all matching words")
        Me.BtnXword.UseVisualStyleBackColor = False
        '
        'BtnShowLog
        '
        Me.BtnShowLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnShowLog.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnShowLog.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue
        Me.BtnShowLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnShowLog.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnShowLog.Location = New System.Drawing.Point(34, 443)
        Me.BtnShowLog.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnShowLog.Name = "BtnShowLog"
        Me.BtnShowLog.Size = New System.Drawing.Size(83, 32)
        Me.BtnShowLog.TabIndex = 4
        Me.BtnShowLog.Text = "Show Log"
        Me.ToolTip1.SetToolTip(Me.BtnShowLog, "Close the program")
        Me.BtnShowLog.UseVisualStyleBackColor = False
        '
        'TxtCrosswordLength
        '
        Me.TxtCrosswordLength.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCrosswordLength.Location = New System.Drawing.Point(134, 68)
        Me.TxtCrosswordLength.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCrosswordLength.Name = "TxtCrosswordLength"
        Me.TxtCrosswordLength.Size = New System.Drawing.Size(40, 27)
        Me.TxtCrosswordLength.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtCrosswordLength, "Maximum length of words to be found")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(164, 182)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.LstWords)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtDefineWord)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnDefine)
        Me.SplitContainer1.Size = New System.Drawing.Size(618, 352)
        Me.SplitContainer1.SplitterDistance = 178
        Me.SplitContainer1.TabIndex = 23
        '
        'LstWords
        '
        Me.LstWords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstWords.FormattingEnabled = True
        Me.LstWords.ItemHeight = 19
        Me.LstWords.Location = New System.Drawing.Point(0, 0)
        Me.LstWords.Name = "LstWords"
        Me.LstWords.Size = New System.Drawing.Size(174, 348)
        Me.LstWords.TabIndex = 0
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(427, 304)
        Me.WebBrowser1.TabIndex = 2
        '
        'TxtDefineWord
        '
        Me.TxtDefineWord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDefineWord.Location = New System.Drawing.Point(90, 317)
        Me.TxtDefineWord.Name = "TxtDefineWord"
        Me.TxtDefineWord.Size = New System.Drawing.Size(238, 27)
        Me.TxtDefineWord.TabIndex = 1
        '
        'BtnDefine
        '
        Me.BtnDefine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDefine.AutoSize = True
        Me.BtnDefine.BackColor = System.Drawing.Color.LightSteelBlue
        Me.BtnDefine.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue
        Me.BtnDefine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDefine.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDefine.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnDefine.Location = New System.Drawing.Point(12, 316)
        Me.BtnDefine.Name = "BtnDefine"
        Me.BtnDefine.Size = New System.Drawing.Size(60, 29)
        Me.BtnDefine.TabIndex = 0
        Me.BtnDefine.Text = "Define"
        Me.BtnDefine.UseVisualStyleBackColor = False
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.ForeColor = System.Drawing.Color.MidnightBlue
        Me.BtnClear.Location = New System.Drawing.Point(38, 335)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(75, 52)
        Me.BtnClear.TabIndex = 2
        Me.BtnClear.Text = "Clear Form"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 19)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Word Length :"
        '
        'ChkFindLargest
        '
        Me.ChkFindLargest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkFindLargest.AutoSize = True
        Me.ChkFindLargest.Location = New System.Drawing.Point(209, 4)
        Me.ChkFindLargest.Name = "ChkFindLargest"
        Me.ChkFindLargest.Size = New System.Drawing.Size(140, 23)
        Me.ChkFindLargest.TabIndex = 3
        Me.ChkFindLargest.Text = "Find largest word"
        Me.ChkFindLargest.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(29, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(166, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Replace missing characters with ?"
        '
        'LblCompany
        '
        Me.LblCompany.AutoSize = True
        Me.LblCompany.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCompany.Location = New System.Drawing.Point(12, 294)
        Me.LblCompany.Name = "LblCompany"
        Me.LblCompany.Size = New System.Drawing.Size(49, 15)
        Me.LblCompany.TabIndex = 11
        Me.LblCompany.Text = "by {0}"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 27)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Anagrams"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Location = New System.Drawing.Point(62, 12)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TxtLetters)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChkFindLargest)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TxtMinLen)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TxtMaxLen)
        Me.SplitContainer2.Panel1.Controls.Add(Me.BtnGetAnagrams)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label11)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TxtPattern)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel2.Controls.Add(Me.BtnXword)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TxtCrosswordLength)
        Me.SplitContainer2.Size = New System.Drawing.Size(724, 133)
        Me.SplitContainer2.SplitterDistance = 361
        Me.SplitContainer2.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(171, 27)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Crossword Solver"
        '
        'FrmAnagrams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(794, 561)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.LblCompany)
        Me.Controls.Add(Me.BtnShowLog)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnAnagClose)
        Me.Controls.Add(Me.BtnInterrupt)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblWordCount)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(810, 600)
        Me.Name = "FrmAnagrams"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anagramatron"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtLetters As System.Windows.Forms.TextBox
    Friend WithEvents TxtPattern As System.Windows.Forms.TextBox
    Friend WithEvents TxtMinLen As System.Windows.Forms.TextBox
    Friend WithEvents TxtMaxLen As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblWordCount As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnGetAnagrams As System.Windows.Forms.Button
    Friend WithEvents BtnInterrupt As System.Windows.Forms.Button
    Friend WithEvents BtnAnagClose As System.Windows.Forms.Button
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtnXword As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnShowLog As Button
    Friend WithEvents LstWords As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtCrosswordLength As TextBox
    Friend WithEvents ChkFindLargest As CheckBox
    Friend WithEvents BtnDefine As Button
    Friend WithEvents TxtDefineWord As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LblCompany As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Label11 As Label
End Class
