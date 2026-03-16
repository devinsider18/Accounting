using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Accounting;

public partial class SalesView : UserControl
{
    public SalesView()
    {
        InitializeComponent();
    }

    private void menu(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Name != null)
        {
            switch (button.Name)
            {
                case "Invoices":
                    Nav.Go(typeof(Invoices));
                    break;
                case "Implementation":
                    Nav.Go(typeof(Implementation));
                    break;
            }
        }
    }
}