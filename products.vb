Public Class products
    Dim Productinventory As Productinventory = New Productinventory(MainForm.cs)

    Dim id As Integer
    Dim description As String
    Dim category As String
    Dim cp As Decimal
    Dim warranty As String
    Dim brand As String

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub




    Private Sub products_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Productinventory.viewproducts()
        Productinventory.lagaylahatngproduct()

    End Sub


    Private Sub cmdupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupdate.Click


        Try
            Dim des As String = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
            Dim tanong = MessageBox.Show("Are you sure you want to update " & des & " ?", "System Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If tanong = DialogResult.Yes Then
                id = (txtid.Text)
                description = txtdescription.Text
                category = cmbcategory.Text
                brand = txtbrand.Text
                Try
                    cp = CDec(txtprice.Text)
                    Productinventory.updateproducts(description, category, brand, cp, id)
                Catch ex As Exception
                    MsgBox("Invalid input of Price")
                    txtprice.Focus()
                    txtprice.Clear()
                End Try
            End If
        Catch ex As Exception
            MsgBox("No Information/s on datagrid")
        End Try

        Productinventory.viewproducts()
    End Sub

    Sub kuhadetails()
        Try
            txtid.Text = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
            txtdescription.Text = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
            txtbrand.Text = DataGridView2(4, DataGridView2.CurrentRow.Index).Value.ToString
            cmbcategory.Text = DataGridView2(5, DataGridView2.CurrentRow.Index).Value.ToString
            txtprice.Text = DataGridView2(2, DataGridView2.CurrentRow.Index).Value.ToString
            txtstocks.Text = DataGridView2(3, DataGridView2.CurrentRow.Index).Value.ToString

        Catch ex As Exception
            MsgBox("No Information/s on datagrid")
        End Try

    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        kuhadetails()
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim itemngalan As String = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
        Dim tanong As String = MessageBox.Show("Are you sure you want to delete item " & itemngalan & " ?", "System Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If tanong = DialogResult.Yes Then
            Try
                Dim id As Integer = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
                Productinventory.deleteproducts(id)
                Productinventory.viewproducts()
            Catch ex As Exception
                MsgBox("No Information/s on datagrid")
            End Try

        End If
    End Sub




    Private Sub cmbcategory_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbcategory.MouseClick
        cmbcategory.Items.Clear()
        Productinventory.kuhacategoryname()
    End Sub


    Private Sub CATEGORYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYToolStripMenuItem.Click
        Categories.Hide()
        Categories.MdiParent = MainForm
        Categories.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Categories.Location = New Point(x + 550, y + 60)
        Categories.TopMost = True
    End Sub

    Private Sub STOCKSINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKSINToolStripMenuItem.Click
        openstocksin()
    End Sub

    Sub openstocksin()

        Try
            Stocksin.txtid.Text = DataGridView2(0, DataGridView2.CurrentRow.Index).Value.ToString
            Stocksin.txtdescription.Text = DataGridView2(1, DataGridView2.CurrentRow.Index).Value.ToString
            pindotstocksin()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub


    Private Sub cmdshowadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowadd.Click
        txtid.Visible = False
        Label1.Visible = False
        GroupBox1.Visible = True
        cmdadd.Visible = True
        cmdupdate.Visible = False
    End Sub

    Private Sub cmddetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddetails.Click
        Label1.Visible = True
        txtid.Visible = True
        GroupBox1.Visible = True
        cmdadd.Visible = False
        cmdupdate.Visible = True
        kuhadetails()
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        If txtdescription.Text.Trim = "" Then
            MsgBox("Please input Product Description")
            txtdescription.Focus()
        ElseIf txtprice.Text.Trim = "" Then
            MsgBox("Please input Product Price")
            txtprice.Focus()
        ElseIf Productinventory.checkduplicates(txtdescription.Text) = True Then
            MsgBox("Already Existed")
        Else
            description = txtdescription.Text
            category = cmbcategory.Text
            brand = txtbrand.Text
            Try
                cp = CDec(txtprice.Text)
                Productinventory.insertproducts(description, category, brand, cp)
                openstocksin()
                Dim des As String
                Stocksin.txtid.Text = Productinventory.kuhalastinsertedproductid(des)
                Stocksin.txtdescription.Text = des
                GroupBox1.Visible = False
                clearinputs()
            Catch ex As Exception
                MsgBox("Invalid input of Price")
                txtprice.Focus()
                txtprice.Clear()
            End Try


            Productinventory.viewproducts()
        End If
      
    End Sub

    Public Sub clearinputs()
        txtid.Clear()
        txtdescription.Clear()
        txtbrand.Clear()
        cmbcategory.Text = ""
        txtprice.Clear()
        txtstocks.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GroupBox1.Visible = False
    End Sub

    Private Sub txtproductsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtproductsearch.TextChanged
        Productinventory.searchproduct(txtproductsearch.Text)
    End Sub

    Private Sub txtdescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdescription.TextChanged
        destrappings()
    End Sub

    Private Sub txtbrand_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbrand.TextChanged
        brandtrappings()
    End Sub

    Private Sub txtprice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprice.TextChanged
        pricetrappings()
    End Sub

    Private Sub destrappings()
        Dim des As String

        des = txtdescription.Text
        If txtdescription.Text = " " Then
            txtdescription.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istext(txtdescription.Text) = False Then

            txtdescription.Text = Mid(txtdescription.Text, 1, Len(txtdescription.Text) - 1)
            txtdescription.SelectionStart = txtdescription.Text.Length + 1
        ElseIf (des.Contains("  ")) Then
            'prevent double space sa pag tytype
            des = des.Replace("  ", " ")
            txtdescription.Text = des
            txtdescription.SelectionStart = txtdescription.Text.Length + 1
        End If

    End Sub

    Private Sub brandtrappings()
        Dim brand As String

        brand = txtbrand.Text
        If txtbrand.Text = " " Then
            txtbrand.Text = ""
            Exit Sub
            'trap special character with funtion isValid()
        ElseIf istext(txtbrand.Text) = False Then

            txtbrand.Text = Mid(txtbrand.Text, 1, Len(txtbrand.Text) - 1)
            txtbrand.SelectionStart = txtbrand.Text.Length + 1
        ElseIf (brand.Contains("  ")) Then
            'prevent double space sa pag tytype
            brand = brand.Replace("  ", " ")
            txtbrand.Text = brand
            txtbrand.SelectionStart = txtbrand.Text.Length + 1
        End If

    End Sub
    Private Sub pricetrappings()
        Dim dec As String
        dec = txtprice.Text
        If isdec(txtprice.Text) = False Then
            txtprice.Text = Mid(txtprice.Text, 1, Len(txtprice.Text) - 1)
            txtprice.SelectionStart = txtprice.Text.Length + 1
        End If
    End Sub

    Private Function isdec(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[.0-9]*$")
    End Function
    Private Function istext(ByVal value As String)
        Return System.Text.RegularExpressions.Regex.IsMatch(value, "^[- #,.;'a-zA-Z0-9]*$")
    End Function
End Class