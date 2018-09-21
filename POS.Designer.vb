<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POS
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descript = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txttotalamount = New System.Windows.Forms.TextBox()
        Me.txtdiscountamount = New System.Windows.Forms.TextBox()
        Me.txtcost = New System.Windows.Forms.TextBox()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmdremoveall = New System.Windows.Forms.Button()
        Me.cmdviewproduct = New System.Windows.Forms.Button()
        Me.cmdtender = New System.Windows.Forms.Button()
        Me.cmdremove = New System.Windows.Forms.Button()
        Me.cmdcustomersearch = New System.Windows.Forms.Button()
        Me.txtcustomerid = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.DataGridView2)
        Me.Panel1.Controls.Add(Me.Panel12)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.txtcustomerid)
        Me.Panel1.Location = New System.Drawing.Point(7, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 586)
        Me.Panel1.TabIndex = 9
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.ProductID, Me.Descript, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.GridColor = System.Drawing.Color.Black
        Me.DataGridView2.Location = New System.Drawing.Point(11, 35)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(1076, 398)
        Me.DataGridView2.TabIndex = 104
        '
        'Column7
        '
        Me.Column7.HeaderText = "Stocks"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 81
        '
        'ProductID
        '
        Me.ProductID.HeaderText = "Product ID"
        Me.ProductID.Name = "ProductID"
        Me.ProductID.ReadOnly = True
        Me.ProductID.Width = 108
        '
        'Descript
        '
        Me.Descript.HeaderText = "Description"
        Me.Descript.Name = "Descript"
        Me.Descript.ReadOnly = True
        Me.Descript.Width = 400
        '
        'Column3
        '
        Me.Column3.HeaderText = "Quantity"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 91
        '
        'Column4
        '
        Me.Column4.HeaderText = "Cost Price"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 104
        '
        'Column5
        '
        Me.Column5.HeaderText = "Discount"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 95
        '
        'Column6
        '
        Me.Column6.HeaderText = "Total Price"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 106
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Black
        Me.Panel12.Controls.Add(Me.Label11)
        Me.Panel12.Controls.Add(Me.Label10)
        Me.Panel12.Controls.Add(Me.Label9)
        Me.Panel12.Controls.Add(Me.txttotalamount)
        Me.Panel12.Controls.Add(Me.txtdiscountamount)
        Me.Panel12.Controls.Add(Me.txtcost)
        Me.Panel12.Controls.Add(Me.Button21)
        Me.Panel12.Controls.Add(Me.Button20)
        Me.Panel12.Controls.Add(Me.Button19)
        Me.Panel12.Location = New System.Drawing.Point(486, 439)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(601, 137)
        Me.Panel12.TabIndex = 101
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Lime
        Me.Label11.Location = New System.Drawing.Point(2, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(275, 32)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Total Amount (Php) :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(4, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(209, 22)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Discount Amount (Php) :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(4, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(175, 22)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Cost Amount (Php) :"
        '
        'txttotalamount
        '
        Me.txttotalamount.BackColor = System.Drawing.Color.Black
        Me.txttotalamount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txttotalamount.Font = New System.Drawing.Font("Times New Roman", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalamount.ForeColor = System.Drawing.Color.Lime
        Me.txttotalamount.Location = New System.Drawing.Point(195, 86)
        Me.txttotalamount.Name = "txttotalamount"
        Me.txttotalamount.ReadOnly = True
        Me.txttotalamount.Size = New System.Drawing.Size(393, 41)
        Me.txttotalamount.TabIndex = 26
        Me.txttotalamount.Text = "0.00"
        Me.txttotalamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdiscountamount
        '
        Me.txtdiscountamount.BackColor = System.Drawing.Color.Black
        Me.txtdiscountamount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtdiscountamount.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiscountamount.ForeColor = System.Drawing.Color.White
        Me.txtdiscountamount.Location = New System.Drawing.Point(170, 41)
        Me.txtdiscountamount.Name = "txtdiscountamount"
        Me.txtdiscountamount.ReadOnly = True
        Me.txtdiscountamount.Size = New System.Drawing.Size(418, 25)
        Me.txtdiscountamount.TabIndex = 25
        Me.txtdiscountamount.Text = "0.00"
        Me.txtdiscountamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcost
        '
        Me.txtcost.BackColor = System.Drawing.Color.Black
        Me.txtcost.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtcost.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcost.ForeColor = System.Drawing.Color.White
        Me.txtcost.Location = New System.Drawing.Point(162, 8)
        Me.txtcost.Name = "txtcost"
        Me.txtcost.ReadOnly = True
        Me.txtcost.Size = New System.Drawing.Size(426, 25)
        Me.txtcost.TabIndex = 24
        Me.txtcost.Text = "0.00"
        Me.txtcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button21
        '
        Me.Button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button21.ForeColor = System.Drawing.Color.Lime
        Me.Button21.Location = New System.Drawing.Point(1, 74)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(597, 61)
        Me.Button21.TabIndex = 22
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button20
        '
        Me.Button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button20.ForeColor = System.Drawing.Color.White
        Me.Button20.Location = New System.Drawing.Point(0, 36)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(598, 35)
        Me.Button20.TabIndex = 21
        Me.Button20.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button19.ForeColor = System.Drawing.Color.White
        Me.Button19.Location = New System.Drawing.Point(0, 3)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(598, 37)
        Me.Button19.TabIndex = 20
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(174, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 21)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Customer ID:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(13, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(155, 21)
        Me.Label12.TabIndex = 99
        Me.Label12.Text = "Customer Order / s"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.cmdremoveall)
        Me.Panel2.Controls.Add(Me.cmdviewproduct)
        Me.Panel2.Controls.Add(Me.cmdtender)
        Me.Panel2.Controls.Add(Me.cmdremove)
        Me.Panel2.Controls.Add(Me.cmdcustomersearch)
        Me.Panel2.Location = New System.Drawing.Point(13, 439)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(468, 137)
        Me.Panel2.TabIndex = 100
        '
        'Button3
        '
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Enabled = False
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(308, 71)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(139, 50)
        Me.Button3.TabIndex = 47
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmdremoveall
        '
        Me.cmdremoveall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdremoveall.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdremoveall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdremoveall.Location = New System.Drawing.Point(163, 71)
        Me.cmdremoveall.Name = "cmdremoveall"
        Me.cmdremoveall.Size = New System.Drawing.Size(139, 50)
        Me.cmdremoveall.TabIndex = 46
        Me.cmdremoveall.Text = "Remove All"
        Me.cmdremoveall.UseVisualStyleBackColor = True
        '
        'cmdviewproduct
        '
        Me.cmdviewproduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdviewproduct.Enabled = False
        Me.cmdviewproduct.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdviewproduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdviewproduct.Location = New System.Drawing.Point(18, 71)
        Me.cmdviewproduct.Name = "cmdviewproduct"
        Me.cmdviewproduct.Size = New System.Drawing.Size(139, 50)
        Me.cmdviewproduct.TabIndex = 45
        Me.cmdviewproduct.Text = "Product List"
        Me.cmdviewproduct.UseVisualStyleBackColor = True
        '
        'cmdtender
        '
        Me.cmdtender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdtender.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdtender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdtender.Location = New System.Drawing.Point(308, 17)
        Me.cmdtender.Name = "cmdtender"
        Me.cmdtender.Size = New System.Drawing.Size(139, 50)
        Me.cmdtender.TabIndex = 44
        Me.cmdtender.Text = "Purchase"
        Me.cmdtender.UseVisualStyleBackColor = True
        '
        'cmdremove
        '
        Me.cmdremove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdremove.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdremove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdremove.Location = New System.Drawing.Point(163, 17)
        Me.cmdremove.Name = "cmdremove"
        Me.cmdremove.Size = New System.Drawing.Size(139, 50)
        Me.cmdremove.TabIndex = 43
        Me.cmdremove.Text = "Remove Item"
        Me.cmdremove.UseVisualStyleBackColor = True
        '
        'cmdcustomersearch
        '
        Me.cmdcustomersearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdcustomersearch.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcustomersearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdcustomersearch.Location = New System.Drawing.Point(18, 17)
        Me.cmdcustomersearch.Name = "cmdcustomersearch"
        Me.cmdcustomersearch.Size = New System.Drawing.Size(139, 50)
        Me.cmdcustomersearch.TabIndex = 42
        Me.cmdcustomersearch.Text = "CustomerList"
        Me.cmdcustomersearch.UseVisualStyleBackColor = True
        '
        'txtcustomerid
        '
        Me.txtcustomerid.AutoSize = True
        Me.txtcustomerid.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcustomerid.ForeColor = System.Drawing.Color.Black
        Me.txtcustomerid.Location = New System.Drawing.Point(288, 11)
        Me.txtcustomerid.Name = "txtcustomerid"
        Me.txtcustomerid.Size = New System.Drawing.Size(19, 21)
        Me.txtcustomerid.TabIndex = 103
        Me.txtcustomerid.Text = "0"
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.CPRSS_v1._0.My.Resources.Resources.Close_Box_Red
        Me.PictureBox2.Location = New System.Drawing.Point(1083, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 15)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'POS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1114, 625)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "POS"
        Me.Text = "POS"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txttotalamount As System.Windows.Forms.TextBox
    Friend WithEvents txtdiscountamount As System.Windows.Forms.TextBox
    Friend WithEvents txtcost As System.Windows.Forms.TextBox
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cmdremoveall As System.Windows.Forms.Button
    Friend WithEvents cmdviewproduct As System.Windows.Forms.Button
    Friend WithEvents cmdtender As System.Windows.Forms.Button
    Friend WithEvents cmdremove As System.Windows.Forms.Button
    Friend WithEvents cmdcustomersearch As System.Windows.Forms.Button
    Friend WithEvents txtcustomerid As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descript As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
