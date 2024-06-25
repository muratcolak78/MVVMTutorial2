
using _02CalculatorDemo.Models;
using System.Windows.Controls;

namespace _02CalculatorDemo.Views;

public partial class _01CalculatorControl : UserControl
{
    Calculator _calculator = new();
    public _01CalculatorControl()
    {
        InitializeComponent();
    }

    private void Operand1Box_TextChanged(object sender, TextChangedEventArgs e)
    {
        _calculator.Number1 = Double.Parse(Operand1Box.Text);
        UpdateResultBlock();
    }

    private void Operand2Box_TextChanged(object sender, TextChangedEventArgs e)
    {
        _calculator.Number2 = Double.Parse(Operand2Box.Text);
        UpdateResultBlock();
    }

    private void UpdateResultBlock()
    {
        if (ResultTextBlock is null)
            return;
        ResultTextBlock.Text = _calculator.Result.ToString();
    }
}
