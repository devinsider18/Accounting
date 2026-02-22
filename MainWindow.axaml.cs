using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
namespace Calculus
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(typeof(HomeView));
            NavMenu.SelectionChanged += menu;
        }
        private void menu(object? sender, NavigationViewSelectionChangedEventArgs e)
        {
            if (e.SelectedItem is NavigationViewItem item)
            {
                if (item.Tag is string tag)
                {
                    switch (tag)
                    {
                        case "MainPage":
                            ContentFrame.Navigate(typeof(HomeView));
                            break;
                        case "BankPage":
                            ContentFrame.Navigate(typeof(BankView));
                            break;
                        case "PurchasesPage":
                            ContentFrame.Navigate(typeof(PurchasesView));
                            break;
                        case "SalesPage":
                            ContentFrame.Navigate(typeof(SalesView));
                            break;
                        case "WarehousePage":
                            ContentFrame.Navigate(typeof(WarehouseView));
                            break;
                        case "OperationsPage":
                            ContentFrame.Navigate(typeof(OperationView));
                            break;
                        case "ReportsPage":
                            ContentFrame.Navigate(typeof(ReportsView));
                            break;
                        case "DictionariesPage":
                            ContentFrame.Navigate(typeof(DictionariesView));
                            break;
                    }
                }
            }
        }
    }
}