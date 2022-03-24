using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Orders
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private static OrdersViewModel model;
        private static Order context;
        Mode mode;
        public AddEditPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Back();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (cbEmployee.SelectedIndex == -1 || cbCar.SelectedIndex == -1 || cbClient.SelectedIndex == -1)
            {
                MessageBox.Show("Мастер, клиент или машина не выбраны.");
                return;
            }

            context.Car = model.CurrentClientsCars[cbCar.SelectedIndex];
            context.Employee = model.Employees[cbEmployee.SelectedIndex];
            switch (mode)
            {
                case Mode.Add:
                    MessageBox.Show(model.Add());
                    break;
                case Mode.Edit:
                    MessageBox.Show(model.Edit());
                    break;
                default:
                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            model = OrdersViewModel.GetInstance();
            context = model.SelectedEntity;

            DataContext = context;

            cbClient.ItemsSource = model.Clients.ConvertAll(p => p.FullName + " " + p.DriversLicense);
            cbEmployee.ItemsSource = model.Employees.ConvertAll(p => p.FullName);
            cbCar.ItemsSource = model.Cars.ConvertAll(p => p.CarModelID + " " + p.CarNumber);

            if (context == null)
            {
                context = new Order();
                mode = Mode.Add;
            }
            else
            {
                mode = Mode.Edit;
                cbClient.SelectedIndex = model.Clients.FindIndex(p => p.DriversLicense == context.Car.Client.DriversLicense);
                cbCar.SelectedIndex = model.Cars.FindIndex(p => p.CarNumber == context.CarID);
                cbEmployee.SelectedIndex = model.Employees.FindIndex(p => p.ID == context.EmployeeID);
            }
        }

        private void cbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbClient.SelectedItem != null)
            {
                var client = cbClient.SelectedItem as Client;
                model.CurrentClientsCars = model.Cars.FindAll(p => p.OwnerID == client.DriversLicense);
                cbCar.ItemsSource = model.CurrentClientsCars.ConvertAll(p => p.CarModelID + " " + p.CarNumber); ;
                cbCar.IsEnabled = true;
            }
        }
    }
}
