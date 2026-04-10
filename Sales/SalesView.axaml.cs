using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Accounting.Sales;

public partial class SalesView : UserControl
{
    public SalesView()
    {
        InitializeComponent();
    }

    private void Menu(object sender, RoutedEventArgs e)
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
                case "InvoicesIssued":
                    Nav.Go(typeof(InvoicesIssued));
                    break;
                case "Returns":
                    Nav.Go(typeof(Returns));
                    break;
                case "Reconciliations":
                    Nav.Go(typeof(Reconciliations));
                    break;
                case "DebtAdjustment":
                    Nav.Go(typeof(DebtAdjustment));
                    break;
                case "InterestAccrual":
                    Nav.Go(typeof(InterestAccrual));
                    break;
                case "SettlementsInventory":
                    Nav.Go(typeof(SettlementsInventory));
                    break;
            }
        }
    }
}