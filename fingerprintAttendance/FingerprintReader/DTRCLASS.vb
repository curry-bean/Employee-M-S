Public Class DTRCLASS
    Dim mDataPath As String
    Public Shared DataModule As DTRCLASS


    Private Function GetConnection() As OleDb.OleDbConnection

        Return New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath() & "\GrFingerSample.mdb")

    End Function
    Public Sub New(ByVal sDatapath As String)

        MyBase.new()
        Me.mDataPath = sDatapath
        DTRCLASS.DataModule = Me

    End Sub

    Sub clear()
        frmMain.txtid.Text = ""
        ' frmMain.txtpin.Text = ""
        frmMain.txtfirst.Text = ""
        frmMain.txtlast.Text = ""
        frmMain.txtmi.Text = ""
        frmMain.cbogen.Text = ""
        frmMain.txtpos.Text = ""
        frmMain.txtinput.Text = ""
        newuser.txtname.Text = ""
        newuser.txtpassw.Text = ""
        newuser.txtretyp.Text = ""
        newuser.txtusername.Text = ""
        newuser.cborole.Text = ""
        newuser.txtfirst.Text = ""
        newuser.txtlast.Text = ""
        newuser.txtmi.Text = ""


    End Sub

    Public Overloads Function dataLoad() As DataSet
        Return Me.dataLoad("mem_code")
    End Function

    Public Overloads Function dataLoad(ByVal sortfield As String) As DataSet

        Dim conn As OleDb.OleDbConnection = GetConnection()
        Dim ds As New DataSet

        Try
            Dim sql As String = "Select MEM_CODE, fname, mname, lname, COURSE_POSITION, GENDER from enroll"
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql, conn)

            Try
                Dim dt As New DataTable("GrFingerSample")
                da.Fill(dt)

                student_info.DataGridView1.DataSource = dt

            Finally
                da.Dispose()
            End Try

            Return ds
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function
    Public Overloads Function dataLoad1(ByVal sortfield As String) As DataSet

        Dim conn As OleDb.OleDbConnection = GetConnection()
        Dim ds As New DataSet

        Try
            Dim sql As String = "Select * from DTR_REC where SDATE LIKE '" & frmMain.LBLDATE.Text & "'"
            '
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(Sql, conn)

            Try
                Dim dt As New DataTable("GrFingerSample")
                da.Fill(dt)

                frmViewLogin.DataGridView1.DataSource = dt

            Finally
                da.Dispose()
            End Try

            Return ds
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function
    Public Overloads Function SaveMEM() As DataSet
        Return Me.SaveMEM("MEM_CODE")
    End Function
    Public Overloads Function SaveMEM(ByVal sortfield As String) As DataSet
        Dim a As String
        Dim b As String
        b = frmMain.LBLTIME.Text & " " & frmMain.LBLDATE.Text

        a = frmMain.txtlast.Text & ", " & frmMain.txtfirst.Text & " " & frmMain.txtmi.Text & "."

        Dim conn As OleDb.OleDbConnection = GetConnection()
        Dim SQL As String

        Try
            SQL = "INSERT INTO MEMBERS_PROF ( MEM_CODE, LOG_ID, NAME, COURSE_POSITION,GENDER," & _
            "ENCODER, DATE_ENCODED )VALUES ( @MEM_CODE, @LOG_ID, @NAME, @COURSE_POSITION,@GENDER,@ENCODER, @DATE_ENCODED);"


            Dim cmd As New OleDb.OleDbCommand(SQL, conn)
            cmd.Parameters.Add(New OleDb.OleDbParameter("@MEM_CODE", frmMain.txtid.Text))
            '   cmd.Parameters.Add(New OleDb.OleDbParameter("@LOG_ID", frmMain.txtpin.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@NAME", a))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@COURSE_POSITION", frmMain.txtpos.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@GENDER", frmMain.cbogen.SelectedItem))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@ENCODER", frmMain.toolguest.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter(" @DATE_ENCODED", b))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@lname", frmMain.txtlast.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@mname", frmMain.txtmi.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@fname", frmMain.txtfirst.Text))
            conn.Open()
            cmd.ExecuteNonQuery()

            MessageBox.Show("New Member is added!")
            clear()
            'RefreshDGV()


        Catch ex As Exception

            MsgBox("Error in connection!ID or PIN already exist!")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function

    Public Overloads Function logins() As DataSet
        Return Me.logins("username")

    End Function
    Public Overloads Function logins(ByVal sortfield As String) As DataSet
        Dim conn As OleDb.OleDbConnection = GetConnection()
        Dim SQL As String
        Dim da As OleDb.OleDbDataAdapter
        Dim ds As New DataSet


        Dim a As String = frmMain.txtuser.Text
        Dim b As String = frmMain.txtpass.Text
        Dim c As Integer
        Dim d As String

        SQL = "SELECT myUsername, myPassword,Fullname, name, role FROM users_table where myusername='" & a & "' and myPassword ='" & b & "' "

        da = New OleDb.OleDbDataAdapter(SQL, conn)
        da.Fill(ds, "GrFingerSample")

        c = ds.Tables("GrFingerSample").Rows.Count

        '   Try
        If c > 0 Then
            '
            d = ds.Tables("GrFingerSample").Rows(0).Item(4)
            MsgBox("Welcome you log on as " & d)
            If d = "ENCODER" Then
                frmMain.GroupBox4.Hide()
                frmMain.Toologin.Text = "Log out"
                frmMain.toolguest.Text = ds.Tables("GrFingerSample").Rows(0).Item(3)
                frmMain.toolmain.Visible = True
                frmMain.AddNewUserToolStripMenuItem.Visible = False
                frmMain.toolguest.Visible = True
                frmMain.toolhi.Visible = True
            Else

                frmMain.GroupBox4.Hide()
                frmMain.toolmain.Visible = True

                frmMain.Toologin.Text = "Log out"
                frmMain.toolguest.Text = ds.Tables("GrFingerSample").Rows(0).Item(3)
                frmMain.toolguest.Visible = True
                frmMain.toolhi.Visible = True

            End If


        Else
            MsgBox("Wrong Username or Password")
        End If

        '  Catch ex As Exception
        '
        '    MsgBox("Error in connection!")
        '   End Try

        Return ds

    End Function

    Public Overloads Function newus() As DataSet
        Return Me.newus("username")
    End Function
    Public Overloads Function newus(ByVal sortfield As String) As DataSet

        Dim conn As OleDb.OleDbConnection = GetConnection()
        conn.Open()
        Dim SQL As String
        ' Dim ds As DataSet
        Dim us As String

        us = newuser.txtlast.Text & ", " & newuser.txtfirst.Text & " " & newuser.txtmi.Text & "." & ""
        Try
            SQL = "INSERT INTO users_table (myusername, mypassword, Rpassword,Fullname, Name, role )" & _
            "VALUES (@myusername,@mypassword,@Rpassword,@Fullname,@Name,@role)"

            Dim cmd As New OleDb.OleDbCommand(SQL, conn)
            cmd.Parameters.Add(New OleDb.OleDbParameter("@myusername", newuser.txtusername.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@mypassword", newuser.txtpassw.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@Rpassword", newuser.txtretyp.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@Fullname", us))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@Name", newuser.txtname.Text))
            cmd.Parameters.Add(New OleDb.OleDbParameter("@Role", newuser.cborole.SelectedItem))



            cmd.ExecuteNonQuery()

            MessageBox.Show("New user is added!")
            clear()

        Catch ex As Exception
            MsgBox("Error in connection! Name is already exist!")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function

    Public Overloads Function AM() As DataSet
        Return Me.AM("FIRST_AM_REMARKS")

    End Function
    Public Overloads Function AM(ByVal SORTFIELD As String) As DataSet
        Dim conn As OleDb.OleDbConnection = GetConnection()
        Dim sql As String
        Dim sql1 As String
        Dim A As Integer

        Dim amlate As String = "7:30:01 AM"
        Dim remm As String

        If frmMain.LBLTIME.Text >= amlate Then
            remm = "LATE"
        Else
            remm = "ON TIME"
        End If


        Try

            sql1 = "SELECT * FROM DTR_REC WHERE MEM_CODES LIKE '" & frmMain.txtid.Text & "' AND SDATE LIKE '" & frmMain.LBLDATE.Text & "'"
            Dim DA As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql1, conn)
            Dim DS As New DataSet
            DA.Fill(DS, "GrFingerSample")
            A = DS.Tables("GrFingerSample").Rows.Count
            If A > 0 Then

                MessageBox.Show("Sorry you Already finished Log in!")

            Else
                sql = "INSERT INTO DTR_REC (MEM_CODES, AM_IN, FIRST_AM_REMARK, SDATE) VALUES (@MEM_CODES, @AM_IN, @FIRST_AM_REMARK, @SDATE)"
                Dim cmd As New OleDb.OleDbCommand(sql, conn)
                cmd.Parameters.Add(New OleDb.OleDbParameter("@MEM_CODES", frmMain.txtid.Text))
                cmd.Parameters.Add(New OleDb.OleDbParameter(" @AM_IN", frmMain.LBLTIME.Text))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@FIRST_AM_REMARK", remm))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@SDATE", frmMain.LBLDATE.Text))

                conn.Open()
                cmd.ExecuteNonQuery()
                If remm = "LATE" Then
                    MessageBox.Show("LATE")
                ElseIf remm = "ON TIME" Then
                    MessageBox.Show("ON TIME")
                End If
            End If

            clear()


        Catch ex As Exception
            Dim dgresult As DialogResult
            Dim ms As String
            ms = "Contact your Administrator! Maybe your not registered."
            MessageBox.Show(ms, "Error in connection", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)

            If dgresult = DialogResult.Yes Then
                frmMain.Show()
            End If

        End Try

    End Function

    Public Overloads Function AMOUT() As DataSet
        Return Me.AMOUT("FIRST_AM_REMARKS")
    End Function
    Public Overloads Function AMOUT(ByVal SORTFEILD As String) As DataSet

        Dim conn As OleDb.OleDbConnection = GetConnection()
        Dim sql As String
        Dim am_OUT As String = "11:30:01 AM"
        Dim remm As String

        If frmMain.LBLTIME.Text >= am_OUT Then
            remm = "OVERTIME"
        Else
            remm = "PRESENT"
        End If

        sql = "UPDATE DTR_REC SET  AM_OUT=@AM_OUT, SEC_AM_REMARK=@SESC_AM_REMARK " & _
              "WHERE MEM_CODES= '" & frmMain.txtid.Text & "'AND SDATE LIKE  '" & frmMain.LBLDATE.Text & "'and AM_OUT is null"

        Try
            Dim sql1 As String
            Dim A As Integer
            sql1 = "SELECT * FROM DTR_REC WHERE MEM_CODES LIKE '" & frmMain.txtid.Text & "' AND SDATE LIKE '" & frmMain.LBLDATE.Text & "'AND AM_OUT IS NOT NULL"
            Dim DA As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql1, conn)
            Dim DS As New DataSet
            DA.Fill(DS, "GrFingerSample")
            A = DS.Tables("GrFingerSample").Rows.Count
            If A > 0 Then

                MessageBox.Show("Sorry you Already finished Log out!")


            Else
                Dim cmd As New OleDb.OleDbCommand(sql, conn)
                cmd.Parameters.Add(New OleDb.OleDbParameter("@AM_OUT", frmMain.LBLTIME.Text))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@SESC_AM_REMARK", remm))

                conn.Open()
                cmd.ExecuteNonQuery()

                If remm = "OVERTIME" Then
                    MessageBox.Show("You have little overtime")
                ElseIf remm = "PRESENT" Then
                    MessageBox.Show("Logout")
                End If
            End If


            clear()



        Catch ex As Exception
            Dim dgresult As DialogResult
            Dim ms As String
            ms = "Contact your Administrator! Maybe your not registered."
            MessageBox.Show(ms, "Error in connection", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)

            If dgresult = DialogResult.Yes Then
                frmMain.Show()
            End If
        End Try
    End Function

    Public Overloads Function PMIN() As DataSet
        Return Me.PMIN("FIRST_AM_REMARKS")
    End Function

    Public Overloads Function PMIN(ByVal SORTFIELD As String) As DataSet

        Dim CONN As OleDb.OleDbConnection = GetConnection()
        Dim PMINS As String = "1:30:01 PM"
        Dim REMM As String

        Dim SQL As String
        If frmMain.LBLTIME.Text >= PMINS Then
            REMM = "LATE"
        Else
            REMM = "ON TIME"
        End If
        Try

            Dim sql1 As String
            Dim A As Integer
            sql1 = "SELECT * FROM DTR_REC WHERE MEM_CODES LIKE '" & frmMain.txtid.Text & "' AND SDATE LIKE '" & frmMain.LBLDATE.Text & "' AND PM_IN IS NOT NULL"
            Dim DA As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql1, CONN)
            Dim DS As New DataSet
            DA.Fill(DS, "GrFingerSample")
            A = DS.Tables("GrFingerSample").Rows.Count
            If A > 0 Then

                MessageBox.Show("Sorry you Already finished Log in!")


            Else
                SQL = "UPDATE DTR_REC SET  PM_IN=@PM_IN, FIRST_PM_REMARK=@FIRST_PM_REMARK " & _
                  "WHERE MEM_CODES= '" & frmMain.txtid.Text & "'AND SDATE LIKE  '" & frmMain.LBLDATE.Text & "' AND PM_IN IS NULL"

                Dim cmd As New OleDb.OleDbCommand(SQL, CONN)
                cmd.Parameters.Add(New OleDb.OleDbParameter("@PM_IN", frmMain.LBLTIME.Text))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@FIRST_PM_REMARK", REMM))

                CONN.Open()
                cmd.ExecuteNonQuery()

                If REMM = "ON TIME" Then
                    MessageBox.Show("Very good you come on time!")
                ElseIf REMM = "LATE" Then
                    MessageBox.Show("Hurry your Late")
                End If

            End If
            clear()
        Catch ex As Exception
            Dim dgresult As DialogResult
            Dim ms As String
            ms = "Contact your Administrator! Maybe your not registered."
            MessageBox.Show(ms, "Error in connection", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)

            If dgresult = DialogResult.Yes Then
                frmMain.Show()
            End If
        End Try
    End Function

    Public Overloads Function PMOUT() As DataSet
        Return Me.PMOUT("FIRST_AM_REMARKS")
    End Function

    Public Overloads Function PMOUT(ByVal SORTFIELD As String) As DataSet

        Dim CONN As OleDb.OleDbConnection = GetConnection()
        Dim PMINS As String = "5:30:01 PM"
        Dim REMM As String

        Dim SQL As String
        If frmMain.LBLTIME.Text >= PMINS Then
            REMM = "OVERTIME"
        Else
            REMM = "UNDERTIME"
        End If
        Try
            Dim sql1 As String
            Dim A As Integer
            sql1 = "SELECT * FROM DTR_REC WHERE MEM_CODES LIKE '" & frmMain.txtid.Text & "' AND SDATE LIKE '" & frmMain.LBLDATE.Text & "' AND PM_OUT IS NOT NULL"
            Dim DA As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql1, CONN)
            Dim DS As New DataSet
            DA.Fill(DS, "GrFingerSample")
            A = DS.Tables("GrFingerSample").Rows.Count
            If A > 0 Then

                MessageBox.Show("Sorry you Already finished Log out!")


            Else
                SQL = "UPDATE DTR_REC SET  PM_OUT=@PM_OUT, SEC_PM_REMARK=@SEC_PM_REMARK " & _
                  "WHERE MEM_CODES= '" & frmMain.txtid.Text & "'AND SDATE LIKE  '" & frmMain.LBLDATE.Text & "'"

                Dim cmd As New OleDb.OleDbCommand(SQL, CONN)
                cmd.Parameters.Add(New OleDb.OleDbParameter("@PM_OUT", frmMain.LBLTIME.Text))
                cmd.Parameters.Add(New OleDb.OleDbParameter("@SEC_PM_REMARK", REMM))

                CONN.Open()
                cmd.ExecuteNonQuery()

                If REMM = "OVERTIME" Then
                    MessageBox.Show("You have already little Overtime!")
                ElseIf REMM = "UNDERTIME" Then
                    MessageBox.Show("Your Undertime")
                End If
            End If
            clear()
        Catch ex As Exception
            Dim dgresult As DialogResult
            Dim ms As String
            ms = "Contact your Administrator! Maybe your not registered."
            MessageBox.Show(ms, "Error in connection", MessageBoxButtons.OKCancel, _
                            MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)

            If dgresult = DialogResult.Yes Then
                frmMain.Show()
            End If
        End Try
    End Function

    Public Overloads Function quick() As DataSet
        Return Me.quick("MEM_CODE")
    End Function
    Public Overloads Function quick(ByVal sortfield As String) As DataSet

        Dim conn As OleDb.OleDbConnection = GetConnection()

        Dim sql As String

        sql = "Select MEM_CODE, fname, mname, lname, COURSE_POSITION, GENDER  from enroll WHERE MEM_CODE LIKE '%" & student_info.TextBox1.Text & "%'" & " OR lname LIKE '%" & student_info.TextBox1.Text & "%'"
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(Sql, conn)
        Dim dt As New DataTable("GrFingerSample")
        da.Fill(dt)
        student_info.DataGridView1.DataSource = dt
        Return ds

    End Function

    Public Overloads Function SPEREC() As DataSet
        Return Me.SPEREC("MEM_CODE")
    End Function
    Public Overloads Function SPEREC(ByVal sortfield As String) As DataSet

        Dim conn As OleDb.OleDbConnection = GetConnection()

        Dim sql As String

        sql = "SELECT D.AM_IN AS[AM IN],FIRST_AM_REMARK AS [IN REMARKS]," & _
              "AM_OUT AS [AM OUT], SEC_AM_REMARK AS [OUT REMARKS], PM_IN AS [PM IN]," & _
              "FIRST_PM_REMARK AS [PM IN REMARKS], PM_OUT AS [PM OUT]," & _
              "SEC_PM_REMARK AS [PM OUT REMARKS], SDATE AS [DATES] FROM enroll AS M," & _
              "DTR_REC AS D WHERE M.MEM_CODE LIKE '%" & student_info.DataGridView1.CurrentRow.Cells(0).Value.ToString & "%'"
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql, conn)
        Dim dt As New DataTable("GrFingerSample")
        da.Fill(dt)
        INDIVIDUAL_REC.DataGridView1.DataSource = dt
        Return ds

    End Function

End Class

