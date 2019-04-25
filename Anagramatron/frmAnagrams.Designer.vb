<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnagrams
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnagrams))
        Me.txtLetters = New System.Windows.Forms.TextBox
        Me.txtPattern = New System.Windows.Forms.TextBox
        Me.txtMinLen = New System.Windows.Forms.TextBox
        Me.txtMaxLen = New System.Windows.Forms.TextBox
        Me.txtAnagrams = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdGetAnagrams = New System.Windows.Forms.Button
        Me.cmdInterrupt = New System.Windows.Forms.Button
        Me.cmdAnagClose = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnXword = New System.Windows.Forms.Button
        Me.txtDef = New System.Windows.Forms.TextBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLetters
        '
        Me.txtLetters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLetters.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLetters.Location = New System.Drawing.Point(152, 22)
        Me.txtLetters.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLetters.Name = "txtLetters"
        Me.txtLetters.Size = New System.Drawing.Size(458, 27)
        Me.txtLetters.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtLetters, "Type the letters to be used in the anagrams")
        '
        'txtPattern
        '
        Me.txtPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPattern.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPattern.Location = New System.Drawing.Point(152, 57)
        Me.txtPattern.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPattern.Name = "txtPattern"
        Me.txtPattern.Size = New System.Drawing.Size(329, 27)
        Me.txtPattern.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtPattern, "Pattern that words must match using ? for single letters, * for multiple characte" & _
                "rs")
        '
        'txtMinLen
        '
        Me.txtMinLen.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinLen.Location = New System.Drawing.Point(209, 97)
        Me.txtMinLen.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMinLen.Name = "txtMinLen"
        Me.txtMinLen.Size = New System.Drawing.Size(55, 27)
        Me.txtMinLen.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtMinLen, "Minimum length of words to be found")
        '
        'txtMaxLen
        '
        Me.txtMaxLen.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxLen.Location = New System.Drawing.Point(431, 97)
        Me.txtMaxLen.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMaxLen.Name = "txtMaxLen"
        Me.txtMaxLen.Size = New System.Drawing.Size(55, 27)
        Me.txtMaxLen.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtMaxLen, "Maximum length of words to be found")
        '
        'txtAnagrams
        '
        Me.txtAnagrams.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAnagrams.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnagrams.Location = New System.Drawing.Point(0, 0)
        Me.txtAnagrams.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAnagrams.Multiline = True
        Me.txtAnagrams.Name = "txtAnagrams"
        Me.txtAnagrams.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAnagrams.Size = New System.Drawing.Size(153, 387)
        Me.txtAnagrams.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtAnagrams, "Editable list of words made from the letters")
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
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(82, 254)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 26)
        Me.Label7.TabIndex = 11
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'cmdGetAnagrams
        '
        Me.cmdGetAnagrams.BackColor = System.Drawing.Color.Thistle
        Me.cmdGetAnagrams.Location = New System.Drawing.Point(13, 320)
        Me.cmdGetAnagrams.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdGetAnagrams.Name = "cmdGetAnagrams"
        Me.cmdGetAnagrams.Size = New System.Drawing.Size(132, 27)
        Me.cmdGetAnagrams.TabIndex = 14
        Me.cmdGetAnagrams.Text = "Find Anagrams"
        Me.ToolTip1.SetToolTip(Me.cmdGetAnagrams, "Click to start finding anagrams")
        Me.cmdGetAnagrams.UseVisualStyleBackColor = False
        '
        'cmdInterrupt
        '
        Me.cmdInterrupt.BackColor = System.Drawing.Color.Thistle
        Me.cmdInterrupt.Enabled = False
        Me.cmdInterrupt.Location = New System.Drawing.Point(13, 396)
        Me.cmdInterrupt.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdInterrupt.Name = "cmdInterrupt"
        Me.cmdInterrupt.Size = New System.Drawing.Size(83, 27)
        Me.cmdInterrupt.TabIndex = 15
        Me.cmdInterrupt.Text = "Interrupt"
        Me.ToolTip1.SetToolTip(Me.cmdInterrupt, "Click to stop looking for anagrams")
        Me.cmdInterrupt.UseVisualStyleBackColor = False
        '
        'cmdAnagClose
        '
        Me.cmdAnagClose.BackColor = System.Drawing.Color.Thistle
        Me.cmdAnagClose.Location = New System.Drawing.Point(13, 431)
        Me.cmdAnagClose.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAnagClose.Name = "cmdAnagClose"
        Me.cmdAnagClose.Size = New System.Drawing.Size(83, 27)
        Me.cmdAnagClose.TabIndex = 16
        Me.cmdAnagClose.Text = "Close"
        Me.ToolTip1.SetToolTip(Me.cmdAnagClose, "Close the program")
        Me.cmdAnagClose.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(68, 211)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 26)
        Me.Label6.TabIndex = 10
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(149, 539)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Label10"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(444, 539)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(166, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Label11"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnXword
        '
        Me.btnXword.BackColor = System.Drawing.Color.Thistle
        Me.btnXword.Location = New System.Drawing.Point(13, 354)
        Me.btnXword.Name = "btnXword"
        Me.btnXword.Size = New System.Drawing.Size(132, 27)
        Me.btnXword.TabIndex = 20
        Me.btnXword.Text = "Crossword Solver"
        Me.ToolTip1.SetToolTip(Me.btnXword, "Enter a pattern and find all matching words")
        Me.btnXword.UseVisualStyleBackColor = False
        '
        'txtDef
        '
        Me.txtDef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDef.Location = New System.Drawing.Point(0, 0)
        Me.txtDef.Multiline = True
        Me.txtDef.Name = "txtDef"
        Me.txtDef.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDef.Size = New System.Drawing.Size(289, 387)
        Me.txtDef.TabIndex = 22
        Me.txtDef.WordWrap = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(164, 138)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAnagrams)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDef)
        Me.SplitContainer1.Size = New System.Drawing.Size(446, 387)
        Me.SplitContainer1.SplitterDistance = 153
        Me.SplitContainer1.TabIndex = 23
        '
        'frmAnagrams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(624, 564)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnXword)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdAnagClose)
        Me.Controls.Add(Me.cmdInterrupt)
        Me.Controls.Add(Me.cmdGetAnagrams)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMaxLen)
        Me.Controls.Add(Me.txtMinLen)
        Me.Controls.Add(Me.txtPattern)
        Me.Controls.Add(Me.txtLetters)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmAnagrams"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anagramatron"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLetters As System.Windows.Forms.TextBox
    Friend WithEvents txtPattern As System.Windows.Forms.TextBox
    Friend WithEvents txtMinLen As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxLen As System.Windows.Forms.TextBox
    Friend WithEvents txtAnagrams As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdGetAnagrams As System.Windows.Forms.Button
    Friend WithEvents cmdInterrupt As System.Windows.Forms.Button
    Friend WithEvents cmdAnagClose As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnXword As System.Windows.Forms.Button
    Friend WithEvents txtDef As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

End Class
