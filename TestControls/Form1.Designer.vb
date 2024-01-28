<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ExpressionTextBox = New System.Windows.Forms.TextBox()
        Me.ValueLabel = New System.Windows.Forms.Label()
        Me.FormulaLabel = New System.Windows.Forms.Label()
        Me.ErrorLabel = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.LiteFormulaLabel = New System.Windows.Forms.Label()
        Me.PeriodBox1 = New ExcelAnalyzer.Controls.PeriodBox()
        Me.PeriodPicker1 = New ExcelAnalyzer.Controls.PeriodPicker()
        Me.SuspendLayout()
        '
        'ExpressionTextBox
        '
        Me.ExpressionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpressionTextBox.Location = New System.Drawing.Point(13, 172)
        Me.ExpressionTextBox.Name = "ExpressionTextBox"
        Me.ExpressionTextBox.Size = New System.Drawing.Size(259, 20)
        Me.ExpressionTextBox.TabIndex = 1
        '
        'ValueLabel
        '
        Me.ValueLabel.AutoSize = True
        Me.ValueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ValueLabel.ForeColor = System.Drawing.Color.LimeGreen
        Me.ValueLabel.Location = New System.Drawing.Point(10, 195)
        Me.ValueLabel.Name = "ValueLabel"
        Me.ValueLabel.Size = New System.Drawing.Size(45, 13)
        Me.ValueLabel.TabIndex = 2
        Me.ValueLabel.Text = "Label1"
        '
        'FormulaLabel
        '
        Me.FormulaLabel.AutoSize = True
        Me.FormulaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormulaLabel.ForeColor = System.Drawing.Color.Blue
        Me.FormulaLabel.Location = New System.Drawing.Point(9, 215)
        Me.FormulaLabel.Name = "FormulaLabel"
        Me.FormulaLabel.Size = New System.Drawing.Size(39, 13)
        Me.FormulaLabel.TabIndex = 3
        Me.FormulaLabel.Text = "Label2"
        '
        'ErrorLabel
        '
        Me.ErrorLabel.AutoSize = True
        Me.ErrorLabel.ForeColor = System.Drawing.Color.Red
        Me.ErrorLabel.Location = New System.Drawing.Point(9, 260)
        Me.ErrorLabel.Name = "ErrorLabel"
        Me.ErrorLabel.Size = New System.Drawing.Size(39, 13)
        Me.ErrorLabel.TabIndex = 4
        Me.ErrorLabel.Text = "Label3"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 146)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(65, 20)
        Me.TextBox2.TabIndex = 5
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(83, 146)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(189, 20)
        Me.TextBox3.TabIndex = 6
        '
        'LiteFormulaLabel
        '
        Me.LiteFormulaLabel.AutoSize = True
        Me.LiteFormulaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LiteFormulaLabel.ForeColor = System.Drawing.Color.Blue
        Me.LiteFormulaLabel.Location = New System.Drawing.Point(12, 234)
        Me.LiteFormulaLabel.Name = "LiteFormulaLabel"
        Me.LiteFormulaLabel.Size = New System.Drawing.Size(39, 13)
        Me.LiteFormulaLabel.TabIndex = 7
        Me.LiteFormulaLabel.Text = "Label2"
        '
        'PeriodBox1
        '
        Me.PeriodBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PeriodBox1.Location = New System.Drawing.Point(12, 3)
        Me.PeriodBox1.Name = "PeriodBox1"
        Me.PeriodBox1.Size = New System.Drawing.Size(186, 120)
        Me.PeriodBox1.TabIndex = 0
        '
        'PeriodPicker1
        '
        Me.PeriodPicker1.DropDownHeight = 148
        Me.PeriodPicker1.DropDownWidth = 209
        Me.PeriodPicker1.FormattingEnabled = True
        Me.PeriodPicker1.IntegralHeight = False
        Me.PeriodPicker1.Location = New System.Drawing.Point(110, 215)
        Me.PeriodPicker1.Name = "PeriodPicker1"
        Me.PeriodPicker1.Size = New System.Drawing.Size(121, 21)
        Me.PeriodPicker1.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 296)
        Me.Controls.Add(Me.PeriodPicker1)
        Me.Controls.Add(Me.LiteFormulaLabel)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ErrorLabel)
        Me.Controls.Add(Me.FormulaLabel)
        Me.Controls.Add(Me.ValueLabel)
        Me.Controls.Add(Me.ExpressionTextBox)
        Me.Controls.Add(Me.PeriodBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PeriodBox1 As ExcelAnalyzer.Controls.PeriodBox
    Friend WithEvents ExpressionTextBox As TextBox
    Friend WithEvents ValueLabel As Label
    Friend WithEvents FormulaLabel As Label
    Friend WithEvents ErrorLabel As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents LiteFormulaLabel As Label
    Friend WithEvents PeriodPicker1 As ExcelAnalyzer.Controls.PeriodPicker
End Class
