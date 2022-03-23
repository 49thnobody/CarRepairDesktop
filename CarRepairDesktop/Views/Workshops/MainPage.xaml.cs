using CarRepairDesktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Workshops
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private static WorkshopsViewModel context;
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            context.SelectedEntity = null;
            Navigator.Move(new AddEditPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(context.Delete());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new AddEditPage());
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new DetailsPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            context = WorkshopsViewModel.GetInstance();
            DataContext = context;
        }
    }
}
