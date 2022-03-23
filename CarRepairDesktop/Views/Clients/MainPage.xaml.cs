using CarRepairDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRepairDesktop.Views.Clients
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

        ClientsViewModel context;
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
            context = ClientsViewModel.GetInstance();
            DataContext = context;
        }
    }
}
