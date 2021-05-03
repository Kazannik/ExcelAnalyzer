﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ExcelAnalyzer.Controls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripNumericUpDown: ToolStripControlHost
    {
        public ToolStripNumericUpDown():base(new NumericUpDown())
        {
            this.NumericUpDownControl.ValueChanged += new System.EventHandler(NumericUpDown_ValueChanged);
        }

        public NumericUpDown NumericUpDownControl
        {
            get { return (NumericUpDown)base.Control; }
        }

        #region ValueChanged

        public decimal Value
        {
            get { return this.NumericUpDownControl.Value; }
            set { this.NumericUpDownControl.Value = value; }
        }

        public event EventHandler ValueChanged;

        public void DoValueChanged()
        {
            //...

            this.OnValueChanged(new EventArgs());
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler ValueChangedEvent = ValueChanged;
            if (ValueChangedEvent != null)
            {
                ValueChangedEvent(this, e);
            }
        }

        private void NumericUpDown_ValueChanged(Object sender, EventArgs e)
        {
            this.DoValueChanged();
        }

        #endregion
    }
}
