Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.ComponentModel.Design

<Serializable>
Public Class ImageControl
    Inherits PictureBox

    Public myParentForm As frmMonitor
    Public rzControl As ResizeableControl

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
    Public Overloads Property ErrorImage() As Image
        Get
            Return MyBase.ErrorImage
        End Get
        Set(value As Image)
            MyBase.ErrorImage = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property ImageLocation() As String
        Get
            Return MyBase.ImageLocation
        End Get
        Set(value As String)
            MyBase.ImageLocation = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property InitialImage() As Image
        Get
            Return MyBase.InitialImage
        End Get
        Set(value As Image)
            MyBase.InitialImage = value
        End Set
    End Property

    <Browsable(False)>
    Public Overloads Property WaitOnLoad() As Boolean
        Get
            Return MyBase.WaitOnLoad
        End Get
        Set(value As Boolean)
            MyBase.WaitOnLoad = value
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

    Private _sensorParam As String
    <Category("Dynamic Image"), Description("Used for a few Sensors like GPU, HDD, Ping && CustomDataTime.")>
    Public Property SensorParam() As String
        Get
            Return _sensorParam
        End Get
        Set(value As String)
            _sensorParam = value
        End Set
    End Property

    Private _sensor As eSensorType = eSensorType.None
    <Category("Dynamic Image")>
    Public Property Sensor() As eSensorType
        Get
            Return _sensor
        End Get
        Set(value As eSensorType)
            _sensor = value
            If String.IsNullOrEmpty(_sensorParam) Then
                Select Case value
                    Case eSensorType.CustomDateTime
                        _sensorParam = "dd/MM/yyyy hh:mm:ss tt"
                    Case eSensorType.Ping
                        _sensorParam = "www.google.com"
                    Case eSensorType.HDDUsage, eSensorType.HDDTotalFreeSpace, eSensorType.HDDTotalSize
                        _sensorParam = "C:\"
                    Case eSensorType.HDDLoadPercent, eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF, eSensorType.GPUClockSpeed, eSensorType.GPULoadPercent, eSensorType.GPUMemoryPercent, eSensorType.GPUPowerWattage,
                         eSensorType.GPUTemperatureC, eSensorType.GPUTemperatureF, eSensorType.GPUVRAMUsage, eSensorType.GPUMemoryClock, eSensorType.GPUShaderClock, eSensorType.GPUFrameBufferLoad,
                         eSensorType.GPUVideoEngineLoad, eSensorType.GPUBusInterfaceLoad, eSensorType.GPUVRAMFree, eSensorType.GPUVRAMTotal
                        _sensorParam = 0
                End Select
            End If
        End Set
    End Property

    Private _userMode As Boolean
    <Category("Behavior")>
    Public Property AllowUserEdit() As Boolean
        Get
            Return _userMode
        End Get
        Set(value As Boolean)
            _userMode = value
        End Set
    End Property

    Private _enableDI As Boolean = False
    <Category("Dynamic Image")>
    Public Property EnableDynamicImages() As Boolean
        Get
            Return _enableDI
        End Get
        Set(value As Boolean)
            _enableDI = value
        End Set
    End Property

    Private _imgs As DynamicImageCollection
    <Editor(GetType(DynamicImageCollectionEditor), GetType(Drawing.Design.UITypeEditor))>
    <Category("Dynamic Image")>
    Public Property DynamicImages() As DynamicImageCollection
        Get
            Return _imgs
        End Get
        Set(value As DynamicImageCollection)
            _imgs = value
        End Set
    End Property

    Public Sub New(allowResize As Boolean)
        Tag = "ThemeControl"
        _imgs = New DynamicImageCollection
        If allowResize Then
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.All)
        Else
            rzControl = New ResizeableControl(Me, ResizeableControl.EdgeEnum.None)
        End If
    End Sub

    Public Sub UpdateControl()
        Try
            If _enableDI AndAlso _imgs.Count <> 0 Then
                Dim _min = 0
                Dim _max = _imgs.Count - 1
                Dim _val = 0

                Select Case _sensor
                    Case eSensorType.CPUTemperatureC, eSensorType.CPUTemperatureF
                        _val = CInt(Math.Round((_max * myParentForm.cpuSensor.RawTemperatureC) / 100))
                    Case eSensorType.CPULoadPercent
                        _val = CInt(Math.Round((_max * myParentForm.cpuSensor.RawLoadPercent) / 100))

                    Case eSensorType.GPUTemperatureC, eSensorType.GPUTemperatureF
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawTemperatureC(_sensorParam)) / 100))
                        Else
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawTemperatureC) / 100))
                        End If
                    Case eSensorType.GPULoadPercent
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawLoadPercent(_sensorParam)) / 100))
                        Else
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawLoadPercent) / 100))
                        End If
                    Case eSensorType.GPUMemoryPercent
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawMemoryPercent(_sensorParam)) / 100))
                        Else
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawMemoryPercent) / 100))
                        End If
                    Case eSensorType.GPUVRAMUsage
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round(((myParentForm.gpuSensor.RawVRAMTotal(_sensorParam) / _max * myParentForm.gpuSensor.RawVRAMUsage(_sensorParam)) / 100) / 100))
                        Else
                            _val = CInt(Math.Round(((myParentForm.gpuSensor.RawVRAMTotal / _max * myParentForm.gpuSensor.RawVRAMUsage) / 100) / 100))
                        End If

                    Case eSensorType.RAMLoadPercent
                        _val = CInt(Math.Round((_max * myParentForm.ramSensor.RawLoadPercent) / 100))
                    Case eSensorType.RAMUsage
                        _val = CInt(Math.Round(((myParentForm.ramSensor.RawRAMTotal / _max * myParentForm.ramSensor.RawRAMUsage) / 100) / 100))
                    Case eSensorType.RAMAvailable
                        _val = CInt(Math.Round(((myParentForm.ramSensor.RawRAMTotal / _max * myParentForm.ramSensor.RawRAMAvailable) / 100) / 100))

                    Case eSensorType.HDDTemperatureC, eSensorType.HDDTemperatureF
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round((_max * myParentForm.hddSensor.RawTemperatureC(_sensorParam)) / 100))
                        Else
                            _val = CInt(Math.Round((_max * myParentForm.hddSensor.RawTemperatureC) / 100))
                        End If
                    Case eSensorType.HDDLoadPercent
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round((_max * myParentForm.hddSensor.RawLoadPercent(_sensorParam)) / 100))
                        Else
                            _val = CInt(Math.Round((_max * myParentForm.hddSensor.RawLoadPercent) / 100))
                        End If
                    Case eSensorType.HDDUsage
                        If String.IsNullOrEmpty(_sensorParam) Then
                            _val = CInt(Math.Round((_max * (100 * myParentForm.hddSensor.RawDiskUsage / myParentForm.hddSensor.RawDiskTotalSize) / 100)))
                        Else
                            _val = CInt(Math.Round((_max * (100 * myParentForm.hddSensor.RawDiskUsage(CStr(_sensorParam)) / myParentForm.hddSensor.RawDiskTotalSize(CStr(_sensorParam))) / 100)))
                        End If
                    Case eSensorType.HDDTotalFreeSpace
                        If String.IsNullOrEmpty(_sensorParam) Then
                            _val = CInt(Math.Round((_max * (100 * myParentForm.hddSensor.RawDiskTotalFreeSpace / myParentForm.hddSensor.RawDiskTotalSize) / 100)))
                        Else
                            _val = CInt(Math.Round((_max * (100 * myParentForm.hddSensor.RawDiskTotalFreeSpace(CStr(_sensorParam)) / myParentForm.hddSensor.RawDiskTotalSize(CStr(_sensorParam))) / 100)))
                        End If

                    Case eSensorType.MoboTemperatureC, eSensorType.MoboTemperatureF
                        _val = CInt(Math.Round((_max * myParentForm.moboSensor.RawTemperatureC) / 100))

                        'Added 13/01/2022
                    Case eSensorType.GPUFrameBufferLoad
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawFrameBufferLoad(_sensorParam)) / 100))
                        Else
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawFrameBufferLoad) / 100))
                        End If
                    Case eSensorType.GPUVideoEngineLoad
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawVideoEngineLoad(_sensorParam)) / 100))
                        Else
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawVideoEngineLoad) / 100))
                        End If
                    Case eSensorType.GPUBusInterfaceLoad
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawBusInterfaceLoad(_sensorParam)) / 100))
                        Else
                            _val = CInt(Math.Round((_max * myParentForm.gpuSensor.RawBusInterfaceLoad) / 100))
                        End If

                        'Added 05/02/2022
                    Case eSensorType.CPUCoreTemperatureC, eSensorType.CPUCoreTemperatureF
                        If IsNumeric(_sensorParam) Then
                            _val = CInt(Math.Round((_max * myParentForm.cpuSensor.RawCoreTemperatureC(_sensorParam)) / 100))
                        Else
                            _val = CInt(Math.Round((_max * myParentForm.cpuSensor.RawCoreTemperatureC) / 100))
                        End If
                End Select

                Try
                    Image = DynamicImages.Find(_val).Image
                Catch ex As Exception
                    Image = My.Resources.Blank
                End Try

                'Invalidate()
            End If
        Catch ex As Exception
            Logger.Log(ex)
        End Try
    End Sub

