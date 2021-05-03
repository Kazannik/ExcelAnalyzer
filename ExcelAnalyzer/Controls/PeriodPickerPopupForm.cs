using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAnalyzer.Controls
{
    public partial class PeriodPickerPopupForm : UserControl
    {
        public PeriodPickerPopupForm()
        {
            InitializeComponent();
        }

        private void PeriodPickerPopupForm_Resize(object sender, EventArgs e)
        {
            this.PopupMenu_PeriodBox.Location = new Point(0, 0);
            this.Size = this.PopupMenu_PeriodBox.Size;
        }

        #region Value

        public Arm.Period Value
        {
            get { return this.PopupMenu_PeriodBox.Value; }
            set { this.PopupMenu_PeriodBox.Value = value; }            
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

        #region Click

        private void PeriodBox_ButtonClick(object sender, EventArgs e)
        {
            this.OnButtonClick(new EventArgs());
        }

        public event EventHandler ButtonClick;

        protected virtual void OnButtonClick(EventArgs e)
        {
            EventHandler ButtonClickEvent = ButtonClick;
            if (ButtonClickEvent != null)
            {
                ButtonClickEvent(this, e);
            }
        }

        #endregion        
    }
}
