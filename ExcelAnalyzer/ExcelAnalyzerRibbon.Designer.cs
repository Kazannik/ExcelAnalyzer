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
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            this.TabExcelAnalyzer = this.Factory.CreateRibbonTab();
            this.ArmDataAnalyzerPane_Group = this.Factory.CreateRibbonGroup();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.WorkbookTools_Group = this.Factory.CreateRibbonGroup();
            this.ExcelAnalyzerPane_Group = this.Factory.CreateRibbonGroup();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.ArmDataAnalyzerPane_ToggleButton = this.Factory.CreateRibbonToggleButton();
            this.ArmDataRefresh_Button = this.Factory.CreateRibbonButton();
            this.WorkbookToolsSum_Button = this.Factory.CreateRibbonButton();
            this.WorkbookToolsInsertSheet_Button = this.Factory.CreateRibbonButton();
            this.WorkbookToolsInsertFormula_Button = this.Factory.CreateRibbonButton();
            this.WorkbookToolsInsertText_Button = this.Factory.CreateRibbonButton();
            this.WorkbookToolsCopyAndPaste_Button = this.Factory.CreateRibbonButton();
            this.button6 = this.Factory.CreateRibbonButton();
            this.button7 = this.Factory.CreateRibbonButton();
            this.ExcelAnalyzerPane_ToggleButton = this.Factory.CreateRibbonToggleButton();
            this.Help_Button = this.Factory.CreateRibbonButton();
            this.About_Button = this.Factory.CreateRibbonButton();
            this.TabExcelAnalyzer.SuspendLayout();
            this.ArmDataAnalyzerPane_Group.SuspendLayout();
            this.WorkbookTools_Group.SuspendLayout();
            this.ExcelAnalyzerPane_Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabExcelAnalyzer
            // 
            this.TabExcelAnalyzer.Groups.Add(this.ArmDataAnalyzerPane_Group);
            this.TabExcelAnalyzer.Groups.Add(this.WorkbookTools_Group);
            this.TabExcelAnalyzer.Groups.Add(this.ExcelAnalyzerPane_Group);
            this.TabExcelAnalyzer.Label = "#Label";
            this.TabExcelAnalyzer.Name = "TabExcelAnalyzer";
            this.TabExcelAnalyzer.Position = this.Factory.RibbonPosition.AfterOfficeId("TabData");
            // 
            // ArmDataAnalyzerPane_Group
            // 
            ribbonDialogLauncherImpl1.OfficeImageId = "ControlToolboxOutlook";
            this.ArmDataAnalyzerPane_Group.DialogLauncher = ribbonDialogLauncherImpl1;
            this.ArmDataAnalyzerPane_Group.Items.Add(this.ArmDataAnalyzerPane_ToggleButton);
            this.ArmDataAnalyzerPane_Group.Items.Add(this.separator2);
            this.ArmDataAnalyzerPane_Group.Items.Add(this.ArmDataRefresh_Button);
            this.ArmDataAnalyzerPane_Group.KeyTip = "A";
            this.ArmDataAnalyzerPane_Group.Label = "#Label";
            this.ArmDataAnalyzerPane_Group.Name = "ArmDataAnalyzerPane_Group";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // WorkbookTools_Group
            // 
            this.WorkbookTools_Group.Items.Add(this.WorkbookToolsSum_Button);
            this.WorkbookTools_Group.Items.Add(this.WorkbookToolsInsertSheet_Button);
            this.WorkbookTools_Group.Items.Add(this.WorkbookToolsInsertFormula_Button);
            this.WorkbookTools_Group.Items.Add(this.WorkbookToolsInsertText_Button);
            this.WorkbookTools_Group.Items.Add(this.WorkbookToolsCopyAndPaste_Button);
            this.WorkbookTools_Group.Items.Add(this.button6);
            this.WorkbookTools_Group.Items.Add(this.button7);
            this.WorkbookTools_Group.Label = "#Label";
            this.WorkbookTools_Group.Name = "WorkbookTools_Group";
            // 
            // ExcelAnalyzerPane_Group
            // 
            this.ExcelAnalyzerPane_Group.Items.Add(this.ExcelAnalyzerPane_ToggleButton);
            this.ExcelAnalyzerPane_Group.Items.Add(this.separator1);
            this.ExcelAnalyzerPane_Group.Items.Add(this.Help_Button);
            this.ExcelAnalyzerPane_Group.Items.Add(this.About_Button);
            this.ExcelAnalyzerPane_Group.Label = "#Label";
            this.ExcelAnalyzerPane_Group.Name = "ExcelAnalyzerPane_Group";
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // ArmDataAnalyzerPane_ToggleButton
            // 
            this.ArmDataAnalyzerPane_ToggleButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ArmDataAnalyzerPane_ToggleButton.Image = global::ExcelAnalyzer.Properties.Resources.APPICON;
            this.ArmDataAnalyzerPane_ToggleButton.Label = "#Label";
            this.ArmDataAnalyzerPane_ToggleButton.Name = "ArmDataAnalyzerPane_ToggleButton";
            this.ArmDataAnalyzerPane_ToggleButton.OfficeImageId = "AppointmentColorDialog";
            this.ArmDataAnalyzerPane_ToggleButton.ShowImage = true;
            this.ArmDataAnalyzerPane_ToggleButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AnalyzerPane_ToggleButton_Click);
            // 
            // ArmDataRefresh_Button
            // 
            this.ArmDataRefresh_Button.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ArmDataRefresh_Button.Label = "#Label";
            this.ArmDataRefresh_Button.Name = "ArmDataRefresh_Button";
            this.ArmDataRefresh_Button.OfficeImageId = "RefreshAll";
            this.ArmDataRefresh_Button.ShowImage = true;
            // 
            // WorkbookToolsSum_Button
            // 
            this.WorkbookToolsSum_Button.Label = "button1";
            this.WorkbookToolsSum_Button.Name = "WorkbookToolsSum_Button";
            this.WorkbookToolsSum_Button.ShowImage = true;
            // 
            // WorkbookToolsInsertSheet_Button
            // 
            this.WorkbookToolsInsertSheet_Button.Label = "button2";
            this.WorkbookToolsInsertSheet_Button.Name = "WorkbookToolsInsertSheet_Button";
            this.WorkbookToolsInsertSheet_Button.ShowImage = true;
            // 
            // WorkbookToolsInsertFormula_Button
            // 
            this.WorkbookToolsInsertFormula_Button.Label = "button3";
            this.WorkbookToolsInsertFormula_Button.Name = "WorkbookToolsInsertFormula_Button";
            this.WorkbookToolsInsertFormula_Button.ShowImage = true;
            // 
            // WorkbookToolsInsertText_Button
            // 
            this.WorkbookToolsInsertText_Button.Label = "button4";
            this.WorkbookToolsInsertText_Button.Name = "WorkbookToolsInsertText_Button";
            this.WorkbookToolsInsertText_Button.ShowImage = true;
            // 
            // WorkbookToolsCopyAndPaste_Button
            // 
            this.WorkbookToolsCopyAndPaste_Button.Label = "button5";
            this.WorkbookToolsCopyAndPaste_Button.Name = "WorkbookToolsCopyAndPaste_Button";
            this.WorkbookToolsCopyAndPaste_Button.ShowImage = true;
            // 
            // button6
            // 
            this.button6.Label = "button6";
            this.button6.Name = "button6";
            this.button6.ShowImage = true;
            // 
            // button7
            // 
            this.button7.Label = "button7";
            this.button7.Name = "button7";
            this.button7.ShowImage = true;
            // 
            // ExcelAnalyzerPane_ToggleButton
            // 
            this.ExcelAnalyzerPane_ToggleButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ExcelAnalyzerPane_ToggleButton.Label = "#Label";
            this.ExcelAnalyzerPane_ToggleButton.Name = "ExcelAnalyzerPane_ToggleButton";
            this.ExcelAnalyzerPane_ToggleButton.ShowImage = true;
            this.ExcelAnalyzerPane_ToggleButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AnalyzerPane_ToggleButton_Click);
            // 
            // Help_Button
            // 
            this.Help_Button.Label = "#Label";
            this.Help_Button.Name = "Help_Button";
            this.Help_Button.ShowImage = true;
            this.Help_Button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Help_Button_Click);
            // 
            // About_Button
            // 
            this.About_Button.Label = "#Label";
            this.About_Button.Name = "About_Button";
            this.About_Button.ShowImage = true;
            this.About_Button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.About_Button_Click);
            // 
            // ExcelAnalyzerRibbon
            // 
            this.Name = "ExcelAnalyzerRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabExcelAnalyzer);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ExcelAnalyzerRibbon_Load);
            this.TabExcelAnalyzer.ResumeLayout(false);
            this.TabExcelAnalyzer.PerformLayout();
            this.ArmDataAnalyzerPane_Group.ResumeLayout(false);
            this.ArmDataAnalyzerPane_Group.PerformLayout();
            this.WorkbookTools_Group.ResumeLayout(false);
            this.WorkbookTools_Group.PerformLayout();
            this.ExcelAnalyzerPane_Group.ResumeLayout(false);
            this.ExcelAnalyzerPane_Group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabExcelAnalyzer;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ExcelAnalyzerPane_Group;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton ExcelAnalyzerPane_ToggleButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Help_Button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton About_Button;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup WorkbookTools_Group;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton WorkbookToolsSum_Button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton WorkbookToolsInsertSheet_Button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton WorkbookToolsInsertFormula_Button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton WorkbookToolsInsertText_Button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton WorkbookToolsCopyAndPaste_Button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button7;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ArmDataAnalyzerPane_Group;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton ArmDataAnalyzerPane_ToggleButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ArmDataRefresh_Button;
    }

    partial class ThisRibbonCollection
    {
        internal ExcelAnalyzerRibbon ExcelAnalyzerRibbon
        {
            get { return this.GetRibbon<ExcelAnalyzerRibbon>(); }
        }
    }
}
