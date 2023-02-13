Imports GrFingerXLib

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents AxGrFingerXCtrl1 As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtContactNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtSSN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRegister As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.AxGrFingerXCtrl1 = New AxGrFingerXLib.AxGrFingerXCtrl
        Me.btnRegister = New System.Windows.Forms.Button
        Me.lblMessage = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtContactNumber = New System.Windows.Forms.TextBox
        Me.txtCompany = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtSSN = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 232)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(8, 296)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(504, 95)
        Me.ListBox1.TabIndex = 1
        '
        'AxGrFingerXCtrl1
        '
        Me.AxGrFingerXCtrl1.Enabled = True
        Me.AxGrFingerXCtrl1.Location = New System.Drawing.Point(16, 120)
        Me.AxGrFingerXCtrl1.Name = "AxGrFingerXCtrl1"
        Me.AxGrFingerXCtrl1.OcxState = CType(resources.GetObject("AxGrFingerXCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxGrFingerXCtrl1.Size = New System.Drawing.Size(32, 32)
        Me.AxGrFingerXCtrl1.TabIndex = 2
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnRegister.Enabled = False
        Me.btnRegister.Location = New System.Drawing.Point(432, 248)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(75, 23)
        Me.btnRegister.TabIndex = 4
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(176, 8)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(336, 72)
        Me.lblMessage.TabIndex = 15
        Me.lblMessage.Text = "Please place your index finger on the fingerprint reader"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtContactNumber)
        Me.GroupBox1.Controls.Add(Me.txtCompany)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.txtSSN)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(176, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 152)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User's Particulars"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(144, 120)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(184, 20)
        Me.txtEmail.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(96, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Email"
        '
        'txtContactNumber
        '
        Me.txtContactNumber.Location = New System.Drawing.Point(144, 96)
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.Size = New System.Drawing.Size(104, 20)
        Me.txtContactNumber.TabIndex = 22
        '
        'txtCompany
        '
        Me.txtCompany.Location = New System.Drawing.Point(144, 72)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(184, 20)
        Me.txtCompany.TabIndex = 21
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(144, 48)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(184, 20)
        Me.txtName.TabIndex = 20
        '
        'txtSSN
        '
        Me.txtSSN.Location = New System.Drawing.Point(144, 24)
        Me.txtSSN.Name = "txtSSN"
        Me.txtSSN.Size = New System.Drawing.Size(100, 20)
        Me.txtSSN.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Contact Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Company"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Social Security Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(96, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Name"
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(520, 398)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.AxGrFingerXCtrl1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxGrFingerXCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const DBFile = "GrFingerSample.mdb"
    Const Logfile = "C:\Log.csv"
    Const ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="

    Private myUtil As Util
    Private _UserID As Integer
    Private connection As System.Data.OleDb.OleDbConnection


    Private Sub Form1_Load( _
       ByVal sender As System.Object, _
       ByVal e As System.EventArgs) _
       Handles MyBase.Load

        Dim err As Integer
        ' initialize util class
        myUtil = New Util(ListBox1, PictureBox1, AxGrFingerXCtrl1)
        ' myUtil = New Util(ListBox1, AxGrFingerXCtrl1)
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

    End Sub
#Region "delete"


    'Public Sub ListenForConnection()
    '    Const portNo As Integer = 500
    '    Dim localAdd As System.Net.IPAddress = _
    '        IPAddress.Parse("127.0.0.1")
    '    Dim listener As New TcpListener(localAdd, portNo)
    '    listener.Start()
    '    Console.WriteLine("Listening...")

    '    Dim tcpClient As TcpClient = listener.AcceptTcpClient()
    '    Dim NWStream As NetworkStream = tcpClient.GetStream
    '    Dim bytesToRead(tcpClient.ReceiveBufferSize) As Byte

    '    '---read incoming stream
    '    Dim numBytesRead As Integer = NWStream.Read(bytesToRead, 0, _
    '        CInt(tcpClient.ReceiveBufferSize))
    '    Console.WriteLine("Received :" & _
    '        Encoding.ASCII.GetString(bytesToRead, 0, numBytesRead))

    '    '---write data to file---
    '    File.Delete("C:\temp.bin")
    '    Dim fs As New FileStream("C:\temp.bin", FileMode.CreateNew, FileAccess.Write)
    '    fs.Write(bytesToRead, 0, bytesToRead.Length)
    '    fs.Close()

    '    '---load the image from the byte()
    '    AxGrFingerXCtrl1.CapLoadImageFromFile("C:\temp.bin", 300)
    '    'myUtil.WriteLog("Fail to load the file.")


    '    Dim bytesToSend As Byte() = Encoding.ASCII.GetBytes(_UserID)
    '    '---send the text
    '    NWStream.Write(bytesToSend, 0, bytesToSend.Length)

    '    tcpClient.Close()
    '    listener.Stop()
    'End Sub

    'Public Sub SendToServer(ByVal CommandType As String, ByVal data As Byte())

    '    Const portNo = 500
    '    'Const textToSend = "1234567890098765432111"
    '    Dim tcpclient As New System.Net.Sockets.TcpClient
    '    tcpclient.Connect("127.0.0.1", portNo)

    '    Dim NWStream As NetworkStream = tcpclient.GetStream
    '    Dim bytesToSend As Byte() = data '  Encoding.ASCII.GetBytes(textToSend)
    '    '---send the text
    '    NWStream.Write(bytesToSend, 0, bytesToSend.Length)

    '    '---read back the text
    '    Dim bytesToRead(tcpclient.ReceiveBufferSize) As Byte
    '    Dim numBytesRead = NWStream.Read(bytesToRead, 0, _
    '        tcpclient.ReceiveBufferSize)

    '    MsgBox("Received : " & _
    '        Encoding.ASCII.GetString(bytesToRead, 0, _
    '                                    numBytesRead))
    '    Console.ReadLine()
    '    tcpclient.Close()

    'End Sub

#End Region

    ' -----------------------------------------------------------------------------------
    ' GrFingerX events
    ' -----------------------------------------------------------------------------------
    ' A fingerprint reader was plugged on system
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
            btnRegister.Enabled = False
            '---display user's information---
            GetUserInfo()
            WriteToLog(_UserID)
        Else
            '---user not found---
            ClearDisplay()
            btnRegister.Enabled = True
            Beep()
            lblMessage.Text = "User not found! Please register your information below"
        End If
    End Sub

    '---Add a new user's information to the database---
    Public Sub AddNewUser()
        Dim filePath As String
        Try
            filePath = Application.StartupPath() & "\" & DBFile
            connection = New OleDb.OleDbConnection(ConnectionString & filePath)
            connection.Open()
            Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand
            command.Connection = connection

            '---set the user's particulars in the table---
            Dim sql As String = "UPDATE enroll SET SSN='" & txtSSN.Text & "', " & _
               "Name='" & txtName.Text & "', " & _
               "Company='" & txtCompany.Text & "', " & _
               "ContactNumber='" & txtContactNumber.Text & "', " & _
               "Email='" & txtEmail.Text & "' " & _
               " WHERE ID=" & _UserID
            command.CommandText = sql
            command.ExecuteNonQuery()
            MsgBox("User added successfully!")
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    '---get user's information---
    Public Sub GetUserInfo()
        Dim filePath As String
        Try
            filePath = Application.StartupPath() & "\" & DBFile
            connection = New OleDb.OleDbConnection(ConnectionString & filePath)
            connection.Open()
            Dim reader As OleDb.OleDbDataReader
            Dim command As OleDb.OleDbCommand = New OleDb.OleDbCommand
            command.Connection = connection
            '---retrieve user's particulars---
            command.CommandText = "SELECT * FROM Enroll WHERE ID=" & _UserID
            reader = command.ExecuteReader(CommandBehavior.CloseConnection)
            reader.Read()

            '---display user's particulars---
            lblMessage.Text = "Welcome, " & reader("name")
            txtSSN.Text = reader("SSN")
            txtName.Text = reader("Name")
            txtCompany.Text = reader("Company")
            txtContactNumber.Text = reader("ContactNumber")
            txtEmail.Text = reader("Email")

            '---reset the timer to another 5 seconds---
            Timer1.Enabled = False
            Timer1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
            myUtil.WriteLog("Fingerprint identified. ID = " & ret & ". Score = " & score & ".")
            myUtil.PrintBiometricDisplay(True, GRConstants.GR_DEFAULT_CONTEXT)
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

    '---Register button---
    Private Sub btnRegister_Click( _
       ByVal sender As System.Object, _
       ByVal e As System.EventArgs) _
       Handles btnRegister.Click
        '---first add the fingerprint---
        _UserID = EnrollFingerprint()
        '---then add the particulars---
        AddNewUser()
        '---clears the display---
        ClearDisplay()
        WriteToLog(_UserID)
    End Sub

    '---Clears the user's particulars---
    Public Sub ClearDisplay()
        lblMessage.Text = _
           "Please place your index finger on the fingerprint reader"
        PictureBox1.Image = ImageList1.Images(0)
        txtSSN.Text = String.Empty
        txtName.Text = String.Empty
        txtCompany.Text = String.Empty
        txtContactNumber.Text = String.Empty
        txtEmail.Text = String.Empty
    End Sub

    '---the Timer control---
    Private Sub Timer1_Tick( _
       ByVal sender As System.Object, _
       ByVal e As System.EventArgs) _
       Handles Timer1.Tick
        ClearDisplay()
        Timer1.Enabled = False
    End Sub

    Public Sub WriteToLog(ByVal ID As String)
        '---write to a log file---
        Dim sw As New System.IO.StreamWriter( _
           Logfile, True, System.Text.Encoding.ASCII)
        sw.WriteLine(ID & "," & Now.ToString)
        sw.Close()
    End Sub
End Class
