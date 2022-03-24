using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Services
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private static ServicesViewModel model;
        private static Service context;
        Mode mode;
        public AddEditPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigator.Back();
        }

        private void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
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

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            model = ServicesViewModel.GetInstance();
            context = model.SelectedEntity;

            DataContext = context;

            switch (model.Mode)
            {
                case Mode.Add:
                    mode = Mode.Add;
                    break;
                case Mode.Edit:
                    mode = Mode.Edit;
                    break;
                default:
                    break;
            }
        }
    }
}
