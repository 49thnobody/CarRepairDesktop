using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Employees
{
    /// <summary>
    /// Логика взаимодействия для DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        private static Employee context;
        public DetailsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            context = EmployeesViewModel.GetInstance().SelectedEntity;

            DataContext = context;
        }

        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigator.Back();
        }
    }
}
