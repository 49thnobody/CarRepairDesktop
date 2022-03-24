using CarRepairDesktop.Model;
using System.Collections.Generic;
using System.Windows;

namespace CarRepairDesktop.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new Clients.MainPage());
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new Cars.MainPage());
        }

        private void btnWorkshops_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new Workshops.MainPage());
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new Employees.MainPage());
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new Orders.MainPage());
        }

        private void btnServices_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new Services.MainPage());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Navigator.Init(mainFrame);
            Navigator.Move(new Clients.MainPage());
        }
    }
}
