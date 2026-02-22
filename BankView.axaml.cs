using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Calculus;

public partial class BankView : UserControl
{
    public BankView()
    {
        InitializeComponent();
    }
    
    private void menu(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Button button = (Button)sender;
        if(button.Name != null)
        {
            switch (button.Name)
            {
                case "Paymentorders":
                    Nav.Go(typeof(Payment_orders));
                    break;
            }
        }
    }
}