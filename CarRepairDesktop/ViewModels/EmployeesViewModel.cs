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


        private Employee _selectedEmployee;
        public Employee SelectedEmployee { get => _selectedEmployee; set => _selectedEmployee = value; }

        public override string Check()
        {
            if (SelectedEmployee == null) return "Нет мастера для проверки.";
            StringBuilder errors = new StringBuilder();

            if (SelectedEmployee.FullName.Length > 50)
                errors.AppendLine("Размер поля ФИО превышен (50 символов).");
            if (string.IsNullOrEmpty(SelectedEmployee.FullName))
                errors.AppendLine("ФИО не указано.");
            else if (SelectedEmployee.FullName.Split(' ').Length < 2)
                errors.AppendLine("Фио казано неполностью (требуется хотя бы фамилия и имя).");
            if (string.IsNullOrEmpty(SelectedEmployee.Phone))
                errors.AppendLine("Телефон не указан.");
            else if (SelectedEmployee.Phone.Length != 11)
                errors.AppendLine("Размер поля Телефон не соблюден (11 символов).");
            else if (!SelectedEmployee.Phone.All(char.IsDigit))
                errors.AppendLine("Телефон должен содержать только цифры.");
            if (SelectedEmployee.Rank < 1 || SelectedEmployee.Rank > 7)
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
                _dbInstance.Employees.Add(SelectedEmployee);
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
                _dbInstance.Employees.Remove(SelectedEmployee);
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно удалена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
