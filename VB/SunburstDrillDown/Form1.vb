Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports DevExpress.TreeMap
Imports DevExpress.XtraTreeMap

Namespace SunburstDrillDown
    Partial Public Class Form1
        Inherits Form

        Private dataStack As New Stack(Of DataSourceInfo)()

        Private ReadOnly Property DataAdapter() As SunburstHierarchicalDataAdapter
            Get
                Return CType(sunburstControl1.DataAdapter, SunburstHierarchicalDataAdapter)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            DataAdapter.Mappings(0).Type = GetType(TypeInfo)
            DataAdapter.DataSource = LoadDataFromXML()
        End Sub

        #Region "LoadData"
        Private Sub LoadData(ByVal element As XElement, ByVal datas As List(Of TypeInfo))
            Dim data As New TypeInfo() With { _
                .NamespaceString = element.Element("Namespace").Value, _
                .TypesCount = Convert.ToDouble(element.Element("TypesCount").Value, CultureInfo.InvariantCulture) _
            }
            datas.Add(data)
            For Each item In element.Element("NestedNamespaces").Elements()
                LoadData(item, data.NestedNamespaces)
            Next item
        End Sub
        Private Function LoadDataFromXML() As List(Of TypeInfo)
            Dim document As XDocument = XDocument.Load("..\..\Data\XtraBarsTypes.xml")
            Dim datas As New List(Of TypeInfo)()
            If document IsNot Nothing Then
                For Each element As XElement In document.Element("ArrayOfTypeInfo").Elements()
                    LoadData(element, datas)
                Next element
            End If
            Return datas
        End Function
        #End Region

        #Region "Process DrillDown"
        Private Sub sunburstControl1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles sunburstControl1.MouseUp
            Dim shi As SunburstHitInfo = sunburstControl1.CalcHitInfo(e.Location)
            If shi.InSunburstItem Then
                dataStack.Push(New DataSourceInfo(DataAdapter.DataSource, sunburstControl1.CenterLabel.TextPattern))
                Dim data As TypeInfo = CType(shi.SunburstItem.Tag, TypeInfo)
                DataAdapter.DataSource = data
                sunburstControl1.CenterLabel.TextPattern &= "." & data.NamespaceString
            ElseIf shi.InCenterLabel AndAlso dataStack.Count > 0 Then
                Dim sourceInfo As DataSourceInfo = dataStack.Pop()
                DataAdapter.DataSource = sourceInfo.Source
                sunburstControl1.CenterLabel.TextPattern = sourceInfo.Label
            End If
        End Sub
        #End Region

        Private Sub sunburstControl1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles sunburstControl1.MouseMove
            Dim shi As SunburstHitInfo = sunburstControl1.CalcHitInfo(e.Location)
            sunburstControl1.Cursor = If(shi.InCenterLabel AndAlso dataStack.Count > 0, Cursors.Hand, Cursors.Arrow)
        End Sub
    End Class

    Public Class DataSourceInfo
        Public ReadOnly Property Source() As Object
        Public ReadOnly Property Label() As String

        Public Sub New(ByVal source As Object, ByVal label As String)
            Me.Source = source
            Me.Label = label
        End Sub
    End Class

    Public Class TypeInfo
        Implements IListSource

        Public Property NamespaceString() As String
        Public Property TypesCount() As Double
        Public ReadOnly Property NestedNamespaces() As New List(Of TypeInfo)()

        Private ReadOnly Property IListSource_ContainsListCollection() As Boolean Implements IListSource.ContainsListCollection
            Get
                Return True
            End Get
        End Property

        Private Function IListSource_GetList() As IList Implements IListSource.GetList
            Return If(NestedNamespaces.Count > 0, NestedNamespaces, New List(Of TypeInfo)() From {Me})
        End Function
    End Class
End Namespace


