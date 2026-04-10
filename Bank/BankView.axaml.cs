using Avalonia.Controls;
namespace Accounting.Bank;
public partial class BankView : UserControl
{
    public BankView()
    {
        InitializeComponent();
    }
    private void Menu(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Button button = (Button)sender;
        if(button.Name != null)
        {
            switch (button.Name)
            {
                case "Paymentorders":
                    Nav.Go(typeof(PaymentOrders));
                    break;
                case "Bankstatements":
                    Nav.Go(typeof(BankStatements));
                    break;
                case "Paymentsonregisters":
                    Nav.Go(typeof(PaymentsOnRegisters));
                    break;
                case "Cashdocuments":
                    Nav.Go(typeof(CashDocuments));
                    break;
                case "Advancereports":
                    Nav.Go(typeof(AdvanceReports));
                    break;
                case "cardtranscations":
                    Nav.Go(typeof(CardTransactions));
                    break;
            }
        }
    }
}