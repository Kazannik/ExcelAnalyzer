namespace ExcelAnalyzer
{
    partial class ExcelAnalyzerRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ExcelAnalyzerRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabExcelAnalyzer = this.Factory.CreateRibbonTab();
            this.ExcelAnalyzerPane_Group = this.Factory.CreateRibbonGroup();
            this.ExcelAnalyzerPane_ToggleButton = this.Factory.CreateRibbonToggleButton();
            this.TabExcelAnalyzer.SuspendLayout();
            this.ExcelAnalyzerPane_Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabExcelAnalyzer
            // 
            this.TabExcelAnalyzer.Groups.Add(this.ExcelAnalyzerPane_Group);
            this.TabExcelAnalyzer.Label = "#Label";
            this.TabExcelAnalyzer.Name = "TabExcelAnalyzer";
            this.TabExcelAnalyzer.Position = this.Factory.RibbonPosition.AfterOfficeId("TabData");
            // 
            // ExcelAnalyzerPane_Group
            // 
            this.ExcelAnalyzerPane_Group.Items.Add(this.ExcelAnalyzerPane_ToggleButton);
            this.ExcelAnalyzerPane_Group.Label = "#Label";
            this.ExcelAnalyzerPane_Group.Name = "ExcelAnalyzerPane_Group";
            // 
            // ExcelAnalyzerPane_ToggleButton
            // 
            this.ExcelAnalyzerPane_ToggleButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ExcelAnalyzerPane_ToggleButton.Label = "#Label";
            this.ExcelAnalyzerPane_ToggleButton.Name = "ExcelAnalyzerPane_ToggleButton";
            this.ExcelAnalyzerPane_ToggleButton.ShowImage = true;
            this.ExcelAnalyzerPane_ToggleButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ExcelAnalyzerPane_ToggleButton_Click);
            // 
            // ExcelAnalyzerRibbon
            // 
            this.Name = "ExcelAnalyzerRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabExcelAnalyzer);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ExcelAnalyzerRibbon_Load);
            this.TabExcelAnalyzer.ResumeLayout(false);
            this.TabExcelAnalyzer.PerformLayout();
            this.ExcelAnalyzerPane_Group.ResumeLayout(false);
            this.ExcelAnalyzerPane_Group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabExcelAnalyzer;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ExcelAnalyzerPane_Group;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton ExcelAnalyzerPane_ToggleButton;
    }

    partial class ThisRibbonCollection
    {
        internal ExcelAnalyzerRibbon ExcelAnalyzerRibbon
        {
            get { return this.GetRibbon<ExcelAnalyzerRibbon>(); }
        }
    }
}
