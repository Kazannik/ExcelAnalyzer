﻿using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ExcelAnalyzer.Controls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripCheckBox : ToolStripControlHost
    {
        public ToolStripCheckBox():base(new CheckBox())
        {
            CheckBoxControl.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            CheckBoxControl.CheckStateChanged += new EventHandler(CheckBox_CheckStateChanged);
        }

        public CheckBox CheckBoxControl
        {
            get { return (CheckBox)Control; }
        }

        #region CheckedChanged

        public bool Checked
        {
            get { return CheckBoxControl.Checked; }
            set { CheckBoxControl.Checked = value; }
        }
        
        public event EventHandler CheckedChanged;

        public void DoCheckedChanged()
        {
            //...

            OnCheckedChanged(new EventArgs());
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DoCheckedChanged();
        }

        #endregion

        #region CheckStateChanged

        public CheckState CheckState
        {
            get { return CheckBoxControl.CheckState; }
            set { CheckBoxControl.CheckState = value; }
        }

        public event EventHandler CheckStateChanged;

        public void DoCheckStateChanged()
        {
            //...

            OnCheckStateChanged(new EventArgs());
        }

        protected virtual void OnCheckStateChanged(EventArgs e)
        {
            CheckStateChanged?.Invoke(this, e);
        }

        private void CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            DoCheckStateChanged();
        }

        #endregion
    }
}
