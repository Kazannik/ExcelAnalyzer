Imports ExcelAnalyzer.Expressions

Public Class Form1
    'Private expression As ArithmeticExpression
    'Private expression As LogicExpression
    Private expression As BooleanExpression

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles _
        ExpressionTextBox.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged

        Try
            'expression = ArithmeticExpression.Create(text:=Me.ExpressionTextBox.Text, cellpattern:="\d{1,4}\x5c\d{1,4}")
            'expression = LogicExpression.Create(text:=Me.ExpressionTextBox.Text, cellpattern:="\d{1,4}\x5c\d{1,4}")
            expression = BooleanExpression.Create(text:=Me.ExpressionTextBox.Text, cellpattern:="\d{1,4}\x5c\d{1,4}")

            If expression.Contains("1\1") Then
                expression.Item("1\1").Format = TextBox3.Text
                Dim v As Decimal = 0
                Decimal.TryParse(TextBox2.Text, v)
                expression.Item("1\1").SetValue(v)
            End If

            Me.ValueLabel.Text = expression.Value
            Me.FormulaLabel.Text = expression.Formula
            Me.LiteFormulaLabel.Text = expression.ToString("0.00")
            Me.ErrorLabel.Text = expression.IsError.ToString

        Catch ex As Exception
            Me.ValueLabel.Text = "Ошибка! " & ex.Message
        End Try

    End Sub


End Class
