using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRepairDesktop.ViewModels
{
    public class WorkshopsViewModel : ViewModel
    {
        public List<Workshop> Entities { get => _dbInstance.Workshops.ToList(); }

        public List<Workshop> SortedEntities { get => _sortedEntities; set => Set(ref _sortedEntities, value); }

        private List<Workshop> _sortedEntities;


        private Workshop _selectedWorkshop;
        public Workshop SelectedWorkshop { get => _selectedWorkshop; set => _selectedWorkshop = value; }

        public override string Check()
        {
            if (SelectedWorkshop == null) return "Нет мастерской для проверки.";
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(SelectedWorkshop.Title))
                errors.AppendLine("Название услуги не введено.");
            if (string.IsNullOrEmpty(SelectedWorkshop.Address))
                errors.AppendLine("Название услуги не введено.");
            errors.AppendLine("Фио казано неполностью (требуется хотя бы фамилия и имя).");
            if (string.IsNullOrEmpty(SelectedWorkshop.Phone))
                errors.AppendLine("Телефон не указан.");
            else if (SelectedWorkshop.Phone.Length != 6)
                errors.AppendLine("Размер поля Телефон не соблюден (6 символов).");
            else if (!SelectedWorkshop.Phone.All(char.IsDigit))
                errors.AppendLine("Телефон должен содержать только цифры.");

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
                _dbInstance.Workshops.Add(SelectedWorkshop);
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
                _dbInstance.Workshops.Remove(SelectedWorkshop);
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
