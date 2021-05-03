using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

namespace ExcelAnalyzer.Controls
{
    public partial class WorkbookListBox : ListView
    {
        

        protected ExpressionType _expression;
        protected int _columnIndex;
        protected SortType _sort;
        protected bool _NullValues;
        protected int _NumberOfDecimal;

        private List<WorkbookListBoxItem> cache;

        protected  ColumnHeaderCollection _expressioncolumns;

        public WorkbookListBox()
        {
            this.cache = new List<WorkbookListBoxItem>();
            this._expressioncolumns = new ColumnHeaderCollection(this);
            base.View = View.Details;

            this._columnIndex = 0;
            this._sort = SortType.Default;
            this._expression = ExpressionType.Value;
            this._NullValues = false;
            this._NumberOfDecimal = 0;
            InitializeComponent();
                        
            if (Globals.ThisAddIn !=null && Globals.ThisAddIn.Application != null)
            {
                Excel.Application application;
                application = Globals.ThisAddIn.Application;
                stdole.IPictureDisp img;
                Bitmap image;
                image = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                Workbook_ImageList.Images.Add("Null", image);
                img = application.CommandBars.GetImageMso("UpArrow2", 16, 16);
                image = Gdi32.ConvertPixelByPixel(img);
                Workbook_ImageList.Images.Add("Up", image);
                img = application.CommandBars.GetImageMso("DownArrow2", 16, 16);
                image = Gdi32.ConvertPixelByPixel(img);
                Workbook_ImageList.Images.Add("Down", image);
            }

            this.DoExpressionChanged();
            this.DoNullValuesChanged();
            this.DoNumberOfDecimalChanged();
       }

        private void WorkbookListBox_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (base.Columns[e.ColumnIndex].Text == ExcelAnalyzerConstants.clnWorksheet)
            {
                ExcelAnalyzer.Properties.Settings.Default.WorksheetLabelWidth = base.Columns[e.ColumnIndex].Width;
                ExcelAnalyzer.Properties.Settings.Default.Save();
            }
            else if (base.Columns[e.ColumnIndex].Text == ExcelAnalyzerConstants.clnDescription)
            {
                ExcelAnalyzer.Properties.Settings.Default.WorksheetDescriptionWidth = base.Columns[e.ColumnIndex].Width;
                ExcelAnalyzer.Properties.Settings.Default.Save();
            }
            else
            {
                switch (e.ColumnIndex)
                {
                    case 1:
                        ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn01Width = base.Columns[e.ColumnIndex].Width;
                        break;
                    case 2:
                        ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn02Width = base.Columns[e.ColumnIndex].Width;
                        break;
                    case 3:
                        ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn03Width = base.Columns[e.ColumnIndex].Width;
                        break;
                    case 4:
                        ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn04Width = base.Columns[e.ColumnIndex].Width;
                        break;
                    case 5:
                        ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn05Width = base.Columns[e.ColumnIndex].Width;
                        break;
                    default:
                        ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn05Width = base.Columns[e.ColumnIndex].Width;
                        break;
                }
                ExcelAnalyzer.Properties.Settings.Default.Save();
            }
        }

        #region Expression

        public ExpressionType Expression
        {
            get { return this._expression; }
            set
            {
                if (this._expression != value)
                {
                    this._expression = value;
                    this.DoExpressionChanged();
                }
            }
        }
        
        public enum ExpressionType
        {
            /// <summary>
            /// Значение.
            /// </summary>
            Value =0,
            /// <summary>
            /// Прирост.
            /// </summary>
            Increase=1,
            /// <summary>
            /// Удельный вес.
            /// </summary>
            Proportion=2,
            /// <summary>
            /// Выражение.
            /// </summary>
            Expression=3
        }
        
        public event EventHandler<WorkbookListBoxExpressionEventArgs> ExpressionChanged;

