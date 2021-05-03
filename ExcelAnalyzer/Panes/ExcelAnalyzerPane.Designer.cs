namespace ExcelAnalyzer.Panes
{
    partial class ExcelAnalyzerPane
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelAnalyzerPane));
            this.ExcelAnalyzer_TabControl = new System.Windows.Forms.TabControl();
            this.ListValues_TabPage = new System.Windows.Forms.TabPage();
            this.ListIncreases_TabPage = new System.Windows.Forms.TabPage();
            this.ListProportions_TabPage = new System.Windows.Forms.TabPage();
            this.ListExpressions_TabPage = new System.Windows.Forms.TabPage();
            this.ListValues_WorkbookBox = new Controls.WorkbookBox();
            this.ListIncreases_WorkbookBox = new Controls.WorkbookBox();
            this.ListProportions_WorkbookBox = new Controls.WorkbookBox();
            this.ListExpressions_WorkbookBox = new Controls.WorkbookBox();
            this.TabControl_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.ExcelAnalyzer_TabControl.SuspendLayout();
            this.ListValues_TabPage.SuspendLayout();
            this.ListIncreases_TabPage.SuspendLayout();
            this.ListProportions_TabPage.SuspendLayout();
            this.ListExpressions_TabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExcelAnalyzer_TabControl
            // 
            this.ExcelAnalyzer_TabControl.Controls.Add(this.ListValues_TabPage);
            this.ExcelAnalyzer_TabControl.Controls.Add(this.ListIncreases_TabPage);
            this.ExcelAnalyzer_TabControl.Controls.Add(this.ListProportions_TabPage);
            this.ExcelAnalyzer_TabControl.Controls.Add(this.ListExpressions_TabPage);
            this.ExcelAnalyzer_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExcelAnalyzer_TabControl.ImageList = this.TabControl_ImageList;
            this.ExcelAnalyzer_TabControl.Location = new System.Drawing.Point(0, 0);
            this.ExcelAnalyzer_TabControl.Name = "ExcelAnalyzer_TabControl";
            this.ExcelAnalyzer_TabControl.SelectedIndex = 0;
            this.ExcelAnalyzer_TabControl.Size = new System.Drawing.Size(263, 243);
            this.ExcelAnalyzer_TabControl.TabIndex = 0;
            // 
            // ListValues_TabPage
            // 
            this.ListValues_TabPage.Controls.Add(this.ListValues_WorkbookBox);
            this.ListValues_TabPage.ImageKey = "Detals";
            this.ListValues_TabPage.Location = new System.Drawing.Point(4, 23);
            this.ListValues_TabPage.Name = "ListValues_TabPage";
            this.ListValues_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ListValues_TabPage.Size = new System.Drawing.Size(255, 216);
            this.ListValues_TabPage.TabIndex = 0;
            this.ListValues_TabPage.Text = "#Text";
            this.ListValues_TabPage.UseVisualStyleBackColor = true;
            // 
            // ListIncreases_TabPage
            // 
            this.ListIncreases_TabPage.Controls.Add(this.ListIncreases_WorkbookBox);
            this.ListIncreases_TabPage.ImageKey = "Increase";
            this.ListIncreases_TabPage.Location = new System.Drawing.Point(4, 23);
            this.ListIncreases_TabPage.Name = "ListIncreases_TabPage";
            this.ListIncreases_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ListIncreases_TabPage.Size = new System.Drawing.Size(255, 216);
            this.ListIncreases_TabPage.TabIndex = 1;
            this.ListIncreases_TabPage.Text = "#Text";
            this.ListIncreases_TabPage.UseVisualStyleBackColor = true;
            // 
            // ListProportions_TabPage
            // 
            this.ListProportions_TabPage.Controls.Add(this.ListProportions_WorkbookBox);
            this.ListProportions_TabPage.ImageKey = "Proportion";
            this.ListProportions_TabPage.Location = new System.Drawing.Point(4, 23);
            this.ListProportions_TabPage.Name = "ListProportions_TabPage";
            this.ListProportions_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ListProportions_TabPage.Size = new System.Drawing.Size(255, 216);
            this.ListProportions_TabPage.TabIndex = 2;
            this.ListProportions_TabPage.Text = "#Text";
            this.ListProportions_TabPage.UseVisualStyleBackColor = true;
            // 
            // ListExpressions_TabPage
            // 
            this.ListExpressions_TabPage.Controls.Add(this.ListExpressions_WorkbookBox);
            this.ListExpressions_TabPage.ImageKey = "Function";
            this.ListExpressions_TabPage.Location = new System.Drawing.Point(4, 23);
            this.ListExpressions_TabPage.Name = "ListExpressions_TabPage";
            this.ListExpressions_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ListExpressions_TabPage.Size = new System.Drawing.Size(255, 216);
            this.ListExpressions_TabPage.TabIndex = 3;
            this.ListExpressions_TabPage.Text = "#Text";
            this.ListExpressions_TabPage.UseVisualStyleBackColor = true;
            // 
            // ListValues_WorkbookBox
            // 
            this.ListValues_WorkbookBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListValues_WorkbookBox.Expression = ExcelAnalyzer.Controls.WorkbookListBox.ExpressionType.Value;
            this.ListValues_WorkbookBox.HideNullValues = true;
            this.ListValues_WorkbookBox.Location = new System.Drawing.Point(3, 3);
            this.ListValues_WorkbookBox.Name = "ListValues_WorkbookBox";
            this.ListValues_WorkbookBox.NumberOfDecimal = 0;
            this.ListValues_WorkbookBox.Size = new System.Drawing.Size(249, 210);
            this.ListValues_WorkbookBox.TabIndex = 0;
            this.ListValues_WorkbookBox.ColumnWidthChanged += new System.EventHandler<System.Windows.Forms.ColumnWidthChangedEventArgs>(this.WorkbookListBox_ColumnWidthChanged);
            // 
            // ListIncreases_WorkbookBox
            // 
            this.ListIncreases_WorkbookBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListIncreases_WorkbookBox.Expression = ExcelAnalyzer.Controls.WorkbookListBox.ExpressionType.Increase;
            this.ListIncreases_WorkbookBox.HideNullValues = true;
            this.ListIncreases_WorkbookBox.Location = new System.Drawing.Point(3, 3);
            this.ListIncreases_WorkbookBox.Name = "ListIncreases_WorkbookBox";
            this.ListIncreases_WorkbookBox.NumberOfDecimal = 0;
            this.ListIncreases_WorkbookBox.Size = new System.Drawing.Size(249, 210);
            this.ListIncreases_WorkbookBox.TabIndex = 0;
            this.ListIncreases_WorkbookBox.ColumnWidthChanged += new System.EventHandler<System.Windows.Forms.ColumnWidthChangedEventArgs>(this.WorkbookListBox_ColumnWidthChanged);
            // 
            // ListProportions_WorkbookBox
            // 
            this.ListProportions_WorkbookBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListProportions_WorkbookBox.Expression = ExcelAnalyzer.Controls.WorkbookListBox.ExpressionType.Proportion;
            this.ListProportions_WorkbookBox.HideNullValues = true;
            this.ListProportions_WorkbookBox.Location = new System.Drawing.Point(3, 3);
            this.ListProportions_WorkbookBox.Name = "ListProportions_WorkbookBox";
            this.ListProportions_WorkbookBox.NumberOfDecimal = 0;
            this.ListProportions_WorkbookBox.Size = new System.Drawing.Size(249, 210);
            this.ListProportions_WorkbookBox.TabIndex = 0;
            this.ListProportions_WorkbookBox.ColumnWidthChanged += new System.EventHandler<System.Windows.Forms.ColumnWidthChangedEventArgs>(this.WorkbookListBox_ColumnWidthChanged);
            // 
            // ListExpressions_WorkbookBox
            // 
            this.ListExpressions_WorkbookBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListExpressions_WorkbookBox.Expression = ExcelAnalyzer.Controls.WorkbookListBox.ExpressionType.Expression;
            this.ListExpressions_WorkbookBox.HideNullValues = true;
            this.ListExpressions_WorkbookBox.Location = new System.Drawing.Point(3, 3);
            this.ListExpressions_WorkbookBox.Name = "ListExpressions_WorkbookBox";
            this.ListExpressions_WorkbookBox.NumberOfDecimal = 0;
            this.ListExpressions_WorkbookBox.Size = new System.Drawing.Size(249, 210);
            this.ListExpressions_WorkbookBox.TabIndex = 0;
            this.ListExpressions_WorkbookBox.ColumnWidthChanged += new System.EventHandler<System.Windows.Forms.ColumnWidthChangedEventArgs>(this.WorkbookListBox_ColumnWidthChanged);
            // 
            // TabControl_ImageList
            // 
            this.TabControl_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabControl_ImageList.ImageStream")));
            this.TabControl_ImageList.TransparentColor = System.Drawing.Color.White;
            this.TabControl_ImageList.Images.SetKeyName(0, "Detals");
            this.TabControl_ImageList.Images.SetKeyName(1, "Increase");
            this.TabControl_ImageList.Images.SetKeyName(2, "Proportion");
            this.TabControl_ImageList.Images.SetKeyName(3, "Function");
            // 
            // ExcelAnalyzerPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ExcelAnalyzer_TabControl);
            this.Name = "ExcelAnalyzerPane";
            this.Size = new System.Drawing.Size(263, 243);
            this.ExcelAnalyzer_TabControl.ResumeLayout(false);
            this.ListValues_TabPage.ResumeLayout(false);
            this.ListIncreases_TabPage.ResumeLayout(false);
            this.ListProportions_TabPage.ResumeLayout(false);
            this.ListExpressions_TabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ExcelAnalyzer_TabControl;
        private System.Windows.Forms.TabPage ListValues_TabPage;
        private System.Windows.Forms.TabPage ListIncreases_TabPage;
        private System.Windows.Forms.TabPage ListProportions_TabPage;
        private System.Windows.Forms.TabPage ListExpressions_TabPage;
        private Controls.WorkbookBox ListValues_WorkbookBox;
        private Controls.WorkbookBox ListIncreases_WorkbookBox;
        private Controls.WorkbookBox ListProportions_WorkbookBox;
        private Controls.WorkbookBox ListExpressions_WorkbookBox;
        private System.Windows.Forms.ImageList TabControl_ImageList;
    }
}
