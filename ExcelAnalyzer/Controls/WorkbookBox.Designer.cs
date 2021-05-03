namespace ExcelAnalyzer.Controls
{
    partial class WorkbookBox
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.Edit_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditCopy_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditSelectFirst_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSelectLast_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditSelectAll_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.Main_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ItemsCount_ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Other_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.Copy_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.HideNull_ToolStripCheckBox = new ExcelAnalyzer.Controls.ToolStripCheckBox();
            this.NumberOfDecimal_ToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.NumberOfDecimal_ToolStripNumericUpDown = new ExcelAnalyzer.Controls.ToolStripNumericUpDown();
            this.Main_WorkbookListBox = new ExcelAnalyzer.Controls.WorkbookListBox();
            this.Edit_ContextMenuStrip.SuspendLayout();
            this.Main_StatusStrip.SuspendLayout();
            this.Other_ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Edit_ContextMenuStrip
            // 
            this.Edit_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditCopy_ToolStripMenuItem,
            this.toolStripSeparator1,
            this.EditSelectFirst_ToolStripMenuItem,
            this.EditSelectLast_ToolStripMenuItem,
            this.toolStripSeparator2,
            this.EditSelectAll_ToolStripMenuItem});
            this.Edit_ContextMenuStrip.Name = "Main_ContextMenuStrip";
            this.Edit_ContextMenuStrip.Size = new System.Drawing.Size(239, 104);
            this.Edit_ContextMenuStrip.Text = "Контекстное меню привка";
            // 
            // EditCopy_ToolStripMenuItem
            // 
            this.EditCopy_ToolStripMenuItem.Name = "EditCopy_ToolStripMenuItem";
            this.EditCopy_ToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.EditCopy_ToolStripMenuItem.Text = "Копировать";
            this.EditCopy_ToolStripMenuItem.Click += new System.EventHandler(this.EditCopy_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // EditSelectFirst_ToolStripMenuItem
            // 
            this.EditSelectFirst_ToolStripMenuItem.Name = "EditSelectFirst_ToolStripMenuItem";
            this.EditSelectFirst_ToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.EditSelectFirst_ToolStripMenuItem.Text = "Выделить первые 10 строк";
            this.EditSelectFirst_ToolStripMenuItem.Click += new System.EventHandler(this.EditSelectFirst_ToolStripMenuItem_Click);
            // 
            // EditSelectLast_ToolStripMenuItem
            // 
            this.EditSelectLast_ToolStripMenuItem.Name = "EditSelectLast_ToolStripMenuItem";
            this.EditSelectLast_ToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.EditSelectLast_ToolStripMenuItem.Text = "Выделить последние 10 строк";
            this.EditSelectLast_ToolStripMenuItem.Click += new System.EventHandler(this.EditSelectLast_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(235, 6);
            // 
            // EditSelectAll_ToolStripMenuItem
            // 
            this.EditSelectAll_ToolStripMenuItem.Name = "EditSelectAll_ToolStripMenuItem";
            this.EditSelectAll_ToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.EditSelectAll_ToolStripMenuItem.Text = "Выделить все";
            this.EditSelectAll_ToolStripMenuItem.Click += new System.EventHandler(this.EditSelectAll_ToolStripMenuItem_Click);
            // 
            // Main_ToolStrip
            // 
            this.Main_ToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.Main_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Main_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Main_ToolStrip.Name = "Main_ToolStrip";
            this.Main_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Main_ToolStrip.Size = new System.Drawing.Size(380, 25);
            this.Main_ToolStrip.TabIndex = 0;
            this.Main_ToolStrip.Text = "Основная панель инструментов";
            // 
            // Main_StatusStrip
            // 
            this.Main_StatusStrip.BackColor = System.Drawing.Color.Transparent;
            this.Main_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemsCount_ToolStripStatusLabel});
            this.Main_StatusStrip.Location = new System.Drawing.Point(0, 258);
            this.Main_StatusStrip.Name = "Main_StatusStrip";
            this.Main_StatusStrip.Size = new System.Drawing.Size(380, 22);
            this.Main_StatusStrip.TabIndex = 1;
            this.Main_StatusStrip.Text = "Строка состояния";
            // 
            // ItemsCount_ToolStripStatusLabel
            // 
            this.ItemsCount_ToolStripStatusLabel.Name = "ItemsCount_ToolStripStatusLabel";
            this.ItemsCount_ToolStripStatusLabel.Size = new System.Drawing.Size(36, 17);
            this.ItemsCount_ToolStripStatusLabel.Text = "#Text";
            // 
            // Other_ToolStrip
            // 
            this.Other_ToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.Other_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Other_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Copy_Button,
            this.toolStripSeparator3,
            this.HideNull_ToolStripCheckBox,
            this.NumberOfDecimal_ToolStripLabel,
            this.NumberOfDecimal_ToolStripNumericUpDown});
            this.Other_ToolStrip.Location = new System.Drawing.Point(0, 25);
            this.Other_ToolStrip.Name = "Other_ToolStrip";
            this.Other_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Other_ToolStrip.Size = new System.Drawing.Size(380, 26);
            this.Other_ToolStrip.TabIndex = 3;
            this.Other_ToolStrip.Text = "Дополнительная панель инструментов";
            // 
            // Copy_Button
            // 
            this.Copy_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Copy_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Copy_Button.Name = "Copy_Button";
            this.Copy_Button.Size = new System.Drawing.Size(23, 23);
            this.Copy_Button.Text = "Копировать";
            this.Copy_Button.Click += new System.EventHandler(this.EditCopy_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // HideNull_ToolStripCheckBox
            // 
            this.HideNull_ToolStripCheckBox.Checked = false;
            this.HideNull_ToolStripCheckBox.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.HideNull_ToolStripCheckBox.Name = "HideNull_ToolStripCheckBox";
            this.HideNull_ToolStripCheckBox.Size = new System.Drawing.Size(183, 23);
            this.HideNull_ToolStripCheckBox.Text = "Скрывать нулевые значения";
            this.HideNull_ToolStripCheckBox.ToolTipText = "Скрывать нулевые значения";
            // 
            // NumberOfDecimal_ToolStripLabel
            // 
            this.NumberOfDecimal_ToolStripLabel.Name = "NumberOfDecimal_ToolStripLabel";
            this.NumberOfDecimal_ToolStripLabel.Size = new System.Drawing.Size(85, 23);
            this.NumberOfDecimal_ToolStripLabel.Text = "Число знаков:";
            this.NumberOfDecimal_ToolStripLabel.ToolTipText = "Число десятичных знаков после запятой";
            // 
            // NumberOfDecimal_ToolStripNumericUpDown
            // 
            this.NumberOfDecimal_ToolStripNumericUpDown.Name = "NumberOfDecimal_ToolStripNumericUpDown";
            this.NumberOfDecimal_ToolStripNumericUpDown.Size = new System.Drawing.Size(41, 23);
            this.NumberOfDecimal_ToolStripNumericUpDown.Text = "0";
            this.NumberOfDecimal_ToolStripNumericUpDown.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Main_WorkbookListBox
            // 
            this.Main_WorkbookListBox.ContextMenuStrip = this.Edit_ContextMenuStrip;
            this.Main_WorkbookListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_WorkbookListBox.Expression = ExcelAnalyzer.Controls.WorkbookListBox.ExpressionType.Value;
            this.Main_WorkbookListBox.Location = new System.Drawing.Point(0, 51);
            this.Main_WorkbookListBox.Name = "Main_WorkbookListBox";
            this.Main_WorkbookListBox.NullValues = false;
            this.Main_WorkbookListBox.NumberOfDecimal = 0;
            this.Main_WorkbookListBox.Size = new System.Drawing.Size(380, 207);
            this.Main_WorkbookListBox.TabIndex = 2;
            this.Main_WorkbookListBox.UseCompatibleStateImageBehavior = false;
            this.Main_WorkbookListBox.VirtualMode = true;
            this.Main_WorkbookListBox.ExpressionChanged += new System.EventHandler<ExcelAnalyzer.Controls.WorkbookListBoxExpressionEventArgs>(this.WorkbookListBox_ExpressionChanged);
            this.Main_WorkbookListBox.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.WorkbookListBox_ColumnWidthChanged);
            // 
            // WorkbookBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Main_WorkbookListBox);
            this.Controls.Add(this.Other_ToolStrip);
            this.Controls.Add(this.Main_StatusStrip);
            this.Controls.Add(this.Main_ToolStrip);
            this.Name = "WorkbookBox";
            this.Size = new System.Drawing.Size(380, 280);
            this.Edit_ContextMenuStrip.ResumeLayout(false);
            this.Main_StatusStrip.ResumeLayout(false);
            this.Main_StatusStrip.PerformLayout();
            this.Other_ToolStrip.ResumeLayout(false);
            this.Other_ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Main_ToolStrip;
        private System.Windows.Forms.StatusStrip Main_StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ItemsCount_ToolStripStatusLabel;
        private WorkbookListBox Main_WorkbookListBox;
        private System.Windows.Forms.ToolStrip Other_ToolStrip;
        private ToolStripCheckBox HideNull_ToolStripCheckBox;
        private System.Windows.Forms.ToolStripLabel NumberOfDecimal_ToolStripLabel;
        private ToolStripNumericUpDown NumberOfDecimal_ToolStripNumericUpDown;
        private System.Windows.Forms.ContextMenuStrip Edit_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditCopy_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem EditSelectFirst_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditSelectLast_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem EditSelectAll_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton Copy_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
