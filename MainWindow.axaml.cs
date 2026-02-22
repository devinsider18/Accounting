using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
namespace Calculus
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Nav.MainFrame = ContentFrame;
            NavMenu.SelectionChanged += menu;
            Nav.Go(typeof(HomeView));
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
                            Nav.Go(typeof(HomeView));
                            break;
                        case "BankPage":
                            Nav.Go(typeof(BankView));
                            break;
                        case "PurchasesPage":
                            Nav.Go(typeof(PurchasesView));
                            break;
                        case "SalesPage":
                            Nav.Go(typeof(SalesView));
                            break;
                        case "WarehousePage":
                            Nav.Go(typeof(WarehouseView));
                            break;
                        case "OperationsPage":
                            Nav.Go(typeof(OperationView));
                            break;
                        case "ReportsPage":
                            Nav.Go(typeof(ReportsView));
                            break;
                        case "DictionariesPage":
                            Nav.Go(typeof(DictionariesView));
                            break;
                    }
                }
            }
        }
    }
}