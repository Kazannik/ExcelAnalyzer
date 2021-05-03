using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ExcelAnalyzer.Controls.WorkbookListBox;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

namespace ExcelAnalyzer.Controls
{
    public partial class WorkbookBox : UserControl
    {
        public WorkbookBox()
        {
            InitializeComponent();
            if (Globals.ThisAddIn != null && Globals.ThisAddIn.Application != null)
            {
                Excel.Application application;
                application = Globals.ThisAddIn.Application;
                stdole.IPictureDisp img;
                Bitmap imgCopy;
                img = application.CommandBars.GetImageMso("Copy", 16, 16);
                imgCopy = Gdi32.ConvertPixelByPixel(img);
                this.Copy_Button.Image = imgCopy;
                this.Copy_Button.ImageTransparentColor = Color.White;
                this.EditCopy_ToolStripMenuItem.Image = imgCopy;
                this.EditCopy_ToolStripMenuItem.ImageTransparentColor = Color.White;
            }

            this.HideNull_ToolStripCheckBox.CheckedChanged += new EventHandler(HideNull_CheckedChanged);
            this.NumberOfDecimal_ToolStripNumericUpDown.ValueChanged += new System.EventHandler(NumberOfDecimal_ValueChanged);
            this.Main_WorkbookListBox.BringToFront();
            this.DoExpressionChanged();
            this.DoNumberOfDecimalChanged();
        }

        public ListView.ColumnHeaderCollection Columns
        {
            get { return this.Main_WorkbookListBox.Columns; }
        }

        #region Expression

        public WorkbookListBox.ExpressionType Expression
        {
            get { return this.Main_WorkbookListBox.Expression; }
            set {this.Main_WorkbookListBox.Expression=value; }
        }
        
        public event EventHandler<WorkbookListBoxExpressionEventArgs> ExpressionChanged;

        public void DoExpressionChanged()
        {
            this.Main_ToolStrip.Items.Clear();
            switch (this.Expression)
            {
                case ExpressionType.Value:
                    InitializeControl(false);
                    break;
                case ExpressionType.Increase:
                    InitializeControl(true);
                    break;
                case ExpressionType.Proportion:
                    InitializeControl(true);
                    break;
                default:
                    InitializeControl(true);
                    break;
            }
            OnExpressionChanged(new WorkbookListBoxExpressionEventArgs(this.Main_WorkbookListBox.Expression));
        }


        private void InitializeControl(bool several)
        {
            if (Globals.ThisAddIn != null && Globals.ThisAddIn.Application != null)
            {
                Excel.Application application;
                application = Globals.ThisAddIn.Application;

                stdole.IPictureDisp img;
                Bitmap imgSelectCell, imgLock, imgShapeLeftArrow, imgShapeUpArrow, imgShapeDownArrow, imgShapeRightArrow;
                img = application.CommandBars.GetImageMso("SelectedTaskGoTo", 16, 16);
                imgSelectCell = Gdi32.ConvertPixelByPixel(img);
                img = application.CommandBars.GetImageMso("Lock", 16, 16);
                imgLock = Gdi32.ConvertPixelByPixel(img);
                img = application.CommandBars.GetImageMso("ShapeLeftArrow", 16, 16);
                imgShapeLeftArrow = Gdi32.ConvertPixelByPixel(img);
                img = application.CommandBars.GetImageMso("ShapeUpArrow", 16, 16);
                imgShapeUpArrow = Gdi32.ConvertPixelByPixel(img);
                img = application.CommandBars.GetImageMso("ShapeDownArrow", 16, 16);
                imgShapeDownArrow = Gdi32.ConvertPixelByPixel(img);
                img = application.CommandBars.GetImageMso("ShapeRightArrow", 16, 16);
                imgShapeRightArrow = Gdi32.ConvertPixelByPixel(img);

                ToolStripSeparator separator;

                ToolStripButton button = new ToolStripButton();
                button.Name = "FirstCellPosition_Button";
                button.Text = "Перейти к анализируемой ячейке";
                button.DisplayStyle = ToolStripItemDisplayStyle.Image;
                button.Image = imgSelectCell;
                this.Main_ToolStrip.Items.Add(button);

                ToolStripTextBox textbox = new ToolStripTextBox();
                textbox.Name = "FirstCell_TextBox";
                textbox.Text = "#Text";
                textbox.ReadOnly = true;
                textbox.AutoSize = false;
                textbox.Width = 40;
                this.Main_ToolStrip.Items.Add(textbox);

                button = new ToolStripButton();
                button.Name = "FirstCellLock_Button";
                button.Text = "Заблокировать ячейку";
                button.DisplayStyle = ToolStripItemDisplayStyle.Image;
                button.Image = imgLock;
                this.Main_ToolStrip.Items.Add(button);

                if (several)
                {
                    separator = new ToolStripSeparator();
                    this.Main_ToolStrip.Items.Add(separator);

                    button = new ToolStripButton();
                    button.Name = "SecondCellPosition_Button";
                    button.Text = "Перейти к анализируемой ячейке";
                    button.DisplayStyle = ToolStripItemDisplayStyle.Image;
                    button.Image = imgSelectCell;
                    this.Main_ToolStrip.Items.Add(button);

                    textbox = new ToolStripTextBox();
                    textbox.Name = "SecondCell_TextBox";
                    textbox.Text = "#Text";
                    textbox.ReadOnly = true;
                    textbox.AutoSize = false;
                    textbox.Width = 40;
                    this.Main_ToolStrip.Items.Add(textbox);

                    button = new ToolStripButton();
                    button.Name = "SecondCellLock_Button";
                    button.Text = "Заблокировать ячейку";
                    button.DisplayStyle = ToolStripItemDisplayStyle.Image;
                    button.Image = imgLock;
                    this.Main_ToolStrip.Items.Add(button);
                }

                separator = new ToolStripSeparator();
                this.Main_ToolStrip.Items.Add(separator);

                button = new ToolStripButton();
                button.Name = "CellLeft_Button";
                button.Text = "Выбрать ячейку слева";
                button.DisplayStyle = ToolStripItemDisplayStyle.Image;
                button.Image = imgShapeLeftArrow;
                this.Main_ToolStrip.Items.Add(button);

                button = new ToolStripButton();
                button.Name = "CellRight_Button";
                button.Text = "Выбрать ячейку справа";
                button.DisplayStyle = ToolStripItemDisplayStyle.Image;
                button.Image = imgShapeRightArrow;
                this.Main_ToolStrip.Items.Add(button);

                button = new ToolStripButton();
                button.Name = "CellUp_Button";
                button.Text = "Выбрать ячейку сверху";
                button.DisplayStyle = ToolStripItemDisplayStyle.Image;
                button.Image = imgShapeUpArrow;
                this.Main_ToolStrip.Items.Add(button);

                button = new ToolStripButton();
                button.Name = "CellDown_Button";
                button.Text = "Выбрать ячейку снизу";
                button.DisplayStyle = ToolStripItemDisplayStyle.Image;
                button.Image = imgShapeDownArrow;
                this.Main_ToolStrip.Items.Add(button);
            }
        }
        
