using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Accounting.Purchases;

public partial class PurchasesView : UserControl
{
    public PurchasesView()
    {
        InitializeComponent();
    }

    private void Menu(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        if (button.Name != null)
        {
            switch (button.Name)
            {
                case "Invoicesfromsuppliers":
                    Nav.Go(typeof(InvoicesFromSuppliers));
                    break;
                case "Admission":
                    Nav.Go(typeof(Admission));
                    break;
                case "Additionalexpenses":
                    Nav.Go(typeof(AdditionalExpenses));
                    break;
                case "InvoicesReceived":
                    Nav.Go(typeof(InvoicesReceived));
                    break;
                case "Returnstosuppliers":
                    Nav.Go(typeof(ReturnsToSuppliers));
                    break;
                case "ReconciliationStatementswithCounterparties":
                    Nav.Go(typeof(ReconciliationStatementsWithCounterparties));
                    break;
                case "Debtadjustment":
                    Nav.Go(typeof(DebtAdjustment));
                    break;
                case "Trusts":
                    Nav.Go(typeof(Trusts));
                    break;
                case "Customsdeclarations":
                    Nav.Go(typeof(CustomsDeclarations));
                    break;
            }
        }
    }
}