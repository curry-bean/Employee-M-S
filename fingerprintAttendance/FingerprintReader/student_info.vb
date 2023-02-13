Public Class student_info
    Dim ds As New DataSet

    Private Sub student_info_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

#Region "my data"
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Dim sPath As String = Application.ExecutablePath
        sPath = System.IO.Path.GetDirectoryName(sPath)

        If sPath.EndsWith("\bin") Then
            sPath = sPath.Substring(0, Len(sPath) - 4)
        End If

        DTRCLASS.DataModule = New DTRCLASS(sPath)

    End Sub
#End Region

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click

        ds = DTRCLASS.DataModule.dataLoad
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmMain.GroupBox2.Enabled = True
        frmMain.GroupBox2.Visible = True
        frmMain.GroupBox3.Enabled = False

        If frmMain.GroupBox2.Enabled = True Then

            '  frmMain.txtpin.TabIndex = 0
            frmMain.txtid.TabIndex = 1
            frmMain.txtfirst.TabIndex = 2
            frmMain.txtlast.TabIndex = 3
            frmMain.txtmi.TabIndex = 4
            frmMain.cbogen.TabIndex = 5
            frmMain.txtpos.TabIndex = 6
            frmMain.btnsave.TabIndex = 7
            frmMain.btncancel.TabIndex = 8

        End If
        Me.Close()
        frmMain.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim str As String
        Dim strArr() As String
        Dim count As Integer

        frmMain.txtid.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        frmMain.txtlast.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
        str = DataGridView1.CurrentRow.Cells(2).Value.ToString
        strArr = str.Split(" ")
        For count = 0 To strArr.Length - 1
            frmMain.txtlast.Text = strArr(0)
            frmMain.txtfirst.Text = strArr(1)
            frmMain.txtmi.Text = strArr(2)
        Next
        frmMain.txtpos.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
        frmMain.cbogen.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString

        frmMain.GroupBox2.Enabled = True

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        ds = DTRCLASS.DataModule.quick
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ds = DTRCLASS.DataModule.SPEREC
        Me.Close()
        INDIVIDUAL_REC.Show()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub
End Class