        public void DoExpressionChanged()
        {
            switch (this._expression)
            {
                case ExpressionType.Value:
                    InitializeColumns(new string[] { ExcelAnalyzerConstants.clnWorksheet,
                        ExcelAnalyzerConstants.clnValue });
                    break;
                case ExpressionType.Increase:
                    InitializeColumns(new string[] { ExcelAnalyzerConstants.clnWorksheet,
                        "Текущее значение", "АППГ", "+/-", "+/- %",
                        ExcelAnalyzerConstants.clnDescription });
                    break;
                case ExpressionType.Proportion:
                    InitializeColumns(new string[] { ExcelAnalyzerConstants.clnWorksheet,
                        "Целое", "Часть", "%",
                        ExcelAnalyzerConstants.clnDescription });
                    break;
                default:
                    InitializeColumns(new string[] { ExcelAnalyzerConstants.clnWorksheet,
                        ExcelAnalyzerConstants.clnValue,
                    ExcelAnalyzerConstants.clnDescription });
                    break;
            }
            for (int i = 0; i < base.Columns.Count; i++)
            {
                if (base.Columns[i].Text == ExcelAnalyzerConstants.clnWorksheet)
                {
                    base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetLabelWidth;
                }
                else if (base.Columns[i].Text == ExcelAnalyzerConstants.clnDescription)
                {
                    base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetDescriptionWidth;
                }
                else
                {
                    switch (i)
                    {
                        case 1:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn01Width;
                            break;
                        case 2:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn02Width;
                            break;
                        case 3:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn03Width;
                            break;
                        case 4:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn04Width;
                            break;
                        case 5:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn05Width;
                            break;
                        default:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn05Width;
                            break;
                    }                    
                }
            }
            this.OnExpressionChanged(new WorkbookListBoxExpressionEventArgs(this._expression));
        }


