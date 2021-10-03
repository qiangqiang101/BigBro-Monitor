Imports System.ComponentModel

Public Class DetailSensor
    Inherits Control

    Public myParentForm As frmMonitor
    Public rzControl As ResizeableControl

    Private _left As String
    Private _right As String

#Region "Overrides"

    <Browsable(False)>
    Public Overloads Property AccessibleDescription() As String
        Get
            Return MyBase.AccessibleDescription
        End Get
        Set(value As String)
            MyBase.AccessibleDescription = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property AccessibleName() As String
        Get
            Return MyBase.AccessibleName
        End Get
        Set(value As String)
            MyBase.AccessibleName = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property AccessibleRole() As AccessibleRole
        Get
            Return MyBase.AccessibleRole
        End Get
        Set(value As AccessibleRole)
            MyBase.AccessibleRole = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property AllowDrop() As Boolean
        Get
            Return MyBase.AllowDrop
        End Get
        Set(value As Boolean)
            MyBase.AllowDrop = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ContextMenuStrip() As ContextMenuStrip
        Get
            Return MyBase.ContextMenuStrip
        End Get
        Set(value As ContextMenuStrip)
            MyBase.ContextMenuStrip = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ImeMode() As ImeMode
        Get
            Return MyBase.ImeMode
        End Get
        Set(value As ImeMode)
            MyBase.ImeMode = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property TabStop() As Boolean
        Get
            Return MyBase.TabStop
        End Get
        Set(value As Boolean)
            MyBase.TabStop = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property Tag() As Object
        Get
            Return MyBase.Tag
        End Get
        Set(value As Object)
            MyBase.Tag = value
        End Set
    End Property

    <Browsable(True)>
    <Category("Design")>
    Public Overloads Property Name() As String
        Get
            Return MyBase.Name
        End Get
        Set(value As String)
            MyBase.Name = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property CausesValidation() As Boolean
        Get
            Return MyBase.CausesValidation
        End Get
        Set(value As Boolean)
            MyBase.CausesValidation = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property TabIndex() As Integer
        Get
            Return MyBase.TabIndex
        End Get
        Set(value As Integer)
            MyBase.TabIndex = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property Cursor() As Cursor
        Get
            Return MyBase.Cursor
        End Get
        Set(value As Cursor)
            MyBase.Cursor = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property UseWaitCursor() As Boolean
        Get
            Return MyBase.UseWaitCursor
        End Get
        Set(value As Boolean)
            MyBase.UseWaitCursor = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property BackgroundImage() As Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(value As Image)
            MyBase.BackgroundImage = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property BackgroundImageLayout() As ImageLayout
        Get
            Return MyBase.BackgroundImageLayout
        End Get
        Set(value As ImageLayout)
            MyBase.BackgroundImageLayout = value
        End Set
    End Property

#End Region

    Private _parentName As String
    <Category("Behavior")>
    Public Property ParentName() As String
        Get
            Return _parentName
        End Get
        Set(value As String)
            If value = Nothing Then Exit Property
            Dim ctrl = myParentForm.Controls.Find(value, False).FirstOrDefault
            If ctrl IsNot Nothing Then
                _parentName = value
            End If
        End Set
    End Property

    Private _sensor As eCompleteSensor = eCompleteSensor.None
    <Category("Behavior")>
    Public Property DetailedSensor() As eCompleteSensor
        Get
            Return _sensor
        End Get
        Set(value As eCompleteSensor)
            _sensor = value
        End Set
    End Property

    Private _border As Boolean = True
    <Category("Appearance")>
    Public Property DrawBorder() As Boolean
        Get
            Return _border
        End Get
        Set(value As Boolean)
            _border = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim formGraphics As Graphics = e.Graphics
        formGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        formGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        Dim leftSize As Size = TextRenderer.MeasureText(_left, Font)
        Dim rightSize As Size = TextRenderer.MeasureText(_right, Font)
        Using sbrush As New SolidBrush(ForeColor)
            Dim leftRect As New Rectangle(0, 0, leftSize.Width, leftSize.Height)
            Dim rightRect As New Rectangle(leftRect.Width, 0, rightSize.Width + 1, rightSize.Height)

            formGraphics.DrawString(_left, Font, sbrush, leftRect)
            formGraphics.DrawString(_right, Font, sbrush, rightRect)
            If _border Then
                Using pen As New Pen(sbrush, 1.0F)
                    formGraphics.DrawRectangle(pen, leftRect)
                    formGraphics.DrawRectangle(pen, rightRect)
                End Using
            End If
        End Using

    End Sub

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.UserPaint, True)
        DoubleBuffered = True
        If allowResize Then
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.All)
        Else
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.None)
        End If
    End Sub

    Public Sub UpdateControl()
        Select Case _sensor
            Case eCompleteSensor.CPUClockSpeed
                Dim result = myParentForm.cpuSensor.Clock.ToLeftRight
                _left = result.Item1
                _right = result.Item2
            Case eCompleteSensor.CPUTemperature
                Dim result = myParentForm.cpuSensor.Temperature.ToLeftRight
                _left = result.Item1
                _right = result.Item2
            Case eCompleteSensor.CPULoad
                Dim result = myParentForm.cpuSensor.Load.ToLeftRight
                _left = result.Item1
                _right = result.Item2
            Case eCompleteSensor.CPUPowerWattage
                Dim result = myParentForm.cpuSensor.Power.ToLeftRight
                _left = result.Item1
                _right = result.Item2
            Case eCompleteSensor.GPUClockSpeed
                Dim result = myParentForm.gpuSensor.Clock.ToLeftRight
                _left = result.Item1
                _right = result.Item2
            Case eCompleteSensor.GPUTemperature
                Dim result = myParentForm.gpuSensor.Temperature.ToLeftRight
                _left = result.Item1
                _right = result.Item2
            Case eCompleteSensor.GPULoadPercent
                Dim result = myParentForm.gpuSensor.Load.ToLeftRight
                _left = result.Item1
                _right = result.Item2
        End Select
        Invalidate()
    End Sub

End Class
