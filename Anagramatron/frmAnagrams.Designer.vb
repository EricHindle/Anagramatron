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
        Me.TxtAnagrams = New System.Windows.Forms.TextBox()
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtLetters
        '
        Me.TxtLetters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLetters.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLetters.Location = New System.Drawing.Point(152, 22)
        Me.TxtLetters.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLetters.Name = "TxtLetters"
        Me.TxtLetters.Size = New System.Drawing.Size(740, 27)
        Me.TxtLetters.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.TxtLetters, "Type the letters to be used in the anagrams")
        '
        'TxtPattern
        '
        Me.TxtPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPattern.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPattern.Location = New System.Drawing.Point(152, 57)
        Me.TxtPattern.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPattern.Name = "TxtPattern"
        Me.TxtPattern.Size = New System.Drawing.Size(611, 27)
        Me.TxtPattern.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtPattern, "Pattern that words must match using ? for single letters, * for multiple characte" &
        "rs")
        '
        'TxtMinLen
        '
        Me.TxtMinLen.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMinLen.Location = New System.Drawing.Point(209, 97)
        Me.TxtMinLen.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMinLen.Name = "TxtMinLen"
        Me.TxtMinLen.Size = New System.Drawing.Size(55, 27)
        Me.TxtMinLen.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.TxtMinLen, "Minimum length of words to be found")
        '
        'TxtMaxLen
        '
        Me.TxtMaxLen.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaxLen.Location = New System.Drawing.Point(431, 97)
        Me.TxtMaxLen.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMaxLen.Name = "TxtMaxLen"
        Me.TxtMaxLen.Size = New System.Drawing.Size(55, 27)
        Me.TxtMaxLen.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.TxtMaxLen, "Maximum length of words to be found")
        '
        'TxtAnagrams
        '
        Me.TxtAnagrams.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtAnagrams.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAnagrams.Location = New System.Drawing.Point(0, 0)
        Me.TxtAnagrams.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtAnagrams.Multiline = True
        Me.TxtAnagrams.Name = "TxtAnagrams"
        Me.TxtAnagrams.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtAnagrams.Size = New System.Drawing.Size(207, 383)
        Me.TxtAnagrams.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TxtAnagrams, "Editable list of words made from the letters")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 135)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Anagrams :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(294, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Maximum Length :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(75, 25)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Letters :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(75, 60)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Pattern :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(75, 100)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Minimum Length :"
        '
        'lblWordCount
        '
        Me.lblWordCount.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblWordCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWordCount.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWordCount.Location = New System.Drawing.Point(82, 254)
        Me.lblWordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWordCount.Name = "lblWordCount"
        Me.lblWordCount.Size = New System.Drawing.Size(55, 26)
        Me.lblWordCount.TabIndex = 11
        Me.lblWordCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(70, 188)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 19)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Processing"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(63, 284)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 19)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Words Found"
        '
        'BtnGetAnagrams
        '
        Me.BtnGetAnagrams.BackColor = System.Drawing.Color.Thistle
        Me.BtnGetAnagrams.Location = New System.Drawing.Point(13, 320)
        Me.BtnGetAnagrams.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGetAnagrams.Name = "BtnGetAnagrams"
        Me.BtnGetAnagrams.Size = New System.Drawing.Size(132, 27)
        Me.BtnGetAnagrams.TabIndex = 14
        Me.BtnGetAnagrams.Text = "Find Anagrams"
        Me.ToolTip1.SetToolTip(Me.BtnGetAnagrams, "Click to start finding anagrams")
        Me.BtnGetAnagrams.UseVisualStyleBackColor = False
        '
        'BtnInterrupt
        '
        Me.BtnInterrupt.BackColor = System.Drawing.Color.Thistle
        Me.BtnInterrupt.Enabled = False
        Me.BtnInterrupt.Location = New System.Drawing.Point(13, 396)
        Me.BtnInterrupt.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnInterrupt.Name = "BtnInterrupt"
        Me.BtnInterrupt.Size = New System.Drawing.Size(83, 27)
        Me.BtnInterrupt.TabIndex = 15
        Me.BtnInterrupt.Text = "Interrupt"
        Me.ToolTip1.SetToolTip(Me.BtnInterrupt, "Click to stop looking for anagrams")
        Me.BtnInterrupt.UseVisualStyleBackColor = False
        '
        'BtnAnagClose
        '
        Me.BtnAnagClose.BackColor = System.Drawing.Color.Thistle
        Me.BtnAnagClose.Location = New System.Drawing.Point(13, 431)
        Me.BtnAnagClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAnagClose.Name = "BtnAnagClose"
        Me.BtnAnagClose.Size = New System.Drawing.Size(83, 27)
        Me.BtnAnagClose.TabIndex = 16
        Me.BtnAnagClose.Text = "Close"
        Me.ToolTip1.SetToolTip(Me.BtnAnagClose, "Close the program")
        Me.BtnAnagClose.UseVisualStyleBackColor = False
        '
        'lblProgress
        '
        Me.lblProgress.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProgress.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.Location = New System.Drawing.Point(68, 211)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(82, 26)
        Me.lblProgress.TabIndex = 10
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(13, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(39, 279)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'lblCopyright
        '
        Me.lblCopyright.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCopyright.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.Location = New System.Drawing.Point(149, 539)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(148, 13)
        Me.lblCopyright.TabIndex = 18
        Me.lblCopyright.Text = "Label10"
        Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(726, 539)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(166, 13)
        Me.lblVersion.TabIndex = 19
        Me.lblVersion.Text = "Label11"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnXword
        '
        Me.BtnXword.BackColor = System.Drawing.Color.Thistle
        Me.BtnXword.Location = New System.Drawing.Point(13, 354)
        Me.BtnXword.Name = "BtnXword"
        Me.BtnXword.Size = New System.Drawing.Size(132, 27)
        Me.BtnXword.TabIndex = 20
        Me.BtnXword.Text = "Crossword Solver"
        Me.ToolTip1.SetToolTip(Me.BtnXword, "Enter a pattern and find all matching words")
        Me.BtnXword.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(164, 138)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtAnagrams)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Size = New System.Drawing.Size(728, 387)
        Me.SplitContainer1.SplitterDistance = 211
        Me.SplitContainer1.TabIndex = 23
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(509, 383)
        Me.WebBrowser1.TabIndex = 23
        '
        'FrmAnagrams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(906, 564)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BtnXword)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnAnagClose)
        Me.Controls.Add(Me.BtnInterrupt)
        Me.Controls.Add(Me.BtnGetAnagrams)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblWordCount)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMaxLen)
        Me.Controls.Add(Me.TxtMinLen)
        Me.Controls.Add(Me.TxtPattern)
        Me.Controls.Add(Me.TxtLetters)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmAnagrams"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anagramatron"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtLetters As System.Windows.Forms.TextBox
    Friend WithEvents TxtPattern As System.Windows.Forms.TextBox
    Friend WithEvents TxtMinLen As System.Windows.Forms.TextBox
    Friend WithEvents TxtMaxLen As System.Windows.Forms.TextBox
    Friend WithEvents TxtAnagrams As System.Windows.Forms.TextBox
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
End Class
