﻿namespace ExcelAnalyzer.Controls
{
    partial class WorkbookListBox
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
            this.Workbook_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // Workbook_ImageList
            // 
            this.Workbook_ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.Workbook_ImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.Workbook_ImageList.TransparentColor = System.Drawing.Color.White;
            // 
            // WorkbookListBox
            // 
            this.LargeImageList = this.Workbook_ImageList;
            this.SmallImageList = this.Workbook_ImageList;
            this.StateImageList = this.Workbook_ImageList;
            this.VirtualMode = true;
            this.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.WorkbookListBox_ColumnWidthChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList Workbook_ImageList;
    }
}
