using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using Microsoft.Office.Core;

namespace ExcelAnalyzer.Panes
{
    public partial class ExcelAnalyzerPane : UserControl
    {
        public ExcelAnalyzerPane()
        {
            
            InitializeComponent();

            if (Globals.ThisAddIn != null && Globals.ThisAddIn.Application != null)
            {
                Microsoft.Office.Interop.Excel.Application application;
                application = Globals.ThisAddIn.Application;

                stdole.IPictureDisp img;
                Bitmap image;

                img = application.CommandBars.GetImageMso("SelectAll", 16, 16);
                image = Gdi32.ConvertPixelByPixel(img);
                this.TabControl_ImageList.Images.Add("SelectAll", image);
                img = application.CommandBars.GetImageMso("ChartAreaChart", 16, 16);
                image = Gdi32.ConvertPixelByPixel(img);
                this.TabControl_ImageList.Images.Add("ChartAreaChart", image);
                img = application.CommandBars.GetImageMso("PercentStyle", 16, 16);
                image = Gdi32.ConvertPixelByPixel(img);
                this.TabControl_ImageList.Images.Add("PercentStyle", image);
                img = application.CommandBars.GetImageMso("EditExpression", 16, 16);
                image = Gdi32.ConvertPixelByPixel(img);
                this.TabControl_ImageList.Images.Add("EditExpression", image);

                this.ExcelAnalyzer_TabControl.TabPages[0].Text = ExcelAnalyzerConstants.Values;
                this.ExcelAnalyzer_TabControl.TabPages[0].ImageKey = "SelectAll";
                this.ExcelAnalyzer_TabControl.TabPages[1].Text = ExcelAnalyzerConstants.Increases;
                this.ExcelAnalyzer_TabControl.TabPages[1].ImageKey = "ChartAreaChart";
                this.ExcelAnalyzer_TabControl.TabPages[2].Text = ExcelAnalyzerConstants.Proportions;
                this.ExcelAnalyzer_TabControl.TabPages[2].ImageKey = "PercentStyle";
                this.ExcelAnalyzer_TabControl.TabPages[3].Text = ExcelAnalyzerConstants.Expressions;
                this.ExcelAnalyzer_TabControl.TabPages[3].ImageKey = "EditExpression";

                application.CommandBars["Cell"].Reset();
                application.CommandBars["Cell"].Protection = MsoBarProtection.msoBarNoProtection;

                SumButton = (CommandBarButton)application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 8);
                SumButton.FaceId = 226;
                SumButton.Caption = Properties.Resources.Sum_Button_Label;
                SumButton.BeginGroup = true;

                InsertCaptionButton = (CommandBarButton)application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 9);
                InsertCaptionButton.FaceId = 1751;
                InsertCaptionButton.Caption = Properties.Resources.InsertCaption_Button_Label;

                InsertFormulaButton = (CommandBarButton)application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 10);
                InsertFormulaButton.FaceId = 385;
                InsertFormulaButton.Caption = Properties.Resources.InsertFormula_Button_Label;

