using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRepairDesktop.ViewModels
{
    public class OrdersViewModel : ViewModel
    {
        public List<Order> Entities { get => _dbInstance.Orders.ToList(); }

        public List<Order> SortedEntities { get => _sortedEntities; set => Set(ref _sortedEntities, value); }

        private List<Order> _sortedEntities;


        private Order _selectedEntity;
        public Order SelectedEntity { get => _selectedEntity; set => _selectedEntity = value; }

        public List<Client> Clients { get=>_dbInstance.Clients.ToList(); }
        public List<Car> Cars { get => _dbInstance.Cars.ToList(); }
        public List<Car> CurrentClientsCars { get; set; }
        public List<Employee> Employees { get=>_dbInstance.Employees.ToList(); }

        public override string Check()
        {
            if (SelectedEntity == null) return "Нет заказа для проверки.";
            StringBuilder errors = new StringBuilder();

            if (SelectedEntity.PlannedEndDate == null)
                errors.AppendLine("Плановая дата окончания не указана.");

            if (SelectedEntity.Services.Count == 0)
                errors.AppendLine("В заказе нет услуг.");

            if (errors.Length > 0)
                return errors.ToString();
            return string.Empty;
        }

        public override string Add()
        {
            var check = Check();
            if (check != string.Empty) return check;

            SelectedEntity.StartDate = DateTime.Now;

            try
            {
                _dbInstance.Orders.Add(SelectedEntity);
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно добавлена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public override string Edit()
        {
            var check = Check();
            if (check != string.Empty) return check;

            try
            {
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно изменена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public override string Delete()
        {
            try
            {
                _dbInstance.Orders.Remove(SelectedEntity);
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно удалена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static OrdersViewModel _instance;
        public static OrdersViewModel GetInstance()
        {
            if (_instance == null) _instance = new OrdersViewModel();
            return _instance;
        }
        public OrdersViewModel()
        {
            SortedEntities = Entities;
        }
    }
}
