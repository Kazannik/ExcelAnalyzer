using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ExcelAnalyzer.Controls
{
    [System.ComponentModel.DesignerCategoryAttribute("Form")]
    [System.Drawing.ToolboxBitmapAttribute(typeof (ComboBox))]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class PeriodPicker: ComboBox
    {
        private ToolStripControlHost controlHost;
        private PeriodPickerPopupForm popupForm;
        private static ToolStripDropDown dropDown;

        public PeriodPicker()
        {
            popupForm = new PeriodPickerPopupForm();
            popupForm.BorderStyle = BorderStyle.None;
            controlHost = new ToolStripControlHost(popupForm);

            popupForm.ValueChanged += new System.EventHandler<ExcelAnalyzer.Arm.PeriodEventArgs>(this.PopupMenu_PeriodBox_ValueChanged);

            dropDown = new ToolStripDropDown();
            dropDown.Items.Add(controlHost);
            this.DropDownHeight = popupForm.Height;
            this.DropDownWidth = popupForm.Width;
            controlHost.Width = this.DropDownWidth;
            controlHost.Height = this.DropDownHeight;
        }

        #region Value

        public Arm.Period Value
        {
            get { return this.popupForm.Value; }
            set { this.popupForm.Value = value; }
        }

        private void PopupMenu_PeriodBox_ValueChanged(object sender, Arm.PeriodEventArgs e)
        {
            this.OnValueChanged(new Arm.PeriodEventArgs(e.Period));
        }

        public event EventHandler<Arm.PeriodEventArgs> ValueChanged;

        protected virtual void OnValueChanged(Arm.PeriodEventArgs e)
        {
            EventHandler<Arm.PeriodEventArgs> ValueChangedEvent = ValueChanged;
            if (ValueChangedEvent != null)
            {
                ValueChangedEvent(this, e);
            }
        }

        #endregion


        //Public ReadOnly Property PopupForm() As MonthPopupForm
        //    Get
        //        Return CType(controlHost.Control, MonthPopupForm)
        //    End Get
        //End Property

        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                controlHost.Width = this.DropDownWidth;
                controlHost.Height = this.DropDownHeight;

                dropDown.Show(this, 0, this.Height);
                //'   dropDown.Hide()
            }
        }

        private const int WM_USER = 0X400;
        private const int WM_REFLECT = WM_USER + 0X1C00;
        private const int WM_COMMAND = 0X111;
        private const int CBN_DROPDOWN = 0X7;

        public static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        public static int HIWORD(IntPtr n)
        {
            return HIWORD(unchecked((int)(long)n));
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_REFLECT + WM_COMMAND)
            {
                if (HIWORD(m.WParam) == CBN_DROPDOWN)
                {
                    this.ShowDropDown();
                    return;
            }
        }
        base.WndProc(ref m);
    }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
