using CarRepairDesktop.Model;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace CarRepairDesktop.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected EntityModel _dbInstance;

        public ViewModel()
        {
            _dbInstance = EntityModel.GetInstance();
        }

        public abstract string Check();
        public abstract string Add();
        public abstract string Edit();
        public abstract string Delete();
    }
}
