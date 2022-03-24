using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Employees
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private static EmployeesViewModel model;
        private static Employee context;
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
            if (cbWorkshop.SelectedIndex == -1)
            {
                MessageBox.Show("Мастерская не выбрана.");
                return;
            }

            context.Workshop = model.Workshops[cbWorkshop.SelectedIndex];

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
            model = EmployeesViewModel.GetInstance();
            context = model.SelectedEntity;

            DataContext = context;
            cbWorkshop.ItemsSource = model.Workshops.ConvertAll(p => p.Title);
            if (context == null)
            {
                context = new Employee();
                mode = Mode.Add;
            }
            else
            {
                mode = Mode.Edit;
                cbWorkshop.SelectedIndex = model.Workshops.FindIndex(p => p.ID == context.Workshop.ID);
            }
        }
    }
}
