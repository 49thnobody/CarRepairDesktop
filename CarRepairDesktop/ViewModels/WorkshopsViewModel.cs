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


        private Workshop _selectedEntity;
        public Workshop SelectedEntity { get => _selectedEntity; set => _selectedEntity = value; }

        public override string Check()
        {
            if (SelectedEntity == null) return "Нет мастерской для проверки.";
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(SelectedEntity.Title))
                errors.AppendLine("Название услуги не введено.");
            if (string.IsNullOrEmpty(SelectedEntity.Address))
                errors.AppendLine("Название услуги не введено.");
            errors.AppendLine("Фио казано неполностью (требуется хотя бы фамилия и имя).");
            if (string.IsNullOrEmpty(SelectedEntity.Phone))
                errors.AppendLine("Телефон не указан.");
            else if (SelectedEntity.Phone.Length != 6)
                errors.AppendLine("Размер поля Телефон не соблюден (6 символов).");
            else if (!SelectedEntity.Phone.All(char.IsDigit))
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
                _dbInstance.Workshops.Add(SelectedEntity);
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
                _dbInstance.Workshops.Remove(SelectedEntity);
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно удалена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public WorkshopsViewModel()
        {
            SortedEntities = Entities;
        }
    }
}
