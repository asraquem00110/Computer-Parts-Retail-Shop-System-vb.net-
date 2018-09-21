<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Roles
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtroledes = New System.Windows.Forms.TextBox()
        Me.cmadd = New System.Windows.Forms.Button()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdaddroles = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdviewrecords = New System.Windows.Forms.CheckBox()
        Me.cmdupdatesupplier = New System.Windows.Forms.CheckBox()
        Me.cmddeletesupplier = New System.Windows.Forms.CheckBox()
        Me.cmdaddsupplier = New System.Windows.Forms.CheckBox()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdviewsupplier = New System.Windows.Forms.CheckBox()
        Me.cmdupdateinventory = New System.Windows.Forms.CheckBox()
        Me.cmddeleteproduct = New System.Windows.Forms.CheckBox()
        Me.cmdaddproduct = New System.Windows.Forms.CheckBox()
        Me.cmdviewinventory = New System.Windows.Forms.CheckBox()
        Me.cmdupdatecustomer = New System.Windows.Forms.CheckBox()
        Me.cmddeletecustomer = New System.Windows.Forms.CheckBox()
        Me.cmdaddcustomer = New System.Windows.Forms.CheckBox()
        Me.cmdviewcustomer = New System.Windows.Forms.CheckBox()
        Me.cmdviewroles = New System.Windows.Forms.CheckBox()
        Me.cmdupdatesystemusers = New System.Windows.Forms.CheckBox()
        Me.richtexxt = New System.Windows.Forms.RichTextBox()
        Me.cmddeletesystemusers = New System.Windows.Forms.CheckBox()
        Me.cmdaddsystemusers = New System.Windows.Forms.CheckBox()
        Me.cmdviewsystemusers = New System.Windows.Forms.CheckBox()
        Me.cmdmaketransaction = New System.Windows.Forms.CheckBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.cmddelete)
        Me.Panel1.Controls.Add(Me.cmdaddroles)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.DataGridView2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(7, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 586)
        Me.Panel1.TabIndex = 12
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel4.Controls.Add(Me.cmdcancel)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.txtroledes)
        Me.Panel4.Controls.Add(Me.cmadd)
        Me.Panel4.Location = New System.Drawing.Point(11, 440)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(339, 138)
        Me.Panel4.TabIndex = 107
        Me.Panel4.Visible = False
        '
        'cmdcancel
        '
        Me.cmdcancel.Location = New System.Drawing.Point(205, 85)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(111, 41)
        Me.cmdcancel.TabIndex = 26
        Me.cmdcancel.Text = "CANCEL"
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(19, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 21)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Description"
        '
        'txtroledes
        '
        Me.txtroledes.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtroledes.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtroledes.Location = New System.Drawing.Point(23, 50)
        Me.txtroledes.Name = "txtroledes"
        Me.txtroledes.Size = New System.Drawing.Size(293, 29)
        Me.txtroledes.TabIndex = 24
        '
        'cmadd
        '
        Me.cmadd.Location = New System.Drawing.Point(88, 85)
        Me.cmadd.Name = "cmadd"
        Me.cmadd.Size = New System.Drawing.Size(111, 41)
        Me.cmadd.TabIndex = 23
        Me.cmadd.Text = "ADD ROLE"
        Me.cmadd.UseVisualStyleBackColor = True
        '
        'cmddelete
        '
        Me.cmddelete.Location = New System.Drawing.Point(125, 537)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(111, 41)
        Me.cmddelete.TabIndex = 21
        Me.cmddelete.Text = "DELETE ROLE"
        Me.cmddelete.UseVisualStyleBackColor = True
        '
        'cmdaddroles
        '
        Me.cmdaddroles.Location = New System.Drawing.Point(11, 536)
        Me.cmdaddroles.Name = "cmdaddroles"
        Me.cmdaddroles.Size = New System.Drawing.Size(111, 41)
        Me.cmdaddroles.TabIndex = 22
        Me.cmdaddroles.Text = "ADD ROLE"
        Me.cmdaddroles.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmdviewrecords)
        Me.Panel2.Controls.Add(Me.cmdupdatesupplier)
        Me.Panel2.Controls.Add(Me.cmddeletesupplier)
        Me.Panel2.Controls.Add(Me.cmdaddsupplier)
        Me.Panel2.Controls.Add(Me.cmdok)
        Me.Panel2.Controls.Add(Me.cmdviewsupplier)
        Me.Panel2.Controls.Add(Me.cmdupdateinventory)
        Me.Panel2.Controls.Add(Me.cmddeleteproduct)
        Me.Panel2.Controls.Add(Me.cmdaddproduct)
        Me.Panel2.Controls.Add(Me.cmdviewinventory)
        Me.Panel2.Controls.Add(Me.cmdupdatecustomer)
        Me.Panel2.Controls.Add(Me.cmddeletecustomer)
        Me.Panel2.Controls.Add(Me.cmdaddcustomer)
        Me.Panel2.Controls.Add(Me.cmdviewcustomer)
        Me.Panel2.Controls.Add(Me.cmdviewroles)
        Me.Panel2.Controls.Add(Me.cmdupdatesystemusers)
        Me.Panel2.Controls.Add(Me.richtexxt)
        Me.Panel2.Controls.Add(Me.cmddeletesystemusers)
        Me.Panel2.Controls.Add(Me.cmdaddsystemusers)
        Me.Panel2.Controls.Add(Me.cmdviewsystemusers)
        Me.Panel2.Controls.Add(Me.cmdmaketransaction)
        Me.Panel2.Location = New System.Drawing.Point(266, 8)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(811, 547)
        Me.Panel2.TabIndex = 105
        Me.Panel2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(245, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 22)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Query Generated :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 22)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Permissions :"
        '
        'cmdviewrecords
        '
        Me.cmdviewrecords.AutoSize = True
        Me.cmdviewrecords.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdviewrecords.Location = New System.Drawing.Point(30, 464)
        Me.cmdviewrecords.Name = "cmdviewrecords"
        Me.cmdviewrecords.Size = New System.Drawing.Size(120, 23)
        Me.cmdviewrecords.TabIndex = 20
        Me.cmdviewrecords.Text = "View Records"
        Me.cmdviewrecords.UseVisualStyleBackColor = True
        '
        'cmdupdatesupplier
        '
        Me.cmdupdatesupplier.AutoSize = True
        Me.cmdupdatesupplier.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdupdatesupplier.Location = New System.Drawing.Point(30, 441)
        Me.cmdupdatesupplier.Name = "cmdupdatesupplier"
        Me.cmdupdatesupplier.Size = New System.Drawing.Size(135, 23)
        Me.cmdupdatesupplier.TabIndex = 19
        Me.cmdupdatesupplier.Text = "Update Supplier"
        Me.cmdupdatesupplier.UseVisualStyleBackColor = True
        '
        'cmddeletesupplier
        '
        Me.cmddeletesupplier.AutoSize = True
        Me.cmddeletesupplier.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddeletesupplier.Location = New System.Drawing.Point(30, 418)
        Me.cmddeletesupplier.Name = "cmddeletesupplier"
        Me.cmddeletesupplier.Size = New System.Drawing.Size(132, 23)
        Me.cmddeletesupplier.TabIndex = 18
        Me.cmddeletesupplier.Text = "Delete Supplier"
        Me.cmddeletesupplier.UseVisualStyleBackColor = True
        '
        'cmdaddsupplier
        '
        Me.cmdaddsupplier.AutoSize = True
        Me.cmdaddsupplier.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdaddsupplier.Location = New System.Drawing.Point(30, 395)
        Me.cmdaddsupplier.Name = "cmdaddsupplier"
        Me.cmdaddsupplier.Size = New System.Drawing.Size(114, 23)
        Me.cmdaddsupplier.TabIndex = 17
        Me.cmdaddsupplier.Text = "Add Supplier"
        Me.cmdaddsupplier.UseVisualStyleBackColor = True
        '
        'cmdok
        '
        Me.cmdok.Location = New System.Drawing.Point(667, 493)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(111, 41)
        Me.cmdok.TabIndex = 4
        Me.cmdok.Text = "Update"
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'cmdviewsupplier
        '
        Me.cmdviewsupplier.AutoSize = True
        Me.cmdviewsupplier.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdviewsupplier.Location = New System.Drawing.Point(30, 372)
        Me.cmdviewsupplier.Name = "cmdviewsupplier"
        Me.cmdviewsupplier.Size = New System.Drawing.Size(119, 23)
        Me.cmdviewsupplier.TabIndex = 16
        Me.cmdviewsupplier.Text = "View Supplier"
        Me.cmdviewsupplier.UseVisualStyleBackColor = True
        '
        'cmdupdateinventory
        '
        Me.cmdupdateinventory.AutoSize = True
        Me.cmdupdateinventory.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdupdateinventory.Location = New System.Drawing.Point(30, 349)
        Me.cmdupdateinventory.Name = "cmdupdateinventory"
        Me.cmdupdateinventory.Size = New System.Drawing.Size(145, 23)
        Me.cmdupdateinventory.TabIndex = 15
        Me.cmdupdateinventory.Text = "Update Inventory"
        Me.cmdupdateinventory.UseVisualStyleBackColor = True
        '
        'cmddeleteproduct
        '
        Me.cmddeleteproduct.AutoSize = True
        Me.cmddeleteproduct.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddeleteproduct.Location = New System.Drawing.Point(30, 325)
        Me.cmddeleteproduct.Name = "cmddeleteproduct"
        Me.cmddeleteproduct.Size = New System.Drawing.Size(128, 23)
        Me.cmddeleteproduct.TabIndex = 14
        Me.cmddeleteproduct.Text = "Delete Product"
        Me.cmddeleteproduct.UseVisualStyleBackColor = True
        '
        'cmdaddproduct
        '
        Me.cmdaddproduct.AutoSize = True
        Me.cmdaddproduct.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdaddproduct.Location = New System.Drawing.Point(30, 300)
        Me.cmdaddproduct.Name = "cmdaddproduct"
        Me.cmdaddproduct.Size = New System.Drawing.Size(110, 23)
        Me.cmdaddproduct.TabIndex = 13
        Me.cmdaddproduct.Text = "Add Product"
        Me.cmdaddproduct.UseVisualStyleBackColor = True
        '
        'cmdviewinventory
        '
        Me.cmdviewinventory.AutoSize = True
        Me.cmdviewinventory.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdviewinventory.Location = New System.Drawing.Point(30, 277)
        Me.cmdviewinventory.Name = "cmdviewinventory"
        Me.cmdviewinventory.Size = New System.Drawing.Size(129, 23)
        Me.cmdviewinventory.TabIndex = 12
        Me.cmdviewinventory.Text = "View Inventory"
        Me.cmdviewinventory.UseVisualStyleBackColor = True
        '
        'cmdupdatecustomer
        '
        Me.cmdupdatecustomer.AutoSize = True
        Me.cmdupdatecustomer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdupdatecustomer.Location = New System.Drawing.Point(30, 254)
        Me.cmdupdatecustomer.Name = "cmdupdatecustomer"
        Me.cmdupdatecustomer.Size = New System.Drawing.Size(145, 23)
        Me.cmdupdatecustomer.TabIndex = 11
        Me.cmdupdatecustomer.Text = "Update Customer"
        Me.cmdupdatecustomer.UseVisualStyleBackColor = True
        '
        'cmddeletecustomer
        '
        Me.cmddeletecustomer.AutoSize = True
        Me.cmddeletecustomer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddeletecustomer.Location = New System.Drawing.Point(30, 231)
        Me.cmddeletecustomer.Name = "cmddeletecustomer"
        Me.cmddeletecustomer.Size = New System.Drawing.Size(142, 23)
        Me.cmddeletecustomer.TabIndex = 10
        Me.cmddeletecustomer.Text = "Delete Customer"
        Me.cmddeletecustomer.UseVisualStyleBackColor = True
        '
        'cmdaddcustomer
        '
        Me.cmdaddcustomer.AutoSize = True
        Me.cmdaddcustomer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdaddcustomer.Location = New System.Drawing.Point(30, 208)
        Me.cmdaddcustomer.Name = "cmdaddcustomer"
        Me.cmdaddcustomer.Size = New System.Drawing.Size(124, 23)
        Me.cmdaddcustomer.TabIndex = 9
        Me.cmdaddcustomer.Text = "Add Customer"
        Me.cmdaddcustomer.UseVisualStyleBackColor = True
        '
        'cmdviewcustomer
        '
        Me.cmdviewcustomer.AutoSize = True
        Me.cmdviewcustomer.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdviewcustomer.Location = New System.Drawing.Point(30, 185)
        Me.cmdviewcustomer.Name = "cmdviewcustomer"
        Me.cmdviewcustomer.Size = New System.Drawing.Size(129, 23)
        Me.cmdviewcustomer.TabIndex = 8
        Me.cmdviewcustomer.Text = "View Customer"
        Me.cmdviewcustomer.UseVisualStyleBackColor = True
        '
        'cmdviewroles
        '
        Me.cmdviewroles.AutoSize = True
        Me.cmdviewroles.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdviewroles.Location = New System.Drawing.Point(30, 161)
        Me.cmdviewroles.Name = "cmdviewroles"
        Me.cmdviewroles.Size = New System.Drawing.Size(103, 23)
        Me.cmdviewroles.TabIndex = 7
        Me.cmdviewroles.Text = "View Roles"
        Me.cmdviewroles.UseVisualStyleBackColor = True
        '
        'cmdupdatesystemusers
        '
        Me.cmdupdatesystemusers.AutoSize = True
        Me.cmdupdatesystemusers.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdupdatesystemusers.Location = New System.Drawing.Point(30, 138)
        Me.cmdupdatesystemusers.Name = "cmdupdatesystemusers"
        Me.cmdupdatesystemusers.Size = New System.Drawing.Size(172, 23)
        Me.cmdupdatesystemusers.TabIndex = 6
        Me.cmdupdatesystemusers.Text = "Update System Users"
        Me.cmdupdatesystemusers.UseVisualStyleBackColor = True
        '
        'richtexxt
        '
        Me.richtexxt.Location = New System.Drawing.Point(246, 46)
        Me.richtexxt.Name = "richtexxt"
        Me.richtexxt.Size = New System.Drawing.Size(532, 441)
        Me.richtexxt.TabIndex = 5
        Me.richtexxt.Text = ""
        '
        'cmddeletesystemusers
        '
        Me.cmddeletesystemusers.AutoSize = True
        Me.cmddeletesystemusers.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddeletesystemusers.Location = New System.Drawing.Point(30, 115)
        Me.cmddeletesystemusers.Name = "cmddeletesystemusers"
        Me.cmddeletesystemusers.Size = New System.Drawing.Size(169, 23)
        Me.cmddeletesystemusers.TabIndex = 3
        Me.cmddeletesystemusers.Text = "Delete System Users"
        Me.cmddeletesystemusers.UseVisualStyleBackColor = True
        '
        'cmdaddsystemusers
        '
        Me.cmdaddsystemusers.AutoSize = True
        Me.cmdaddsystemusers.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdaddsystemusers.Location = New System.Drawing.Point(30, 92)
        Me.cmdaddsystemusers.Name = "cmdaddsystemusers"
        Me.cmdaddsystemusers.Size = New System.Drawing.Size(151, 23)
        Me.cmdaddsystemusers.TabIndex = 2
        Me.cmdaddsystemusers.Text = "Add System Users"
        Me.cmdaddsystemusers.UseVisualStyleBackColor = True
        '
        'cmdviewsystemusers
        '
        Me.cmdviewsystemusers.AutoSize = True
        Me.cmdviewsystemusers.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdviewsystemusers.Location = New System.Drawing.Point(30, 69)
        Me.cmdviewsystemusers.Name = "cmdviewsystemusers"
        Me.cmdviewsystemusers.Size = New System.Drawing.Size(156, 23)
        Me.cmdviewsystemusers.TabIndex = 1
        Me.cmdviewsystemusers.Text = "View System Users"
        Me.cmdviewsystemusers.UseVisualStyleBackColor = True
        '
        'cmdmaketransaction
        '
        Me.cmdmaketransaction.AutoSize = True
        Me.cmdmaketransaction.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmaketransaction.Location = New System.Drawing.Point(30, 46)
        Me.cmdmaketransaction.Name = "cmdmaketransaction"
        Me.cmdmaketransaction.Size = New System.Drawing.Size(151, 23)
        Me.cmdmaketransaction.TabIndex = 0
        Me.cmdmaketransaction.Text = "Make Transaction"
        Me.cmdmaketransaction.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.GridColor = System.Drawing.Color.Black
        Me.DataGridView2.Location = New System.Drawing.Point(5, 3)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(241, 580)
        Me.DataGridView2.TabIndex = 104
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(253, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(842, 579)
        Me.Panel3.TabIndex = 106
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.CPRSS_v1._0.My.Resources.Resources.Close_Box_Red
        Me.PictureBox2.Location = New System.Drawing.Point(1083, 1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 15)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        '
        'Roles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1114, 625)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Roles"
        Me.Text = "Roles"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmddeletesystemusers As System.Windows.Forms.CheckBox
    Friend WithEvents cmdaddsystemusers As System.Windows.Forms.CheckBox
    Friend WithEvents cmdviewsystemusers As System.Windows.Forms.CheckBox
    Friend WithEvents cmdmaketransaction As System.Windows.Forms.CheckBox
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents richtexxt As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdviewroles As System.Windows.Forms.CheckBox
    Friend WithEvents cmdupdatesystemusers As System.Windows.Forms.CheckBox
    Friend WithEvents cmdviewrecords As System.Windows.Forms.CheckBox
    Friend WithEvents cmdupdatesupplier As System.Windows.Forms.CheckBox
    Friend WithEvents cmddeletesupplier As System.Windows.Forms.CheckBox
    Friend WithEvents cmdaddsupplier As System.Windows.Forms.CheckBox
    Friend WithEvents cmdviewsupplier As System.Windows.Forms.CheckBox
    Friend WithEvents cmdupdateinventory As System.Windows.Forms.CheckBox
    Friend WithEvents cmddeleteproduct As System.Windows.Forms.CheckBox
    Friend WithEvents cmdaddproduct As System.Windows.Forms.CheckBox
    Friend WithEvents cmdviewinventory As System.Windows.Forms.CheckBox
    Friend WithEvents cmdupdatecustomer As System.Windows.Forms.CheckBox
    Friend WithEvents cmddeletecustomer As System.Windows.Forms.CheckBox
    Friend WithEvents cmdaddcustomer As System.Windows.Forms.CheckBox
    Friend WithEvents cmdviewcustomer As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cmadd As System.Windows.Forms.Button
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdaddroles As System.Windows.Forms.Button
    Friend WithEvents txtroledes As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
