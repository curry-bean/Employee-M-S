Imports GrFingerXLib
Imports System.Data.OleDb
Public Class frmMain
    Dim DSDTR As New DataSet

    Const DBFile = "GrFingerSample.mdb"
    Const Logfile = "C:\Log.csv"
    Const ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Dim ds As New DataSet
    Private myUtil As Util
    Private _UserID As Integer
    Private connection As System.Data.OleDb.OleDbConnection

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'GetUserInfo()
        Call Module1.Connection()
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
        Timer1.Start()
        Timer2.Start()
        toolmain.Visible = False
        toolhi.Visible = False
        toolguest.Visible = False
        GroupBox4.Visible = False
        'GroupBox2.Enabled = False
        LBLTIME.Width = Me.Width
        LBLDATE.Width = Me.Width
        Dim err As Integer
        ' initialize util class
        myUtil = New Util(ListBox1, PictureBox1, AxGrFingerXCtrl1)
        ' Initialize GrFingerX Library
        err = myUtil.InitializeGrFinger()
        ' Print result in log
        If err < 0 Then
            myUtil.WriteError(err)
            Exit Sub
        Else
            myUtil.WriteLog( _
               "**GrFingerX Initialized Successfull**")
        End If

        PictureBox1.Image = ImageList1.Images(0)
        '---create a log file---
        If Not System.IO.File.Exists(Logfile) Then
            System.IO.File.Create(Logfile)
        End If

        If (Me.LBLTIME.Text >= "7:30:01 AM" And Me.LBLTIME.Text <= "12:00:00 AM") Then
            '    'Me.LBLTIME.Text >= "1:00:01 PM" And Me.LBLTIME.Text <= "5:30:00 PM")
            Button1.Enabled = True
            Button2.Enabled = True
            Button4.Enabled = False
            Button5.Enabled = False
        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = True
            Button5.Enabled = True
        End If
    End Sub
#Region "TIMER"
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        LBLDATE.Text = My.Computer.Clock.LocalTime.Date

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBLTIME.Text = TimeOfDay

    End Sub
#End Region






#Region "TOOLSTRIP"

    Private Sub Toologin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toologin.Click

        GroupBox4.Visible = True

        If Toologin.Text = "Log out" Then
            Toologin.Text = "Log in"
            GroupBox2.Enabled = False
            GroupBox3.Enabled = True
            toolhi.Visible = False
            toolguest.Visible = False
            toolmain.Visible = False
            txtuser.Text = ""
            txtpass.Text = ""

        Else
            Toologin.Text = "Log in"


        End If
    End Sub

    Private Sub NewMemberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMemberToolStripMenuItem.Click
        GroupBox2.Enabled = True
        GroupBox3.Enabled = False
        ClearDisplay()
        If GroupBox2.Enabled = True Then

            '    txtpin.TabIndex = 0
            txtid.TabIndex = 1
            txtfirst.TabIndex = 2
            txtlast.TabIndex = 3
            txtmi.TabIndex = 4
            cbogen.TabIndex = 5
            txtpos.TabIndex = 6
            btnsave.TabIndex = 7
            btncancel.TabIndex = 8

        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        student_info.Show()

    End Sub

    Private Sub AddNewUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewUserToolStripMenuItem.Click
        newuser.Show()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim dgrResult As DialogResult
        Dim strmessage2 As String
        Dim strmessage1 As String
        strmessage1 = "Please Log out first before you continue"
        strmessage2 = "Are you sure you want to exit Program?"
        dgrResult = MessageBox.Show(strmessage2, "Confirm", _
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
                                 MessageBoxDefaultButton.Button2)

        If dgrResult = Windows.Forms.DialogResult.Yes Then
            Me.Close()

        End If
    End Sub

#End Region


