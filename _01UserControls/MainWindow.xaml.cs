using System.Windows;
using _01UserControls.Views;

namespace _01UserControls;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //instanziiere das benutzerdefinierte Benutzersteuerelement
        var redControl = new RedBoxControl();
        //setze dieses als Content des Maincontents um es in die Shell (MainWindow) hineinzuholen
        MainContent.Content = redControl;
    }

    private void RedMenuItem_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new RedBoxControl();
    }

    private void BlueMenuItem_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new BlueBoxControl();
    }
}