        private void InitializeColumns(string[] columns)
        {
            int ColumnCount = columns.Length;
            while (base.Columns.Count > ColumnCount)
            {
                base.Columns.RemoveAt(ColumnCount);
            }

            for (int i = 0; i < ColumnCount; i++)
            {
                if (i < base.Columns.Count)
                {
                    base.Columns[i].Text = columns[i];
                    base.Columns[i].ImageKey = "Null";
                }
                else
                {
                    ColumnHeader column = base.Columns.Add(columns[i]);
                    column.ImageKey = "Null";
                };
            }
                        
            for (int i = 0; i < base.Columns.Count; i++)
            {
                if (base.Columns[i].Text == ExcelAnalyzerConstants.clnWorksheet)
                {
                    base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetLabelWidth;
                }
                else if (base.Columns[i].Text == ExcelAnalyzerConstants.clnDescription)
                {
                    base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetDescriptionWidth;
                }
                else
                {
                    switch (i)
                    {
                        case 1:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn01Width;
                            break;
                        case 2:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn02Width;
                            break;
                        case 3:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn03Width;
                            break;
                        case 4:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn04Width;
                            break;
                        case 5:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn05Width;
                            break;
                        default:
                            base.Columns[i].Width = ExcelAnalyzer.Properties.Settings.Default.WorksheetColumn05Width;
                            break;
                    }
                }
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


        protected virtual void OnExpressionChanged(WorkbookListBoxExpressionEventArgs e)
        {
            EventHandler<WorkbookListBoxExpressionEventArgs> ExpressionChangedEvent = ExpressionChanged;
            if (ExpressionChangedEvent != null)
            {
                ExpressionChangedEvent(this, e);
            }
        }

        #endregion

        #region NullValues

        public bool NullValues
        {
            get { return this._NullValues; }
            set
            {
                if (this._NullValues != value)
                {
                    this._NullValues = value;
                    this.DoNullValuesChanged();
                }
            }
        }

        public event EventHandler NullValuesChanged;

        public void DoNullValuesChanged()
        {
            //...

            this.OnNullValuesChanged(new EventArgs());
        }

        protected virtual void OnNullValuesChanged(EventArgs e)
        {
            EventHandler NullValuesChangedEvent = NullValuesChanged;
            if (NullValuesChangedEvent != null)
            {
                NullValuesChangedEvent(this, e);
            }
        }

        #endregion

        #region NumberOfDecimal

        public int NumberOfDecimal
        {
            get { return this._NumberOfDecimal; }
            set
            {
                if (this._NumberOfDecimal != value)
                {
                    this._NumberOfDecimal = value;
                    this.DoNumberOfDecimalChanged();
                }
            }
        }

        public event EventHandler NumberOfDecimalChanged;

        public void DoNumberOfDecimalChanged()
        {
            //...

            this.OnNumberOfDecimalChanged(new EventArgs());
        }

        protected virtual void OnNumberOfDecimalChanged(EventArgs e)
        {
            EventHandler NumberOfDecimalEvent = NumberOfDecimalChanged;
            if (NumberOfDecimalEvent != null)
            {
                NumberOfDecimalEvent(this, e);
            }
        }

        #endregion

        #region Sort
                
        protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e)
        {
            if (this._columnIndex != e.Column)
            {
                this._columnIndex = e.Column;
                if (this._columnIndex == 0)
                { this._sort = SortType.Default; }
                else { this._sort = SortType.Forward; }
            }
            else
            {
                if (this._columnIndex == 0)
                {
                    switch (this._sort)
                    {
                        case SortType.Default:
                            this._sort = SortType.Forward;
                            break;
                        case SortType.Forward:
                            this._sort = SortType.Reverse;
                            break;
                        case SortType.Reverse:
                            this._sort = SortType.Default;
                            break;
                        default:
                            this._sort = SortType.Default;
                            break;
                    }
                }
                else
                {
                    switch (this._sort)
                    {
                        case SortType.Default:
                            this._sort = SortType.Forward;
                            break;
                        case SortType.Forward:
                            this._sort = SortType.Reverse;
                            break;
                        case SortType.Reverse:
                            this._sort = SortType.Forward;
                            break;
                        default:
                            this._sort = SortType.Forward;
                            break;
                    }
                }
            }
            this.DoSortChanged(this._columnIndex, this._sort);
        }
                
        public enum SortType
        {
            /// <summary>
            /// Сортировка по умолчанию.
            /// </summary>
            Default = 0,
            /// <summary>
            /// Сортировка по возрастанию.
            /// </summary>
            Forward = 1,
            /// <summary>
            /// Сортировка по убыванию.
            /// </summary>
            Reverse = 2
        }

        public event EventHandler<WorkbookListBoxSortEventArgs> SortChanged;

        public void DoSortChanged(int columnIndex, SortType sort)
        {
            this.BeginUpdate();
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (columnIndex == i)
                {
                    switch (sort)
                    {
                        case SortType.Default:
                            this.Columns[i].ImageKey = "Null";
                            break;
                        case SortType.Forward:
                            this.Columns[i].ImageKey = "Down";
                            break;
                        case SortType.Reverse:
                            this.Columns[i].ImageKey = "Up";
                            break;
                        default:
                            this.Columns[i].ImageKey = "Null";
                            break;
                    }
                }
                else
                {
                    this.Columns[i].ImageKey = "Null";
                }
            }



            //        Me._StatWorkbook.ViewSortColumnIndex = e.Column
            //        For i As Integer = 0 To Me.View_ListView.Columns.Count - 1
            //            If e.Column<> i Then Me.View_ListView.Columns.Item(i).ImageIndex = 3
            //        Next
            //        If e.Column = 0 Then
            //            If Me._StatWorkbook.ViewCaptionSort = StatWorkbook.SortType.Default Then
            //                Me._StatWorkbook.ViewCaptionSort = StatWorkbook.SortType.Forward
            //                Me.View_ListView.Columns.Item(0).ImageIndex = 2
            //            ElseIf Me._StatWorkbook.ViewCaptionSort = StatWorkbook.SortType.Forward Then
            //                Me._StatWorkbook.ViewCaptionSort = StatWorkbook.SortType.Reverse
            //                Me.View_ListView.Columns.Item(0).ImageIndex = 1
            //            Else
            //                Me._StatWorkbook.ViewCaptionSort = StatWorkbook.SortType.Default
            //                Me.View_ListView.Columns.Item(0).ImageIndex = 3
            //            End If
            //            Me._StatWorkbook.ViewArraySort(New StatWorkbook.WorksheetComparer(Me._StatWorkbook.ViewCaptionSort, Me.SelectedWorkbook, StatWorkbook.WorksheetComparer.SortValueType.Caption))
            //        ElseIf e.Column > 0 Then
            //            If Me._StatWorkbook.ViewSortTypeColumn = StatWorkbook.SortType.Default Then
            //                Me._StatWorkbook.ViewSortTypeColumn = StatWorkbook.SortType.Forward
            //                Me.View_ListView.Columns.Item(Me._StatWorkbook.ViewSortColumnIndex).ImageIndex = 2
            //            ElseIf Me._StatWorkbook.ViewSortTypeColumn = StatWorkbook.SortType.Forward Then
            //                Me._StatWorkbook.ViewSortTypeColumn = StatWorkbook.SortType.Reverse
            //                Me.View_ListView.Columns.Item(Me._StatWorkbook.ViewSortColumnIndex).ImageIndex = 1
            //            Else
            //                Me._StatWorkbook.ViewSortTypeColumn = StatWorkbook.SortType.Forward
            //                Me.View_ListView.Columns.Item(Me._StatWorkbook.ViewSortColumnIndex).ImageIndex = 2
            //            End If
            //            If e.Column = 1 Then
            //                Me._StatWorkbook.ViewArraySort(New StatWorkbook.WorksheetComparer(Me._StatWorkbook.ViewSortTypeColumn, Me.SelectedWorkbook, StatWorkbook.WorksheetComparer.SortValueType.Value1))
            //            Else
            //                Me._StatWorkbook.ViewArraySort(New StatWorkbook.WorksheetComparer(Me._StatWorkbook.ViewSortTypeColumn, Me.SelectedWorkbook, StatWorkbook.WorksheetComparer.SortValueType.Caption))
            //            End If
            //        End If
            //        Me._StatWorkbook.ViewCacheClear()
            //        Me.View_ListView.Invalidate()
            //        For i As Integer = 0 To Me.View_ListView.Items.Count - 1
            //            If DirectCast(Me.View_ListView.Items(i), StatWorkbook.StatListViewItem).Worksheet Is Me.SelectedWorkbook.ActiveSheet Then
            //                Me.View_ListView.Items(i).EnsureVisible()
            //                Exit For
            //            End If
            //        Next
            this.EndUpdate();

            //...

            this.OnSortChanged(new WorkbookListBoxSortEventArgs(columnIndex, sort));
        }
        
