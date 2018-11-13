namespace SunburstDrillDown {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.XtraTreeMap.SunburstPaletteColorizer sunburstPaletteColorizer1 = new DevExpress.XtraTreeMap.SunburstPaletteColorizer();
            DevExpress.XtraTreeMap.SunburstHierarchicalDataAdapter sunburstHierarchicalDataAdapter1 = new DevExpress.XtraTreeMap.SunburstHierarchicalDataAdapter();
            DevExpress.XtraTreeMap.SunburstHierarchicalDataMapping sunburstHierarchicalDataMapping1 = new DevExpress.XtraTreeMap.SunburstHierarchicalDataMapping();
            this.sunburstControl1 = new DevExpress.XtraTreeMap.SunburstControl();
            ((System.ComponentModel.ISupportInitialize)(this.sunburstControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // sunburstControl1
            // 
            this.sunburstControl1.CenterLabel.TextPattern = "XtraBar";
            this.sunburstControl1.Colorizer = sunburstPaletteColorizer1;
            sunburstHierarchicalDataMapping1.ChildrenDataMember = "NestedNamespaces";
            sunburstHierarchicalDataMapping1.LabelDataMember = "NamespaceString";
            sunburstHierarchicalDataMapping1.ValueDataMember = "TypesCount";
            sunburstHierarchicalDataAdapter1.Mappings.Add(sunburstHierarchicalDataMapping1);
            this.sunburstControl1.DataAdapter = sunburstHierarchicalDataAdapter1;
            this.sunburstControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sunburstControl1.HoleRadiusPercent = 40;
            this.sunburstControl1.Location = new System.Drawing.Point(0, 0);
            this.sunburstControl1.Name = "sunburstControl1";
            this.sunburstControl1.Size = new System.Drawing.Size(800, 450);
            this.sunburstControl1.TabIndex = 0;
            this.sunburstControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sunburstControl1_MouseMove);
            this.sunburstControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sunburstControl1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sunburstControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sunburstControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeMap.SunburstControl sunburstControl1;
    }
}

