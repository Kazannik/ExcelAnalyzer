namespace Controls.TableBox
{
    partial class TableBox
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.caret_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // caret_timer
            // 
            this.caret_timer.Interval = 300;
            // 
            // TableBox
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TableBox_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer caret_timer;
    }
}
