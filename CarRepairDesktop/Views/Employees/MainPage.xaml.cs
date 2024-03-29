﻿using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Employees
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

        private static EmployeesViewModel context;
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
            context.SelectedEntity = new Employee();
            context.Mode = Mode.Add;
            Navigator.Move(new AddEditPage());
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Move(new DetailsPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            context = EmployeesViewModel.GetInstance();
            DataContext = context;
        }

        private void btnQuerry_Click(object sender, RoutedEventArgs e)
        {
            var emp = context.Querry();

            if (emp == null) MessageBox.Show("Нет мастеров, работавших с довоенными автомобилями.");
            else MessageBox.Show($"Мастер, наиболее часто работающий с довоенными автомобилями: {emp.FullName}");
        }
    }
}
