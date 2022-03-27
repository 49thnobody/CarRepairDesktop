using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Orders
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

        private static OrdersViewModel context;
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            context.Mode = Mode.Edit;
            Navigator.Move(new AddEditPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                MessageBox.Show(context.Delete());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            context.SelectedEntity = new Order();
            context.Mode = Mode.Add;
            Navigator.Move(new AddEditPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            context = OrdersViewModel.GetInstance();
            DataContext = context;

            cbModels.ItemsSource = context.CarModels.ConvertAll(p=>p.Title);
        }

        bool isClicked = false;
        private void btnQuerry_Click(object sender, RoutedEventArgs e)
        {
            if(!isClicked)
            {
                if (cbModels.SelectedIndex == -1)
                    return;
                context.Querry(context.CarModels[cbModels.SelectedIndex]);
                btnQuerry.Content = "К списку";
                isClicked = true;
            }
            else
            {
                context.Reset();
                isClicked = false;
            }
        }
    }
}
