Imports MySql.Data.MySqlClient
Public Class TempForm
    Dim con As New MySqlConnection
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim cs As String = MainForm.cs


    Private Sub cmbtemptbl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtemptbl.SelectedIndexChanged

        cmdcreate.Enabled = True

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Public Function getcsvfilepathname() As String
        Dim filename As String
        OpenFileDialog1.Filter = "CSV Files | *.csv"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            filename = OpenFileDialog1.FileName
        End If
        Return filename
    End Function


    Private Sub cmdopenfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdopenfile.Click
        Dim filenamepath As String = getcsvfilepathname()
        txtfilename.Text = filenamepath
    End Sub

    Private Sub cmdcreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcreate.Click
            createtemptable()
        insertcsvintotemptable()
        viewtemptable()
    End Sub

    'para sa supplier na option
    Sub createtemptable()
        con.ConnectionString = cs
        If cmbtemptbl.Text = "Supplier" Then
            cmd.CommandText = "create temporary table IF NOT EXISTS `cprss`.`tempsupplier`( " & _
                              "suppid INT NOT NULL AUTO_INCREMENT, " & _
                              "descrip VARCHAR(100),Add1 VARCHAR(100),Phone VARCHAR(100),PRIMARY KEY(suppid)); "
        ElseIf cmbtemptbl.Text = "Customer" Then
            cmd.CommandText = "create temporary table IF NOT EXISTS `cprss`.`tempcustomer`( " & _
                             "customid INT NOT NULL AUTO_INCREMENT, " & _
                             "lastn VARCHAR(100),firstn VARCHAR(100),phonenum VARCHAR(100),add1 VARCHAR(100),PRIMARY KEY(customid)); "
        End If
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            'MsgBox("Successfully inserted to temporary table")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Sub insertcsvintotemptable()
        con.ConnectionString = cs
        Dim temptable As String
        If cmbtemptbl.Text = "Supplier" Then
            temptable = "tempsupplier"
        ElseIf cmbtemptbl.Text = "Customer" Then
            temptable = "tempcustomer"
        End If
        cmd.CommandText = "LOAD DATA INFILE @path " & _
                          "INTO TABLE " & temptable & " " & _
                          "FIELDS TERMINATED BY ',' " & _
                          "ENCLOSED BY '""' " & _
                          "LINES TERMINATED BY '\n' " & _
                          "IGNORE 1 ROWS; "
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@path", txtfilename.Text)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Successfully inserted to temporary table")
            cmd.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Sub viewtemptable()
        Dim temptable As String
        Dim tbl As New DataTable
        tbl.Clear()
        con.ConnectionString = cs
        If cmbtemptbl.Text = "Supplier" Then
            temptable = "tempsupplier"
        ElseIf cmbtemptbl.Text = "Customer" Then
            temptable = "tempcustomer"
        End If
        cmd.CommandText = "SELECT * FROM " & temptable & ""
        cmd.Connection = con
        Try
            con.Open()
            da.SelectCommand = cmd
            da.Fill(tbl)
            DataGridView2.DataSource = tbl

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Sub insertintoactualtable()
        con.ConnectionString = cs
        If cmbtemptbl.Text = "Supplier" Then
            cmd.CommandText = "INSERT INTO suppliers (supplier_id,Description,Address,Phoneno) " & _
                              "SELECT suppid,descrip,Add1,Phone FROM tempsupplier "
        ElseIf cmbtemptbl.Text = "Customer" Then
            cmd.CommandText = "INSERT INTO customers (customer_id,lname,fname,address,phonenumber) " & _
                           "SELECT customid,lastn,firstn,add1,phonenum FROM tempcustomer "
        End If
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Informations are permanently added to database")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try
    End Sub


    'dito sinasave na permanently sa actual table ung laman ni temporary table
    Private Sub cmdsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsave.Click

        insertintoactualtable()

    End Sub

    Private Sub panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panel4.Paint

    End Sub
End Class