                InsertTextButton = (CommandBarButton)application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 11);
                InsertTextButton.FaceId = 173;
                InsertTextButton.Caption = Properties.Resources.InsertText_Button_Label;

                InsertCopyButton = (CommandBarButton)application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 12);
                InsertCopyButton.FaceId = 1642;
                InsertCopyButton.Caption = Properties.Resources.InsertCopy_Button_Label;

                EqualsSheetButton = (CommandBarButton)application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 13);
                EqualsSheetButton.FaceId = 2652;
                EqualsSheetButton.Caption = Properties.Resources.EqualsSheet_Button_Label;
                
                application.CommandBars["Cell"].Protection = MsoBarProtection.msoBarNoCustomize;

                application.CommandBars[application.CommandBars["Cell"].Index + 3].Reset();
                application.CommandBars[application.CommandBars["Cell"].Index + 3].Protection = MsoBarProtection.msoBarNoProtection;
                CellSumButton = (CommandBarButton)application.CommandBars[application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 8);

                CellSumButton.FaceId = 226;
                CellSumButton.Caption = Properties.Resources.Sum_Button_Label;
                CellSumButton.BeginGroup = true;

                CellInsertCaptionButton = (CommandBarButton)application.CommandBars[application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 9);
                CellInsertCaptionButton.FaceId = 1751;
                CellInsertCaptionButton.Caption = Properties.Resources.InsertCaption_Button_Label;

                CellInsertFormulaButton = (CommandBarButton)application.CommandBars[application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 10);
                CellInsertFormulaButton.FaceId = 385;
                CellInsertFormulaButton.Caption = ExcelAnalyzer.Properties.Resources.InsertFormula_Button_Label;

                CellInsertTextButton = (CommandBarButton)application.CommandBars[application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 11);
                CellInsertTextButton.FaceId = 173;
                CellInsertTextButton.Caption = Properties.Resources.InsertText_Button_Label;

                CellInsertCopyButton = (CommandBarButton)application.CommandBars[application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 12);
                CellInsertCopyButton.FaceId = 1642;
                CellInsertCopyButton.Caption = Properties.Resources.InsertCopy_Button_Label;

                CellEqualsSheetButton = (CommandBarButton)application.CommandBars[application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 13);
                CellEqualsSheetButton.FaceId = 2652;
                CellEqualsSheetButton.Caption = ExcelAnalyzer.Properties.Resources.EqualsSheet_Button_Label;

                application.CommandBars[application.CommandBars["Cell"].Index + 3].Protection = MsoBarProtection.msoBarNoCustomize;
            }
        }


        private CommandBarButton SumButton;
        private CommandBarButton InsertCaptionButton;
        private CommandBarButton InsertFormulaButton;
        private CommandBarButton InsertTextButton;
        private CommandBarButton InsertCopyButton;
        private CommandBarButton EqualsSheetButton;

        private CommandBarButton CellSumButton;
        private CommandBarButton CellInsertCaptionButton;
        private CommandBarButton CellInsertFormulaButton;
        private CommandBarButton CellInsertTextButton;
        private CommandBarButton CellInsertCopyButton;
        private CommandBarButton CellEqualsSheetButton;

        private void AddPopupMenu()
        {
            //    this._application.CommandBars["Cell"].Reset();
            //    this._application.CommandBars["Cell"].Protection = MsoBarProtection.msoBarNoProtection;

            //    SumButton =(CommandBarButton) this._application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before:8);
            //    SumButton.FaceId = 226;
            //    SumButton.Caption = ExcelAnalyzer.Properties.Resources.Sum_Button_Label;
            //    SumButton.BeginGroup = true;

            //    InsertCaptionButton = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 9);
            //    InsertCaptionButton.FaceId = 1751;
            //    InsertCaptionButton.Caption = ExcelAnalyzer.Properties.Resources.InsertCaption_Button_Label;

            //    InsertFormulaButton = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 10);
            //    InsertFormulaButton.FaceId = 385;
            //    InsertFormulaButton.Caption = ExcelAnalyzer.Properties.Resources.InsertFormula_Button_Label;

            //    InsertTextButton = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 11);
            //    InsertTextButton.FaceId = 173;
            //    InsertTextButton.Caption = ExcelAnalyzer.Properties.Resources.InsertText_Button_Label;

            //    InsertCopyButton = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 12);
            //    InsertCopyButton.FaceId = 1642;
            //    InsertCopyButton.Caption = ExcelAnalyzer.Properties.Resources.InsertCopy_Button_Label;

            //    EqualsSheetButton = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type: MsoControlType.msoControlButton, Before: 13);
            //    EqualsSheetButton.FaceId = 2652;
            //    EqualsSheetButton.Caption = ExcelAnalyzer.Properties.Resources.EqualsSheet_Button_Label;

            //    //    'ListButton = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type:=Microsoft.Office.Core.MsoControlType.msoControlButton, Before:=14)
            //    //    'With ListButton
            //    //    '    .FaceId = 162
            //    //    '    .Caption = My.Resources.List_Button_Label
            //    //    'End With

            //    //    SetViewButton = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 15)
            //    //    With SetViewButton
            //    //        .FaceId = 25
            //    //        .Caption = "Закрепить ячейку для списка значений"
            //    //        .BeginGroup = True
            //    //    End With

            //    //    SetIncrease1Button = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 16)
            //    //    With SetIncrease1Button
            //    //        .FaceId = 422
            //    //        .Caption = "Закрепить ячейку для анализа прироста (текущий период)"
            //    //        .BeginGroup = True
            //    //    End With
            //    //    SetIncrease2Button = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 17)
            //    //    With SetIncrease2Button
            //    //        .FaceId = 422
            //    //        .Caption = "Закрепить ячейку для анализа прироста (АППГ)"
            //    //    End With

            //    //    SetProportion1Button = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 18)
            //    //    With SetProportion1Button
            //    //        .FaceId = 396
            //    //        .Caption = "Закрепить ячейку для анализа удельного веса (целое)"
            //    //        .BeginGroup = True
            //    //    End With
            //    //    SetProportion2Button = (CommandBarButton)this._application.CommandBars["Cell"].Controls.Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 19)
            //    //    With SetProportion2Button
            //    //        .FaceId = 396
            //    //        .Caption = "Закрепить ячейку для анализа удельного веса (часть)"
            //    //    End With
            //    //End With
            //    this._application.CommandBars["Cell"].Protection = MsoBarProtection.msoBarNoCustomize;
            ////End With

            //    this._application.CommandBars[this._application.CommandBars["Cell"].Index + 3].Reset();
            //    this._application.CommandBars[this._application.CommandBars["Cell"].Index + 3].Protection = MsoBarProtection.msoBarNoProtection;
            //    CellSumButton = (CommandBarButton)this._application.CommandBars[this._application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 8);

            //    CellSumButton.FaceId = 226;
            //    CellSumButton.Caption = ExcelAnalyzer.Properties.Resources.Sum_Button_Label;
            //    CellSumButton.BeginGroup = true;

            //    CellInsertCaptionButton = (CommandBarButton)this._application.CommandBars[this._application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 9);
            //    CellInsertCaptionButton.FaceId = 1751;
            //    CellInsertCaptionButton.Caption = ExcelAnalyzer.Properties.Resources.InsertCaption_Button_Label;

            //    CellInsertFormulaButton = (CommandBarButton)this._application.CommandBars[this._application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 10);
            //    CellInsertFormulaButton.FaceId = 385;
            //    CellInsertFormulaButton.Caption = ExcelAnalyzer.Properties.Resources.InsertFormula_Button_Label;

            //    CellInsertTextButton = (CommandBarButton)this._application.CommandBars[this._application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 11);
            //    CellInsertTextButton.FaceId = 173;
            //    CellInsertTextButton.Caption = ExcelAnalyzer.Properties.Resources.InsertText_Button_Label;

            //    CellInsertCopyButton = (CommandBarButton)this._application.CommandBars[this._application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 12);
            //    CellInsertCopyButton.FaceId = 1642;
            //    CellInsertCopyButton.Caption = ExcelAnalyzer.Properties.Resources.InsertCopy_Button_Label;

            //    CellEqualsSheetButton = (CommandBarButton)this._application.CommandBars[this._application.CommandBars["Cell"].Index + 3].Controls.Add(Type: MsoControlType.msoControlButton, Before: 13);
            //    CellEqualsSheetButton.FaceId = 2652;
            //    CellEqualsSheetButton.Caption = ExcelAnalyzer.Properties.Resources.EqualsSheet_Button_Label;


            //    //    'CellListButton = .Add(Type:=Microsoft.Office.Core.MsoControlType.msoControlButton, Before:=14)
            //    //    'With CellListButton
            //    //    '    .FaceId = 162
            //    //    '    .Caption = My.Resources.List_Button_Label
            //    //    'End With

            //    //    CellSetViewButton = .Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 15)
            //    //    With CellSetViewButton
            //    //        .FaceId = 25
            //    //        .Caption = "Закрепить ячейку для списка значений"
            //    //        .BeginGroup = True
            //    //    End With

            //    //    CellSetIncrease1Button = .Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 16)
            //    //    With CellSetIncrease1Button
            //    //        .FaceId = 422
            //    //        .Caption = "Закрепить ячейку для анализа прироста (текущий период)"
            //    //        .BeginGroup = True
            //    //    End With

            //    //    CellSetIncrease2Button = .Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 17)
            //    //    With CellSetIncrease2Button
            //    //        .FaceId = 422
            //    //        .Caption = "Закрепить ячейку для анализа прироста (АППГ)"
            //    //    End With

            //    //    CellSetProportion1Button = .Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 18)
            //    //    With CellSetProportion1Button
            //    //        .FaceId = 396
            //    //        .Caption = "Закрепить ячейку для анализа удельного веса (целое)"
            //    //        .BeginGroup = True
            //    //    End With

            //    //    CellSetProportion2Button = .Add(Type:= Microsoft.Office.Core.MsoControlType.msoControlButton, Before:= 19)
            //    //    With CellSetProportion2Button
            //    //        .FaceId = 396
            //    //        .Caption = "Закрепить ячейку для анализа удельного веса (часть)"
            //    //    End With
            //    //End With
            //    this._application.CommandBars[this._application.CommandBars["Cell"].Index + 3].Protection = MsoBarProtection.msoBarNoCustomize;

        }



        private void WorkbookListBox_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            Controls.WorkbookBox listbox = (Controls.WorkbookBox) sender;

            if (listbox != this.ListValues_WorkbookBox 
                && e.ColumnIndex < this.ListValues_WorkbookBox.Columns.Count
                && this.ListValues_WorkbookBox.Columns[e.ColumnIndex].Width != listbox.Columns[e.ColumnIndex].Width)
            { this.ListValues_WorkbookBox.Columns[e.ColumnIndex].Width = listbox.Columns[e.ColumnIndex].Width; }

            if (listbox != this.ListIncreases_WorkbookBox 
                && e.ColumnIndex < this.ListIncreases_WorkbookBox.Columns.Count
                && this.ListIncreases_WorkbookBox.Columns[e.ColumnIndex].Width != listbox.Columns[e.ColumnIndex].Width)
            { this.ListIncreases_WorkbookBox.Columns[e.ColumnIndex].Width = listbox.Columns[e.ColumnIndex].Width; }

            if (listbox != this.ListProportions_WorkbookBox 
                && e.ColumnIndex < this.ListProportions_WorkbookBox.Columns.Count
                && this.ListProportions_WorkbookBox.Columns[e.ColumnIndex].Width != listbox.Columns[e.ColumnIndex].Width)
            { this.ListProportions_WorkbookBox.Columns[e.ColumnIndex].Width = listbox.Columns[e.ColumnIndex].Width; }

            if (listbox != this.ListExpressions_WorkbookBox 
                && e.ColumnIndex < this.ListExpressions_WorkbookBox.Columns.Count
                && this.ListExpressions_WorkbookBox.Columns[e.ColumnIndex].Width != listbox.Columns[e.ColumnIndex].Width)
            { this.ListExpressions_WorkbookBox.Columns[e.ColumnIndex].Width = listbox.Columns[e.ColumnIndex].Width; }
        }
    }
}
