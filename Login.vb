Imports System.IO
Imports System.Data

Public Class Login
    Dim Systemusers_mysqlcon As Systemusers_mysqlcon = New Systemusers_mysqlcon(MainForm.cs)
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Systemusers_mysqlcon.checkroles()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Systemusers_mysqlcon.checkroles()
        '   MessageBox.Show(Systemusers_mysqlcon.haha)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        With MainForm
            .Show()
            .cmdtransact.Enabled = False
            .cmdusers.Enabled = False
            .cmdcustomer.Enabled = False
            .cmdsuppliers.Enabled = False
            .cmdrecords.Enabled = False
            .cmdproduct.Text = "Products"
            .cmdproduct.Enabled = True
            .lblid.Text = ""
            .lblrole.Text = "Guest"
        End With

        With products
            .txtdescription.Enabled = False
            .txtbrand.Enabled = False
            .cmbcategory.Enabled = False
            .txtprice.Enabled = False
            .cmdupdate.Enabled = False
            .cmdshowadd.Enabled = False
            .cmddelete.Enabled = False
        End With


        Me.Hide()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  Dim timeNow = DateTime.Now()
        Dim path As String = "c:\cprss\Databasebackup"
        Dim path2 As String = "c:\cprss\eventreports\DailyReport"
        Dim path3 As String = "c:\cprss\eventreports\MonthlyReport"
        If Directory.Exists(path) = False Then
            Directory.CreateDirectory(path)
        End If
        If Directory.Exists(path2) = False Then
            Directory.CreateDirectory(path2)
        End If
        If Directory.Exists(path3) = False Then
            Directory.CreateDirectory(path3)
        End If
    End Sub
End Class