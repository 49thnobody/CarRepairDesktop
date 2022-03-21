using System.Data.Entity;

namespace CarRepairDesktop.Model
{
    public partial class EntityModel : DbContext
    {
        private static EntityModel _instance;

        public static EntityModel GetInstance()
        {
            if(_instance == null)   
                _instance = new EntityModel();

            return _instance;
        }
    }
}
