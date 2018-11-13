using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.TreeMap;
using DevExpress.XtraTreeMap;
using SunburstDrillDown.Properties;

namespace SunburstDrillDown {
    public partial class Form1 : Form {
        Stack<DataSourceInfo> dataStack = new Stack<DataSourceInfo>();

        SunburstHierarchicalDataAdapter DataAdapter { get { return (SunburstHierarchicalDataAdapter)sunburstControl1.DataAdapter; } }

        public Form1() {
            InitializeComponent();
            DataAdapter.Mappings[0].Type = typeof(TypeInfo);
            DataAdapter.DataSource = LoadDataFromXML();
        }

        #region LoadData
        void LoadData(XElement element, List<TypeInfo> datas) {
            TypeInfo data = new TypeInfo() { NamespaceString = element.Element("Namespace").Value, TypesCount = Convert.ToDouble(element.Element("TypesCount").Value, CultureInfo.InvariantCulture) };
            datas.Add(data);
            foreach (var item in element.Element("NestedNamespaces").Elements())
                LoadData(item, data.NestedNamespaces);
        }
        List<TypeInfo> LoadDataFromXML() {
            XDocument document = XDocument.Load(@"..\..\Data\XtraBarsTypes.xml");
            List<TypeInfo> datas = new List<TypeInfo>();
            if (document != null) {
                foreach (XElement element in document.Element("ArrayOfTypeInfo").Elements())
                    LoadData(element, datas);
            }
            return datas;
        }
        #endregion

        #region Process DrillDown
        void sunburstControl1_MouseUp(object sender, MouseEventArgs e) {
            SunburstHitInfo shi = sunburstControl1.CalcHitInfo(e.Location);
            if (shi.InSunburstItem) {
                dataStack.Push(new DataSourceInfo(DataAdapter.DataSource, sunburstControl1.CenterLabel.TextPattern));
                TypeInfo data = (TypeInfo)shi.SunburstItem.Tag;
                DataAdapter.DataSource = data;
                sunburstControl1.CenterLabel.TextPattern += "." + data.NamespaceString;
            }
            else if (shi.InCenterLabel && dataStack.Count > 0) {
                DataSourceInfo sourceInfo = dataStack.Pop();
                DataAdapter.DataSource = sourceInfo.Source;
                sunburstControl1.CenterLabel.TextPattern = sourceInfo.Label;
            }
        }
        #endregion

        void sunburstControl1_MouseMove(object sender, MouseEventArgs e) {
            SunburstHitInfo shi = sunburstControl1.CalcHitInfo(e.Location);
            sunburstControl1.Cursor = shi.InCenterLabel && dataStack.Count > 0 ? Cursors.Hand : Cursors.Arrow;
        }
    }

    public class DataSourceInfo {
        public object Source { get; }
        public string Label { get; }

        public DataSourceInfo(object source, string label) {
            Source = source;
            Label = label;
        }
    }

    public class TypeInfo : IListSource {
        public string NamespaceString { get; set; }
        public double TypesCount { get; set; }
        public List<TypeInfo> NestedNamespaces { get; } = new List<TypeInfo>();

        bool IListSource.ContainsListCollection { get { return true; } }

        IList IListSource.GetList() {
            return NestedNamespaces.Count > 0 ? NestedNamespaces : new List<TypeInfo>() { this };
        }
    }
}


