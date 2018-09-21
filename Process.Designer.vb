<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Process
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdcalculate = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmdprocess = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtchangeamount = New System.Windows.Forms.TextBox()
        Me.txtcashpayment = New System.Windows.Forms.TextBox()
        Me.txttotalamount = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.cmdcalculate)
        Me.Panel1.Controls.Add(Me.cmdcancel)
        Me.Panel1.Controls.Add(Me.cmdprocess)
        Me.Panel1.Location = New System.Drawing.Point(-7, 130)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(424, 38)
        Me.Panel1.TabIndex = 114
        '
        'cmdcalculate
        '
        Me.cmdcalculate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcalculate.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcalculate.Location = New System.Drawing.Point(211, 3)
        Me.cmdcalculate.Name = "cmdcalculate"
        Me.cmdcalculate.Size = New System.Drawing.Size(99, 30)
        Me.cmdcalculate.TabIndex = 101
        Me.cmdcalculate.Text = "Calculate"
        Me.cmdcalculate.UseVisualStyleBackColor = True
        '
        'cmdcancel
        '
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.Location = New System.Drawing.Point(311, 3)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(98, 30)
        Me.cmdcancel.TabIndex = 100
        Me.cmdcancel.Text = "Cancel"
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'cmdprocess
        '
        Me.cmdprocess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdprocess.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdprocess.Location = New System.Drawing.Point(212, 3)
        Me.cmdprocess.Name = "cmdprocess"
        Me.cmdprocess.Size = New System.Drawing.Size(98, 30)
        Me.cmdprocess.TabIndex = 99
        Me.cmdprocess.Text = "Purchase"
        Me.cmdprocess.UseVisualStyleBackColor = True
        Me.cmdprocess.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 23)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Change (Php)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(5, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 23)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Amount (Php)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 23)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Cash (Php) "
        '
        'txtchangeamount
        '
        Me.txtchangeamount.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtchangeamount.Location = New System.Drawing.Point(135, 85)
        Me.txtchangeamount.Name = "txtchangeamount"
        Me.txtchangeamount.ReadOnly = True
        Me.txtchangeamount.Size = New System.Drawing.Size(267, 32)
        Me.txtchangeamount.TabIndex = 110
        '
        'txtcashpayment
        '
        Me.txtcashpayment.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcashpayment.Location = New System.Drawing.Point(135, 9)
        Me.txtcashpayment.Name = "txtcashpayment"
        Me.txtcashpayment.Size = New System.Drawing.Size(267, 32)
        Me.txtcashpayment.TabIndex = 109
        '
        'txttotalamount
        '
        Me.txttotalamount.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalamount.Location = New System.Drawing.Point(135, 47)
        Me.txttotalamount.Name = "txttotalamount"
        Me.txttotalamount.ReadOnly = True
        Me.txttotalamount.Size = New System.Drawing.Size(267, 32)
        Me.txttotalamount.TabIndex = 108
        '
        'Process
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 168)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtchangeamount)
        Me.Controls.Add(Me.txtcashpayment)
        Me.Controls.Add(Me.txttotalamount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Process"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Process"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdcalculate As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdprocess As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtchangeamount As System.Windows.Forms.TextBox
    Friend WithEvents txtcashpayment As System.Windows.Forms.TextBox
    Friend WithEvents txttotalamount As System.Windows.Forms.TextBox
End Class
