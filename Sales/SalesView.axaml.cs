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
                case "InvoicesIssued":
                    Nav.Go(typeof(InvoicesIssued));
                    break;
                case "Returns":
                    Nav.Go(typeof(returns));
                    break;
                case "Reconciliations":
                    Nav.Go(typeof(reconciliations));
                    break;
                case "DebtAdjustment":
                    Nav.Go(typeof(debt_adjustment));
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