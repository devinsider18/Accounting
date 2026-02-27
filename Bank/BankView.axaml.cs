using Avalonia.Controls;
namespace Accounting;
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
                case "Bankstatements":
                    Nav.Go(typeof(Bank_statements));
                    break;
                case "Paymentsonregisters":
                    Nav.Go(typeof(Payments_on_registers));
                    break;
                case "Cashdocuments":
                    Nav.Go(typeof(Cash_documents));
                    break;
                case "Advancereports":
                    Nav.Go(typeof(Advance_reports));
                    break;
                case "cardtranscations":
                    Nav.Go(typeof(card_transactions));
                    break;
            }
        }
    }
}