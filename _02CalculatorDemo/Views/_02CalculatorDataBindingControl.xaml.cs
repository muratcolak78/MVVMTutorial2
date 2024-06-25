using _02CalculatorDemo.Models;
using System.ComponentModel;
using System.Windows.Controls;
namespace _02CalculatorDemo.Views;

public partial class _02CalculatorDataBindingControl : UserControl, INotifyPropertyChanged
{
    Calculator _calculator = new();

    public event PropertyChangedEventHandler? PropertyChanged; //EVENT
    public double Number1 //Datenquelle 1 => wird in einem Target/Ziel (TextBox1) angebunden
    {
        get => _calculator.Number1;
        set 
        {
            _calculator.Number1 = value;
            OnResultChanged();
        }
    }
    public void OnResultChanged()
    {
        if (PropertyChanged != null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Result))); //Löse das Event aus
        }
    }
    public double Number2
    {
        get => _calculator.Number2;
        set
        {
            _calculator.Number2 = value;
            OnResultChanged();
        }
    }
    public double Result => _calculator.Result;
   
  
    public string Title => "Version 2 mit DataBinding";  //ausführlich: public string Title { get { return "Version 2 mit DataBinding";} } 
    public _02CalculatorDataBindingControl()
    {
        InitializeComponent();
        //DataContext bestimmt den Ort, wo die Datenquellen (für die UI/Targets) sind
        DataContext = this; 
    }
}
