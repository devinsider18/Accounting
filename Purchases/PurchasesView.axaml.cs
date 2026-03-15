using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace Accounting;

public partial class PurchasesView : UserControl
{
    public PurchasesView()
    {
        InitializeComponent();
    }

    private void menu(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        if (button.Name != null)
        {
            switch (button.Name)
            {
                case "Invoicesfromsuppliers":
                    Nav.Go(typeof(Invoices_from_suppliers));
                    break;
                case "Admission":
                    Nav.Go(typeof(Admission));
                    break;
                case "Additionalexpenses":
                    Nav.Go(typeof(Additional_expenses));
                    break;
                case "InvoicesReceived":
                    Nav.Go(typeof(Invoices_Received));
                    break;
                case "Returnstosuppliers":
                    Nav.Go(typeof(Returns_to_suppliers));
                    break;
                case "ReconciliationStatementswithCounterparties":
                    Nav.Go(typeof(Reconciliation_Statements_with_Counterparties));
                    break;
                case "Debtadjustment":
                    Nav.Go(typeof(Debt_adjustment));
                    break;
                case "Trusts":
                    Nav.Go(typeof(Trusts));
                    break;
                case "Customsdeclarations":
                    Nav.Go(typeof(Customs_declarations));
                    break;
            }
        }
    }
}