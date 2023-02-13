Public Class newuser
    Dim dsUSERS As DataSet

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
        frmMain.Show()
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click

        Dim dgrResult As DialogResult
        Dim strmessage2 As String
        Dim strmessage1 As String
        Dim strmessage3 As String
        strmessage1 = "Please Enter Username"
        strmessage2 = "Are you sure you want to save this user?"
        strmessage3 = "Please check the password"
        
        


        If txtusername.Text = "" Then
            dgrResult = MessageBox.Show(strmessage1, "Confirm", _
                               MessageBoxButtons.OK, MessageBoxIcon.Warning, _
                               MessageBoxDefaultButton.Button2)
        End If
        If txtpassw.Text = txtretyp.Text Then
            dgrResult = MessageBox.Show(strmessage2, "Confirm", _
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
                                 MessageBoxDefaultButton.Button2)
            If dgrResult = Windows.Forms.DialogResult.Yes Then
                dsUSERS = DTRCLASS.DataModule.newus
            End If

        Else
            dgrResult = MessageBox.Show(strmessage3, "Confirm", _
                               MessageBoxButtons.OK, MessageBoxIcon.Warning, _
                               MessageBoxDefaultButton.Button2)

        End If



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
    Private Sub newuser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class