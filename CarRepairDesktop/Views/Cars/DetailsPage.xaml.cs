using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Cars
{
    /// <summary>
    /// Логика взаимодействия для DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        private static Car context;
        public DetailsPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigator.Back();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            context = CarsViewModel.GetInstance().SelectedEntity;

            DataContext = context;
        }

        private void btnMakeOrder_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