End Class

<Serializable>
Public Class SImage

    Private _img As Image
    Public Property Image() As Image
        Get
            Return _img
        End Get
        Set(value As Image)
            _img = value
        End Set
    End Property

    Private _di As Integer
    Public Property DisplayIndex() As Integer
        Get
            Return _di
        End Get
        Set(value As Integer)
            _di = value
        End Set
    End Property

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

End Class

<Serializable>
Public Class DynamicImageCollection
    Inherits CollectionBase

    Default Public ReadOnly Property Item(ByVal index As Integer) As SImage
        Get
            Return CType(List(index), SImage)
        End Get
    End Property

    Public Sub Add(ByVal img As SImage)
        List.Add(img)
    End Sub

    Public Sub AddRange(ByVal listOfSImage As List(Of SImage))
        For Each si In listOfSImage
            List.Add(si)
        Next
    End Sub

    Public Sub Remove(ByVal img As SImage)
        List.Remove(img)
    End Sub

    Public Function Find(di As Integer) As SImage
        Return (From si As SImage In List Where si.DisplayIndex = di).FirstOrDefault
    End Function

    Public Function Items() As List(Of SImage)
        Dim genericList As New List(Of SImage)
        For Each si As SImage In List
            genericList.Add(si)
        Next
        Return genericList
    End Function

End Class

<Serializable>
Public Class DynamicImageCollectionEditor
    Inherits CollectionEditor

    Public Sub New(type As Type)
        MyBase.New(type)
    End Sub

    Protected Overrides Function GetDisplayText(value As Object) As String
        Dim item As New SImage()
        item = CType(value, SImage)

        Return MyBase.GetDisplayText($"[{item.DisplayIndex}] {item.Name}")
    End Function

End Class