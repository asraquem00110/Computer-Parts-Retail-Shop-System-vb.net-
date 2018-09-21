Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Records_Reports
    Dim cs = MainForm.cs
    Dim Customers As Customers = New Customers(MainForm.cs)
    Dim Productinventory As Productinventory = New Productinventory(MainForm.cs)
    Dim SupplierDetails As SupplierDetails = New SupplierDetails(MainForm.cs)
    Dim Transactions As Transactions = New Transactions(MainForm.cs)
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Customers.generatecustomerlistreport()
        viewreport()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Productinventory.generateproductlistreport()
        viewreport()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SupplierDetails.generatesupplierlistreport()
        viewreport()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Customers.generatesystemuserslistreport()
        viewreport()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        viewrecords()
        Transactions.viewrecordtransactions()
    End Sub



   

    'getting filepathname of database
    Public Function restorebackup() As String
        Dim filename As String
        OpenFileDialog1.Filter = "SQL FILE | *.sql"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            filename = OpenFileDialog1.FileName
        End If
        Return filename
    End Function

    'backup database
    Private Sub cmdbackupdatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbackupdatabase.Click
        Dim timeNow = DateTime.Now()
        Dim fileName As String = "cprss_mysql_backup" + timeNow.ToString("MM.dd.yy_H.mm.ss") + ".sql"
        MsgBox(fileName)
        System.Diagnostics.Process.Start("C:\xampp\mysql\bin\mysqldump.exe", "-h 127.0.0.1 -u root -p cprss -r ""c:\cprss\Databasebackup\" & fileName.ToString & """")
    End Sub
    'restore database
    Private Sub cmdrestoredatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrestoredatabase.Click
        Dim filenamepath As String = restorebackup()
        Dim myProcess As New System.Diagnostics.Process()

        myProcess.StartInfo.FileName = "cmd.exe"
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
        myProcess.StartInfo.RedirectStandardInput = True
        myProcess.StartInfo.RedirectStandardOutput = True
        myProcess.Start()

        Dim myStreamWriter As StreamWriter = myProcess.StandardInput
        Dim mystreamreader As StreamReader = myProcess.StandardOutput

        myStreamWriter.WriteLine("mysql -u root -p cprss < " & filenamepath & "")
        myStreamWriter.Close()
        myProcess.WaitForExit()
        myProcess.Close()
    End Sub

    Private Sub cmdtemporarytables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtemporarytables.Click
        viewtemptables()
    End Sub


End Class