        protected virtual void OnExpressionChanged(WorkbookListBoxExpressionEventArgs e)
        {
            EventHandler<WorkbookListBoxExpressionEventArgs> ExpressionChangedEvent = ExpressionChanged;
            if (ExpressionChangedEvent != null)
            {
                ExpressionChangedEvent(this, e);
            }
        }
        
        private void WorkbookListBox_ExpressionChanged(object sender, WorkbookListBoxExpressionEventArgs e)
        {
            this.DoExpressionChanged();
        }

        #endregion
        
        #region ColumnWidthChanged
        
        public event EventHandler<ColumnWidthChangedEventArgs> ColumnWidthChanged;

        public void DoColumnWidthChanged(int index)
        {
            OnColumnWidthChanged(new ColumnWidthChangedEventArgs(index));
        }

        protected virtual void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            EventHandler<ColumnWidthChangedEventArgs> ColumnWidthChangedEvent = ColumnWidthChanged;
            if (ColumnWidthChangedEvent != null)
            {
                ColumnWidthChangedEvent(this, e);
            }
        }

        private void WorkbookListBox_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            this.DoColumnWidthChanged(e.ColumnIndex);
        }

        #endregion

        #region HideNullValues

        public bool HideNullValues
        {
            get { return !this.HideNull_ToolStripCheckBox.Checked; }
            set { this.HideNull_ToolStripCheckBox.Checked = !value; }
        }

        public event EventHandler HideNullValuesChanged;

        public void DoHideNullValuesChanged()
        {
            OnHideNullValuesChanged(new EventArgs());
        }

        protected virtual void OnHideNullValuesChanged(EventArgs e)
        {
            EventHandler HideNullValuesChangedEvent = HideNullValuesChanged;
            if (HideNullValuesChangedEvent != null)
            {
                HideNullValuesChangedEvent(this, e);
            }
        }

        private void HideNull_CheckedChanged(Object sender, EventArgs e)
        {
            this.DoHideNullValuesChanged();
        }

        #endregion

        #region NumberOfDecimal

        public int NumberOfDecimal
        {
            get { return (int)this.NumberOfDecimal_ToolStripNumericUpDown.Value; }
            set { this.NumberOfDecimal_ToolStripNumericUpDown.Value =(decimal)value; }
        }

        public event EventHandler NumberOfDecimalChanged;

        public void DoNumberOfDecimalChanged()
        {
            OnNumberOfDecimalChanged(new EventArgs());
        }

        protected virtual void OnNumberOfDecimalChanged(EventArgs e)
        {
            EventHandler NumberOfDecimalChangedEvent = NumberOfDecimalChanged;
            if (NumberOfDecimalChangedEvent != null)
            {
                NumberOfDecimalChangedEvent(this, e);
            }
        }

        private void NumberOfDecimal_ValueChanged(Object sender, EventArgs e)
        {
            this.DoNumberOfDecimalChanged();
        }

        #endregion
        
        private void EditCopy_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditSelectFirst_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditSelectLast_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditSelectAll_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
