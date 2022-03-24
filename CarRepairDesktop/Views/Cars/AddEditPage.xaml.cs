using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Cars
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private static CarsViewModel model;
        private static Car context;
        Mode mode;
        public AddEditPage()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (cbModel.SelectedIndex == -1 || cbOwner.SelectedIndex == -1)
            {
                MessageBox.Show("Модель или владелец не выбраны.");
                return;
            }

            context.CarModel = model.CarModels[cbModel.SelectedIndex];
            context.Client = model.Owners[cbOwner.SelectedIndex];

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
            model = CarsViewModel.GetInstance();
            context = model.SelectedEntity;

            DataContext = context;
            cbModel.ItemsSource = model.CarModels.ConvertAll(p => p.Title);
            cbOwner.ItemsSource = model.Owners.ConvertAll(p => p.FullName + " " + p.DriversLicense);
            switch (model.Mode)
            {
                case Mode.Add:
                    mode = Mode.Add;
                    if (context.Client != null)
                        cbOwner.SelectedIndex = model.Owners.IndexOf(context.Client);
                    break;
                case Mode.Edit:
                    mode = Mode.Edit;
                    cbModel.SelectedIndex = model.CarModels.IndexOf(context.CarModel);
                    cbOwner.SelectedIndex = model.Owners.IndexOf(context.Client);
                    break;
                default:
                    break;
            }
        }

        private void btnAddCarModel_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new CarModels.AddPage());

            cbModel.ItemsSource = model.CarModels.ConvertAll(p => p.Title); // dunno if needed
        }
    }
}
