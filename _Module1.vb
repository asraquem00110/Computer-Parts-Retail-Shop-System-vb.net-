Module _Module1

    Public Sub pindottransact()
        Purchase.Hide()
        Purchase.MdiParent = MainForm
        Purchase.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Purchase.Location = New Point(x + 230, y + 0)
    End Sub


    Public Sub pindotcustomer()
        Customer_Details.Hide()
        Customer_Details.MdiParent = MainForm
        Customer_Details.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Customer_Details.Location = New Point(x + 230, y + 0)
    End Sub

    Public Sub pindotproducts()
        products.Hide()
        products.MdiParent = MainForm
        products.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        products.Location = New Point(x + 230, y + 0)
        If MainForm.cmdproduct.Text = "&Products" Then
            products.MenuStrip1.Visible = True
        Else
            products.MenuStrip1.Visible = False
        End If
    End Sub

    Public Sub pindotsupplier()
        Suppliers.Hide()
        Suppliers.MdiParent = MainForm
        Suppliers.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Suppliers.Location = New Point(x + 230, y + 0)
    End Sub



    Public Sub pindotusers()
        users.Hide()
        users.MdiParent = MainForm
        users.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        users.Location = New Point(x + 230, y + 0)
    End Sub


    Public Sub viewreport()
        Reports.Hide()
        Reports.MdiParent = MainForm
        Reports.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Reports.Location = New Point(x + 230, y + 0)
    End Sub


    Public Sub viewrecord_report()
        Records_Reports.Hide()
        Records_Reports.MdiParent = MainForm
        Records_Reports.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Records_Reports.Location = New Point(x + 230, y + 0)
    End Sub

    Public Sub viewrecords()
        Records.Hide()
        Records.MdiParent = MainForm
        Records.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Records.Location = New Point(x + 230, y + 0)
    End Sub


    Public Sub viewtemptables()
        TempForm.Close()
        TempForm.MdiParent = MainForm
        TempForm.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        TempForm.Location = New Point(x + 230, y + 0)
    End Sub

    Public Sub pindotstocksin()
        Stocksin.Hide()
        Stocksin.MdiParent = MainForm
        Stocksin.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Stocksin.Location = New Point(x + 230, y + 0)
    End Sub


    Public Sub pindotroles()
        Roles.Hide()
        Roles.MdiParent = MainForm
        Roles.Show()
        Dim x, y As Integer
        x = MainForm.Panel2.Location.X
        y = MainForm.Panel2.Location.Y
        Roles.Location = New Point(x + 230, y + 0)
    End Sub
End Module
