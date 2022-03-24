using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Clients
{
    /// <summary>
    /// Логика взаимодействия для DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        private static Client context;
        public DetailsPage()
        {
            InitializeComponent();
        }

        private void btnAddCar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CarsViewModel.GetInstance().SelectedEntity = null;
            Navigator.Move(new Cars.AddEditPage());
        }

        private void btnCarDetails_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CarsViewModel.GetInstance().SelectedEntity = dgCars.SelectedItem as Car;
            Navigator.Move(new Cars.DetailsPage());
        }

        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigator.Back();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            context = ClientsViewModel.GetInstance().SelectedEntity;

            DataContext = context;
        }

        private void btnMakeOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OrdersViewModel.GetInstance().SelectedEntity = new Order();
            OrdersViewModel.GetInstance().SelectedEntity.Car= dgCars.SelectedItem as Car;
            Navigator.Move(new Orders.AddEditPage());
        }
    }
}
