using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRepairDesktop.ViewModels
{
    public class EmployeesViewModel : ViewModel
    {
        public List<Employee> Entities { get => _dbInstance.Employees.ToList(); }

        public List<Employee> SortedEntities { get => _sortedEntities; set => Set(ref _sortedEntities, value); }

        private List<Employee> _sortedEntities;


        private Employee _selectedEntity;
        public Employee SelectedEntity { get => _selectedEntity; set => _selectedEntity = value; }

        public override string Check()
        {
            if (SelectedEntity == null) return "Нет мастера для проверки.";
            StringBuilder errors = new StringBuilder();

            if (SelectedEntity.FullName.Length > 50)
                errors.AppendLine("Размер поля ФИО превышен (50 символов).");
            if (string.IsNullOrEmpty(SelectedEntity.FullName))
                errors.AppendLine("ФИО не указано.");
            else if (SelectedEntity.FullName.Split(' ').Length < 2)
                errors.AppendLine("Фио казано неполностью (требуется хотя бы фамилия и имя).");
            if (string.IsNullOrEmpty(SelectedEntity.Phone))
                errors.AppendLine("Телефон не указан.");
            else if (SelectedEntity.Phone.Length != 11)
                errors.AppendLine("Размер поля Телефон не соблюден (11 символов).");
            else if (!SelectedEntity.Phone.All(char.IsDigit))
                errors.AppendLine("Телефон должен содержать только цифры.");
            if (SelectedEntity.Rank < 1 || SelectedEntity.Rank > 7)
                errors.AppendLine("Разряд не может быть ниже 1 или выше 7.");

            if (errors.Length > 0)
                return errors.ToString();
            return string.Empty;
        }

        public override string Add()
        {
            var check = Check();
            if (check != string.Empty) return check;

            try
            {
                _dbInstance.Employees.Add(SelectedEntity);
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
                _dbInstance.Employees.Remove(SelectedEntity);
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно удалена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static EmployeesViewModel _instance;
        public static EmployeesViewModel GetInstance()
        {
            if (_instance == null) _instance = new EmployeesViewModel();
            return _instance;
        }
        public EmployeesViewModel()
        {
            SortedEntities = Entities;
        }
    }
}
