using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Workshops
{
    /// <summary>
    /// Логика взаимодействия для DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        private static Workshop context;
        public DetailsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            context = WorkshopsViewModel.GetInstance().SelectedEntity;
            DataContext = context;
        }

        private void btnAddEmployee_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EmployeesViewModel.GetInstance().SelectedEntity = new Employee();
            EmployeesViewModel.GetInstance().SelectedEntity.Workshop = context;
            Navigator.Move(new Employees.AddEditPage());
        }

        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigator.Back();
        }
    }
}
