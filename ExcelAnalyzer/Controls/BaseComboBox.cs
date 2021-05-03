using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;

namespace ExcelAnalyzer.Controls
{
    [System.ComponentModel.DesignerCategory("code"),
        System.Drawing.ToolboxBitmapAttribute(typeof(ComboBox)),
        System.Runtime.InteropServices.ComVisible(false)]
     public abstract class BaseComboBox : ComboBox
    {

        protected StringFormat sfCode;
        protected StringFormat sfCaption;

        #region Initialize

        [System.Diagnostics.DebuggerNonUserCode()]
        public BaseComboBox (System.ComponentModel.IContainer container) :this()
        {
            // Required for Windows.Forms Class Composition Designer support
            if (container != null) { container.Add(this); }
        }

        // Component overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        { try
            {
                if (disposing && components != null)
                { components.Dispose(); }
            }
            finally
            { base.Dispose(disposing); }
        }

        // Required by the Component Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Component Designer
        // It can be modified using the Component Designer.
        // Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        public BaseComboBox():base()
        {
            sfCode =(StringFormat) StringFormat.GenericTypographic.Clone();
            sfCode.Alignment = StringAlignment.Center;
            sfCode.LineAlignment = StringAlignment.Center;
            sfCode.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap;

            sfCaption = (StringFormat)StringFormat.GenericTypographic.Clone();
            sfCaption.Alignment = StringAlignment.Near;
            sfCaption.LineAlignment = StringAlignment.Near;
            sfCaption.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap;


            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.DrawMode = DrawMode.OwnerDrawFixed;
            base.MaxDropDownItems = 20;
            base.DropDownWidth = 80;
            base.AutoSize = false;
            base.Width = 80;
            base.DropDownHeight = 80;
            base.Items.Clear();
        }

        #endregion


        #region Draw Item
        // Handle the DrawItem event for an owner-drawn List.
        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics graphics = e.Graphics;

            SizeF CodeSize = graphics.MeasureString("FFFFFFF", Font);
            ItemHeight =(int) CodeSize.Height + SystemInformation.BorderSize.Height * 4;
            DropDownHeight = ItemHeight * 8 + SystemInformation.BorderSize.Height * 4;



            Rectangle rectSelection = new Rectangle(e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 3, e.Bounds.Height - 1);
            Rectangle rectCode = new Rectangle(rectSelection.X + 2, rectSelection.Y + 2,(int) CodeSize.Width, rectSelection.Height - 4);
            Rectangle rectText = new Rectangle(rectCode.X + rectCode.Width + 6, rectCode.Y, e.Bounds.Width - rectCode.X - rectCode.Width - 6, rectCode.Height);

            Size TextSize = new Size(rectText.Width - SystemInformation.VerticalScrollBarWidth - 8, rectText.Height);


            Brush backCodeBrush, foreCodeBrush, backCaptionBrush, foreCaptionBrush;
            Pen borderPen;

            if (e.Index == -1)
            {
                backCodeBrush = SystemBrushes.Control;
                foreCodeBrush = SystemBrushes.ControlText;
                foreCaptionBrush = new SolidBrush(ForeColor);
                backCaptionBrush = new SolidBrush(BackColor);
                borderPen = new Pen(ForeColor);

                graphics.FillRectangle(backCaptionBrush, e.Bounds);
                graphics.FillRectangle(backCodeBrush, rectCode);
                graphics.DrawRectangle(borderPen, rectCode);
                graphics.DrawString("", Font, foreCodeBrush, rectCode, sfCode);
                graphics.DrawString("(не выбрано)", Font, foreCaptionBrush, rectText, sfCaption);
                return;
             }

            if (base.Items.Count <= e.Index) return;
            int itemCode = this[e.Index].Code;
            string itemCodeString = itemCode.ToString();
            string itemCaptionString = this[e.Index].Text.Trim();
            if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
            {
                backCodeBrush = new SolidBrush(BackColor);
                foreCodeBrush = new SolidBrush(ForeColor);
                foreCaptionBrush = new SolidBrush(ForeColor);
                backCaptionBrush = new SolidBrush(BackColor);
                borderPen = new Pen(ForeColor);
            }
            else
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {                  
                    backCodeBrush = new LinearGradientBrush(rectCode, Color.FromArgb(249, 249, 249), Color.FromArgb(241, 241, 241), LinearGradientMode.Vertical);
                    foreCodeBrush = new SolidBrush(Color.FromArgb(0, 102, 204));
                    backCaptionBrush = System.Drawing.SystemBrushes.Highlight;
                    foreCaptionBrush = new SolidBrush(Color.FromArgb(0, 102, 204)); 
                    borderPen = new Pen( Color.FromArgb(0, 102, 204),1); 
                }
                else
                {
                    backCodeBrush = new SolidBrush(BackColor);
                    foreCodeBrush = new SolidBrush(ForeColor);
                    backCaptionBrush = new SolidBrush(BackColor);
                    foreCaptionBrush = new SolidBrush(ForeColor);
                    borderPen = new Pen(ForeColor, 1);
                }
            }
            graphics.FillRectangle(backCaptionBrush, e.Bounds);
            graphics.FillRectangle(backCodeBrush, rectCode);
            graphics.DrawRectangle(borderPen, rectCode);
            graphics.DrawString(itemCodeString, Font, foreCodeBrush, rectCode, sfCode);
            graphics.DrawString(itemCaptionString, Font, foreCaptionBrush, rectText, sfCaption);
        }
        #endregion

        [ReadOnly(true)]
        public IComboBoxItem this[int index]
        {
            get
            {
                return (IComboBoxItem)base.Items[index: index];               
            }
        }

        [ReadOnly(true)]
        public new ComboBoxStyle DropDownStyle
        {
            get { return base.DropDownStyle; }
        }

        protected void Clear()
        {
            base.Items.Clear();
        }

        protected void Insert(int index, IComboBoxItem item)
        {
            base.Items.Insert(index, item);
        }

        protected void Remove(IComboBoxItem value)
        {
            base.Items.Remove(value);
        }
        protected void RemoveAt(int index)
        {
            base.Items.RemoveAt(index);
        }
        public int Add(IComboBoxItem item)
        {
            foreach (IComboBoxItem i in base.Items)
            {
                if (i.Code == item.Code)
                {
                    throw new ArgumentException("Элемент с кодом [" + item.Code.ToString() + "] ранее добавлен в коллекцию.", "item.Code");
                }
            }
            return base.Items.Add(item);
        }

        public abstract int Add(int code, string text);

        public interface IComboBoxItem
        {
            int Code { get; }
            string Text { get; }
        }
    }
}
