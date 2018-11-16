Namespace SunburstDrillDown
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim sunburstPaletteColorizer1 As New DevExpress.XtraTreeMap.SunburstPaletteColorizer()
            Dim sunburstHierarchicalDataAdapter1 As New DevExpress.XtraTreeMap.SunburstHierarchicalDataAdapter()
            Dim sunburstHierarchicalDataMapping1 As New DevExpress.XtraTreeMap.SunburstHierarchicalDataMapping()
            Me.sunburstControl1 = New DevExpress.XtraTreeMap.SunburstControl()
            CType(Me.sunburstControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' sunburstControl1
            ' 
            Me.sunburstControl1.CenterLabel.TextPattern = "XtraBar"
            Me.sunburstControl1.Colorizer = sunburstPaletteColorizer1
            sunburstHierarchicalDataMapping1.ChildrenDataMember = "NestedNamespaces"
            sunburstHierarchicalDataMapping1.LabelDataMember = "NamespaceString"
            sunburstHierarchicalDataMapping1.ValueDataMember = "TypesCount"
            sunburstHierarchicalDataAdapter1.Mappings.Add(sunburstHierarchicalDataMapping1)
            Me.sunburstControl1.DataAdapter = sunburstHierarchicalDataAdapter1
            Me.sunburstControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.sunburstControl1.HoleRadiusPercent = 40
            Me.sunburstControl1.Location = New System.Drawing.Point(0, 0)
            Me.sunburstControl1.Name = "sunburstControl1"
            Me.sunburstControl1.Size = New System.Drawing.Size(800, 450)
            Me.sunburstControl1.TabIndex = 0
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 450)
            Me.Controls.Add(Me.sunburstControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.sunburstControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents sunburstControl1 As DevExpress.XtraTreeMap.SunburstControl
    End Class
End Namespace