#Region "COMMAND"
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim dgrResult As DialogResult
        Dim strmessage As String
        Dim strmessage1 As String
        Dim strmessage2 As String
        strmessage1 = "operation Cancelled"
        strmessage2 = "Please provide some data before saving"
        strmessage = "Are you sure you want to save this data?"

        dgrResult = MessageBox.Show(strmessage, "Confirm", _
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                   MessageBoxDefaultButton.Button2)

        If txtid.Text = "" And txtfirst.Text = "" And txtlast.Text = "" Or txtpos.Text = "" Or txtmi.Text = "" Then
            ' If PictureBox1.Image = ImageList1.Images(0) Then
            MessageBox.Show(strmessage2, "", _
                             MessageBoxButtons.OK, MessageBoxIcon.Information, _
                             MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        'Else

        ' End If
        If dgrResult = DialogResult.Yes Then
            '_UserID = EnrollFingerprint()
            '---then add the particulars---
            AddNewUser()

          
            'With cm
            '    '.Parameters.AddWithValue("@id", _UserID)
            '    '.Parameters.AddWithValue("@template", _UserID = EnrollFingerprint())
            '    '.Parameters.AddWithValue("@lname", txtlast.Text)
            '    '.Parameters.AddWithValue("@fname", txtfirst.Text)
            '    '.Parameters.AddWithValue("@mname", txtmi.Text)
            '    '.Parameters.AddWithValue("@MEM_CODE", cbogen.Text)
            '    '.Parameters.AddWithValue("@GENDER", cbogen.Text)
            '    .Parameters.Add(New System.Data.OleDb.OleDbParameter("@Picture", System.Data.OleDb.OleDbType.VarBinary, 2147483647, Me.OpenFileDialog1.FileName))

            '    ' .Parameters.AddWithValue("@COURSE_POSITION", txtpos.Text)

            '    '.Parameters.AddWithValue("@yeargraduated", txtYearGraduate.Text)
            '    '.Parameters.AddWithValue("@address", txtAddress.Text)
            '    '.Parameters.AddWithValue("@Status", cboStatus.Text)

            '    '.Parameters.AddWithValue("@em", txtemail.Text)
            '    '.Parameters.AddWithValue("@work", txtwork.Text)
            '    '.Parameters.AddWithValue("@latestwork", txtlwork.Text)
            '    '.Parameters.AddWithValue("@homeaddress", txthadd.Text)
            '    '.Parameters.AddWithValue("@officeaddress", txtOadd.Text)
            '    '.Parameters.AddWithValue("@businessaddress", txtBadd.Text)
            '    '.Parameters.AddWithValue("@stat", cboStat.Text)
            '    Dim FileStream1 As System.IO.FileStream
            '    Dim FileInfo1 As System.IO.FileInfo

            '    ' READ THE FILE INTO MEMORY
            '    FileInfo1 = New System.IO.FileInfo(OpenFileDialog1.FileName)
            '    FileStream1 = New System.IO.FileStream(OpenFileDialog1.FileName, IO.FileMode.Open)
            '    Dim Array1(CInt(FileInfo1.Length - 1)) As Byte
            '    Debug.WriteLine(FileStream1.Read(Array1, 0, CInt(FileInfo1.Length)))
            '    FileStream1.Close()

            '    Dim String1 As String
            '    Dim ASCIIEncoding1 As New System.Text.ASCIIEncoding()
            '    String1 = ASCIIEncoding1.GetString(Array1)

            '    ' RUN THE COMMAND
            '    cm.Parameters("@Picture").Value = Array1
            '    Dim sql As String = "UPDATE enroll SET [Picture]= '" & Array1.Length & "' WHERE ID=" & _UserID
            '    '  Dim sql As String = "INSERT INTO enroll VALUES(@id,@template,@lname,@fname,@mname,@name,@MEM_CODE,@GENDER,@Picture,@COURSE_POSITION)"
            '    'Dim sql As String = "INSERT INTO tblAlumni VALUES(@sno, @lname,@fname,@mname,@program,@contactno,@gender,@yeargraduated,@address,@status,@Picture,@em,@work,@latestwork,@homeaddress,@officeaddress,@businessaddress,@stat)"
            '    cm = New OleDbCommand(sql, cn)
            '    .ExecuteNonQuery()
            '    MsgBox("Record successfully saved.", vbInformation)







            '---clears the display---
            ClearDisplay()
            WriteToLog(_UserID)
            ' DSDTR = DTRCLASS.DataModule.SaveMEM

            '   End With
        Else

            MessageBox.Show(strmessage1, "", _
                              MessageBoxButtons.OK, MessageBoxIcon.Information, _
                              MessageBoxDefaultButton.Button1)
        End If
    End Sub
    Public Sub AddNewUser()
        Dim filePath As String
        '   Try
        filePath = Application.StartupPath() & "\" & DBFile
        connection = New OleDb.OleDbConnection(ConnectionString & filePath)
        connection.Open()
        Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand
        command.Connection = connection


        Dim a As String
        a = txtlast.Text & ", " & txtfirst.Text & " " & txtmi.Text & "."

        Dim FileStream1 As System.IO.FileStream
        Dim FileInfo1 As System.IO.FileInfo


        '  READ THE FILE INTO MEMORY
        FileInfo1 = New System.IO.FileInfo(OpenFileDialog1.FileName)
        FileStream1 = New System.IO.FileStream(OpenFileDialog1.FileName, IO.FileMode.Open)
        Dim Array3(CInt(FileInfo1.Length - 1)) As Byte
        Debug.WriteLine(FileStream1.Read(Array3, 0, CInt(FileInfo1.Length)))
        FileStream1.Close()

        Dim String1 As String
        Dim ASCIIEncoding1 As New System.Text.ASCIIEncoding()
        String1 = ASCIIEncoding1.GetString(Array3)

        '     command.Parameters.Add(New System.Data.OleDb.OleDbParameter("@Picture", System.Data.OleDb.OleDbType.VarBinary, 2147483647, Me.OpenFileDialog1.FileName))
        '  command.Parameters("@Picture").Value = Array3
        '---set the user's particulars in the table---
        Dim sql As String = "UPDATE enroll SET MEM_CODE= '" & txtid.Text & "', GENDER= '" & cbogen.Text & "', fname= '" & txtfirst.Text & "', lname = '" & txtlast.Text & "',mname ='" & txtmi.Text & "', COURSE_POSITION='" & txtpos.Text & "' , [NAME] ='" & a & "' WHERE ID=" & _UserID

        ' Dim sql As String = "UPDATE enroll SET MEM_CODE= '" & txtpin.Text & "' WHERE ID=" & _UserID


        command.CommandText = sql
        'command.Parameters.Add(New System.Data.OleDb.OleDbParameter("@Picture", System.Data.OleDb.OleDbType.VarBinary, 2147483647, Me.OpenFileDialog1.FileName))
        'command.Parameters("@Picture").Value = Array3

        command.ExecuteNonQuery()
        MsgBox("User added successfully!")
        '  PictureBox3.ImageLocation = ""
        connection.Close()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
    End Sub
    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtid.Text = "" Then
            MessageBox.Show("Pls put first your index finger on the Fingerprint scanner")
        Else
            DSDTR = DTRCLASS.DataModule.AM

        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtid.Text = "" Then
            MessageBox.Show("Pls put first your index finger on the Fingerprint scanner")
        Else
            DSDTR = DTRCLASS.DataModule.AMOUT

        End If

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If txtid.Text = "" Then
            MessageBox.Show("Pls put first your index finger on the Fingerprint scanner")
        Else
            DSDTR = DTRCLASS.DataModule.PMIN

        End If

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If txtid.Text = "" Then
            MessageBox.Show("Pls put first your index finger on the Fingerprint scanner")
        Else
            DSDTR = DTRCLASS.DataModule.PMOUT

        End If

    End Sub
    Private Sub BTNOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNOK.Click
        Dim dgrResult As DialogResult
        Dim strmessage As String
        strmessage = "Please Enter Username"


        If txtuser.Text = "" Then
            dgrResult = MessageBox.Show(strmessage, "", _
                             MessageBoxButtons.OK, MessageBoxIcon.Error, _
                             MessageBoxDefaultButton.Button2)
        Else

            DSDTR = DTRCLASS.DataModule.logins

        End If
    End Sub
#End Region


#Region "NUMBER"


    Private Sub btn0_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click

        txtinput.Text = txtinput.Text & btn0.Text

    End Sub

    Private Sub btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1.Click
        txtinput.Text = txtinput.Text & btn1.Text

    End Sub

    Private Sub btn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn2.Click
        txtinput.Text = txtinput.Text & btn2.Text

    End Sub

    Private Sub btn3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn3.Click
        txtinput.Text = txtinput.Text & btn3.Text

    End Sub

    Private Sub btn4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn4.Click
        txtinput.Text = txtinput.Text & btn4.Text

    End Sub

    Private Sub btn5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn5.Click
        txtinput.Text = txtinput.Text & btn5.Text

    End Sub

    Private Sub btn6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn6.Click
        txtinput.Text = txtinput.Text & btn6.Text

    End Sub

    Private Sub btn7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn7.Click
        txtinput.Text = txtinput.Text & btn7.Text

    End Sub

    Private Sub btn8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn8.Click
        txtinput.Text = txtinput.Text & btn8.Text

    End Sub

    Private Sub btn9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn9.Click
        txtinput.Text = txtinput.Text & btn9.Text

    End Sub

    Private Sub btnback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        Dim str As String
        Dim loc As Integer
        If txtinput.Text.Length > 0 Then
            str = txtinput.Text.Chars(txtinput.Text.Length - 1)
            loc = txtinput.Text.Length
            txtinput.Text = txtinput.Text.Remove(loc - 1, 1)
        End If
    End Sub

#End Region


#Region "TEXTBOX"


    Private Sub txtpin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '  txtpin.BackColor = Color.Lime
    End Sub

    Private Sub txtpin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'txtpin.BackColor = Color.White
    End Sub

    Private Sub txtid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtid.GotFocus
        txtid.BackColor = Color.Lime
    End Sub

    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid.KeyPress
        If e.KeyChar >= "A" And e.KeyChar <= "Z" Or e.KeyChar >= "a" And e.KeyChar <= "z" Then
            e.Handled = True
            MsgBox("Enter Only Number")

        End If
    End Sub

    Private Sub txtid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtid.LostFocus
        txtid.BackColor = Color.White
    End Sub

    Private Sub txtfirst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfirst.GotFocus
        txtfirst.BackColor = Color.Lime
    End Sub

    Private Sub txtfirst_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfirst.LostFocus
        txtfirst.BackColor = Color.White

    End Sub

    Private Sub txtlast_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlast.GotFocus
        txtlast.BackColor = Color.Lime

    End Sub

    Private Sub txtlast_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlast.LostFocus
        txtlast.BackColor = Color.White
    End Sub

    Private Sub txtmi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmi.GotFocus
        txtmi.BackColor = Color.Lime
    End Sub

    Private Sub txtmi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmi.LostFocus
        txtmi.BackColor = Color.White

    End Sub

    Private Sub cbogen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbogen.GotFocus
        cbogen.BackColor = Color.Lime
    End Sub

    Private Sub cbogen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbogen.LostFocus
        cbogen.BackColor = Color.White
    End Sub

    Private Sub txtpos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpos.GotFocus
        txtpos.BackColor = Color.Lime
    End Sub

    Private Sub txtpos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpos.LostFocus
        txtpos.BackColor = Color.White
    End Sub

    Private Sub txtinput_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinput.GotFocus
        txtinput.BackColor = Color.Lime
    End Sub

    Private Sub txtinput_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtinput.LostFocus
        txtinput.BackColor = Color.White

    End Sub

#End Region


    Private Sub txtinput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtinput.TextChanged

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
    Private Sub AxGrFingerXCtrl1_SensorPlug( _
     ByVal sender As System.Object, _
     ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) _
     Handles AxGrFingerXCtrl1.SensorPlug
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Plugged.")
        AxGrFingerXCtrl1.CapStartCapture(e.idSensor)
    End Sub

    ' A fingerprint reader was unplugged from system
    Private Sub AxGrFingerXCtrl1_SensorUnplug( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) _
       Handles AxGrFingerXCtrl1.SensorUnplug
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Unplugged.")
        AxGrFingerXCtrl1.CapStopCapture(e.idSensor)
    End Sub

    ' A finger was placed on reader
    Private Sub AxGrFingerXCtrl1_FingerDown( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) _
       Handles AxGrFingerXCtrl1.FingerDown
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Finger Placed.")
    End Sub

    ' A finger was removed from reader
    Private Sub AxGrFingerXCtrl1_FingerUp( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) _
       Handles AxGrFingerXCtrl1.FingerUp
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Finger removed.")
    End Sub

    ' An image was acquired from reader
    Private Sub AxGrFingerXCtrl1_ImageAcquired( _
       ByVal sender As System.Object, _
       ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) _
       Handles AxGrFingerXCtrl1.ImageAcquired

        ' Copying aquired image
        myUtil.raw.height = e.height
        myUtil.raw.width = e.width
        myUtil.raw.res = e.res
        myUtil.raw.img = e.rawImage

        ' Signaling that an Image Event occurred.
        myUtil.WriteLog("Sensor: " & e.idSensor & ". Event: Image captured.")

        ' display fingerprint image
        myUtil.PrintBiometricDisplay(False, GRConstants.GR_DEFAULT_CONTEXT)

        '---extract the template from the fingerprint scanned---
        ExtractTemplate()

        '---identify who the user is---
        _UserID = IdentifyFingerprint()
        If _UserID > 0 Then
            '---user found---
            Beep()
            'btnRegister.Enabled = False
            '---display user's information---
            GetUserInfo()
            WriteToLog(_UserID)
        Else
            '---user not found---
            ClearDisplay()
            '  btnRegister.Enabled = True
            Beep()
            lblMessage.Text = "User not found! Please register your information on the Left Side."
        End If
    End Sub
    ' Extract a template from a fingerprint image
    Private Function ExtractTemplate() As Integer
        Dim ret As Integer
        ' extract template
        ret = myUtil.ExtractTemplate()
        ' write template quality to log
        If ret = GRConstants.GR_BAD_QUALITY Then
            myUtil.WriteLog("Template extracted successfully. Bad quality.")
        ElseIf ret = GRConstants.GR_MEDIUM_QUALITY Then
            myUtil.WriteLog("Template extracted successfully. Medium quality.")
        ElseIf ret = GRConstants.GR_HIGH_QUALITY Then
            myUtil.WriteLog("Template extracted successfully. High quality.")
        End If
        If ret >= 0 Then
            ' if no error, display minutiae/segments/directions into the image
            myUtil.PrintBiometricDisplay(True, GRConstants.GR_NO_CONTEXT)
        Else
            ' write error to log
            myUtil.WriteError(ret)
        End If
        Return ret
    End Function

    '---Identify a fingerprint; returns the ID of the user---
    Private Function IdentifyFingerprint() As Integer
        Dim ret As Integer, score As Integer
        score = 0
        ' identify it
        ret = myUtil.Identify(score)
        ' write result to log
        If ret > 0 Then
            '   Beep()
            myUtil.WriteLog("Fingerprint identified. ID = " & ret & ". Score = " & score & ".")
            myUtil.PrintBiometricDisplay(True, GRConstants.GR_DEFAULT_CONTEXT)

            'Dim filePath As String
            'Dim a As String
            'a = txtlast.Text & ", " & txtfirst.Text & " " & txtmi.Text & "."
            ''  Try
            'filePath = Application.StartupPath() & "\" & DBFile
            'connection = New OleDb.OleDbConnection(ConnectionString & filePath)
            'connection.Open()

            'Dim reader As OleDb.OleDbDataReader
            'Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand



            'command.Connection = connection
            ''---retrieve user's particulars---
            'command.CommandText = "SELECT Picture FROM Enroll WHERE ID like '" & ret & "'"
            'reader = command.ExecuteReader()
            'reader.Read()


            'Dim Len1 As Long = reader.GetBytes(0, 0, Nothing, 0, 0)
            'Dim Array1(CInt(Len1)) As Byte
            'reader.GetBytes(0, 0, Array1, 0, CInt(Len1))

            'Dim MemoryStream1 As New System.IO.MemoryStream(Array1)
            'Dim Bitmap1 As New System.Drawing.Bitmap(MemoryStream1)

            'PictureBox3.Image = Bitmap1
            'Dim Form10 As New System.Windows.Forms.Form()
            'Dim PictureBox30 As New System.Windows.Forms.PictureBox()

            'PictureBox30.Dock = DockStyle.Fill
            'PictureBox30.Image = Bitmap1

            'Form10.Controls.Add(PictureBox30)
            'Form10.Show()

        ElseIf ret = 0 Then
            myUtil.WriteLog("Fingerprint not Found.")
        Else
            myUtil.WriteError(ret)
        End If
        Return ret
    End Function

    '---adds a fingerprint to the database; returns the ID of the user---
    Private Function EnrollFingerprint() As Integer
        Dim id As Integer
        ' add fingerprint
        id = myUtil.Enroll()
        ' write result to log
        If id >= 0 Then
            myUtil.WriteLog("Fingerprint enrolled with id = " & id)
        Else
            myUtil.WriteLog("Error: Fingerprint not enrolled")
        End If
        Return id
    End Function
    Public Sub WriteToLog(ByVal ID As String)
        '---write to a log file---
        Dim sw As New System.IO.StreamWriter( _
           Logfile, True, System.Text.Encoding.ASCII)
        sw.WriteLine(ID & "," & Now.ToString)
        sw.Close()
    End Sub
    '---get user's information---
    Public Sub GetUserInfo()
        Dim filePath As String
        Dim a As String
        a = txtlast.Text & ", " & txtfirst.Text & " " & txtmi.Text & "."
        '  Try
        filePath = Application.StartupPath() & "\" & DBFile
        connection = New OleDb.OleDbConnection(ConnectionString & filePath)
        connection.Open()

        Dim reader As OleDb.OleDbDataReader
        Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand
        Dim command1 As OleDb.OleDbCommand = New OleDb.OleDbCommand


        command.Connection = connection
        '---retrieve user's particulars---
        command.CommandText = "SELECT * FROM Enroll WHERE ID=" & _UserID
        reader = command.ExecuteReader()
        reader.Read()

       
        'Form1.Controls.Add(PictureBox1)
        'Form1.Show()
        ''---display user's particulars---
        lblMessage.Text = "Welcome, " & reader("Name")
        txtid.Text = reader("MEM_CODE")
        '    txtpin.Text = reader("LOG_ID")
        txtfirst.Text = reader("fname")
        txtlast.Text = reader("lname")
        txtmi.Text = reader("mname")
        txtpos.Text = reader("COURSE_POSITION")
        cbogen.Text = reader("GENDER")
        '  PictureBox3.Image = reader("Picture")

        'command1.Connection = connection
        ''---retrieve user's particulars---
        'command1.CommandText = "SELECT *FROM Enroll WHERE ID=" & _UserID
        'reader = command.ExecuteReader()
        'reader.Read()
        ''Dim Len1 As Long = reader.GetBytes(0, 0, Nothing, 0, 0)
        ''Dim Array1(CInt(Len1)) As Byte
        ''reader.GetBytes(0, 0, Array1, 0, CInt(Len1))

        ''Dim MemoryStream1 As New System.IO.MemoryStream(Array1)
        ''Dim Bitmap1 As New System.Drawing.Bitmap(MemoryStream1)
        ''PictureBox3.Image = Bitmap1

        'Dim Form1 As New Stem.Windows.Forms.Form()
        'Dim PictureBox1 As New System.Windows.Forms.PictureBox()
        '  .i()
        'PictureBox1.Dock = DockStyle.Fill
        'PictureBox1.Image = Bitmap1
        ''   Form1.Controls.Add(PictureBox1)
        ''   Form1.ShowDialog()


       
        'reader.Close()
        'reader.Close()
       
        '   Form1.Controls.Add(PictureBox1)
        '   Form1.ShowDialog()


        ' me. frmAlumni.PictureBox1.Image = Bitmap1
        'Me.Show()

        'Dim dr As OleDb.OleDbDataReader
        'Dim cm As OleDb.OleDbCommand = New OleDb.OleDbCommand

        'With cm
        '    .Connection = connection
        '    .CommandText = "SELECT Picture FROM Enroll WHERE ID=" & _UserID
        '    dr = .ExecuteReader
        'End With
        '   dr.Read()


   



        '---reset the timer to another 5 seconds---
        Timer1.Enabled = False
        Timer1.Enabled = True
        '   Catch ex As Exception
        'MsgBox(ex.ToString)
        '   End Try
    End Sub
    Public Sub ClearDisplay()
        lblMessage.Text = _
           "Please place your index finger on the fingerprint reader"
        '   PictureBox1.Image = ImageList1.Images(0)
        txtid.Text = String.Empty
        ' txtpin.Text = String.Empty
        txtlast.Text = String.Empty
        txtfirst.Text = String.Empty
        txtmi.Text = String.Empty
        txtpos.Text = String.Empty
        txtpos.Text = String.Empty
    End Sub



    Private Sub Panel7_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel7.Paint

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '  GroupBox4.Visble = False
    End Sub

    Private Sub cmdBrowse_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        OpenFileDialog1.ShowDialog()
        PictureBox3.ImageLocation = OpenFileDialog1.FileName
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click

        ds = DTRCLASS.DataModule.dataLoad1("")
        frmViewLogin.Show()
    End Sub

    Private Sub txtid_SystemColorsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtid.SystemColorsChanged

    End Sub

    Private Sub txtid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid.TextChanged

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        ' frmReport.d()
        'frmReport.da
        ' emReport.
        frmReport.Show()


    End Sub
End Class
