Public Class MainForm
    Public cs As String = My.Settings.consetting
    Private Sub cmdlogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlogout.Click
        Me.Close()
        Login.txtuname.Clear()
        Login.txtpass.Clear()
        Login.Show()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        Dim Systemusers_mysqlcon As Systemusers_mysqlcon = New Systemusers_mysqlcon(cs)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay.ToShortTimeString
        lbldate.Text = Date.Today.ToLongDateString
    End Sub

    Private Sub cmdtransact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtransact.Click
        pindottransact()
    End Sub

    Private Sub cmdcustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcustomer.Click
        pindotcustomer()
    End Sub

    Private Sub cmdproduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdproduct.Click
        pindotproducts()
    End Sub

    Private Sub cmdsuppliers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdsuppliers.Click
        pindotsupplier()
    End Sub

    Private Sub cmdrecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrecords.Click
        viewrecord_report()
    End Sub

    Private Sub cmdusers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdusers.Click
        pindotusers()
    End Sub
End Class
