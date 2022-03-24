using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Workshops
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private static WorkshopsViewModel model;
        private static Workshop context;
        Mode mode;
        public AddEditPage()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Back();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            model = WorkshopsViewModel.GetInstance();
            context = model.SelectedEntity;

            DataContext = context;
            if (context == null)
            {
                context = new Workshop();
                mode = Mode.Add;
            }
            else
            {
                mode = Mode.Edit;
            }
        }
    }
}
