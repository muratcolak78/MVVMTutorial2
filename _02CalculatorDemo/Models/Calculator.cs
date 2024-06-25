namespace _02CalculatorDemo.Models;

class Calculator
{
    public double Number1 { get; set; }
    public double Number2 { get; set; }
    public double Result => Number1 + Number2;
}