        protected virtual void OnSortChanged(WorkbookListBoxSortEventArgs e)
        {
            EventHandler<WorkbookListBoxSortEventArgs> SortChangedEvent = SortChanged;
            if (SortChangedEvent != null)
            {
                SortChangedEvent(this, e);
            }
        }

        #endregion

        #region Virtual Mode
                
        protected override void OnRetrieveVirtualItem(System.Windows.Forms.RetrieveVirtualItemEventArgs e)
        {
            WorkbookListBoxItem item;
            if (this.cache.Contains(e.Item))
            {
                item = (WorkbookListBoxItem)e.Item;
            }
            else
            {
//                Dim WsValue As WorksheetValue
//                If IsNull Then
//                WsValue = Me.ViewArray(ItemIndex)
//            Else
//                WsValue = Me.ViewArray.Where(Function(p) p.IsNull = False)(ItemIndex)
//            End If
//            item = ViewListItem(WsValue, N)
//            Me._ViewCache.Add(ItemIndex, item)
//            Return item
        }

//            Dim item As ListViewItem = Me._StatWorkbook.ViewRetrieveVirtualItem(e.ItemIndex, Me.ViewDecimalCount_NumericUpDown.Value, Not Me.NotNullView_CheckBox.Checked)
//      If item Is Nothing Then
//        e.Item = New ListViewItem
//      Exit Sub
//End If
//        e.Item = item
//       If e.Item Is Nothing Then Exit Sub
//      If DirectCast(e.Item, StatWorkbook.StatListViewItem).Worksheet Is Me.SelectedWorkbook.ActiveSheet Then
//         e.Item.BackColor = StatAddIn.SelectedSheetColor
//    ElseIf DirectCast(e.Item, StatWorkbook.StatListViewItem).Parent Then
//       e.Item.BackColor = StatAddIn.SumSheetColor
//  Else
//      e.Item.BackColor = Me.View_ListView.BackColor
//  End If


        }

        protected override void OnCacheVirtualItems(System.Windows.Forms.CacheVirtualItemsEventArgs e)
        {
//            Me._StatWorkbook.ViewCacheVirtualItems(e.StartIndex, e.EndIndex, Me.ViewDecimalCount_NumericUpDown.Value, Not Me.NotNullView_CheckBox.Checked)

        }

        #endregion
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public new View View
        {
            get { return base.View; }
        }
    }

    public class WorkbookListBoxExpressionEventArgs : EventArgs
    {
        public WorkbookListBoxExpressionEventArgs(WorkbookListBox.ExpressionType args)
        {
            Expression = args;
        }
        public WorkbookListBox.ExpressionType Expression { get; }
    }

    public class WorkbookListBoxSortEventArgs : EventArgs
    {
        public WorkbookListBoxSortEventArgs(int columnIndex, WorkbookListBox.SortType args)
        {
            ColumnIndex = columnIndex;
            Sort = args;
        }
        public int ColumnIndex { get; }
        public WorkbookListBox.SortType Sort { get; }
    }
}
