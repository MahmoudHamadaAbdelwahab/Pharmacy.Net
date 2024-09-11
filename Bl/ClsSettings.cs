using Microsoft.EntityFrameworkCore;
using SearchPharmacy.Models;
using Dominos.Models;

namespace Dominos.Bl
{
    public interface ISettings
    {
        public List<SettingsModel> GetAll();
        public SettingsModel GetById(int id);
        public bool Save(SettingsModel setting);
        public bool Delete(int id);
    }
	
    public class ClsSettings : ISettings
    {
        PharmacyContext context;
        public ClsSettings(PharmacyContext ctx)
        {
            context = ctx;
        }
        // should be use curentState = 1; becouse show ele result = 1 ,
        // but the curentState result 0 it's deleted  
        public List<SettingsModel> GetAll()
        {
            try
            {
                var lstSettings = context.TbSettings.ToList();
                return lstSettings;
            }
            catch
            {
                return new List<SettingsModel>();
            }
        }

        public SettingsModel GetById(int id)
        {
            try
            {
                var setting = context.TbSettings.FirstOrDefault(a => a.SettingsId == id);
                return setting;
            }
            catch
            {
                var setting = new SettingsModel();
                return setting;
            }
        }

        public bool Save(SettingsModel suppliers)
        {
            try
            {
                // setting new
                if (suppliers.SettingsId == 0)
                {
                    // complute the setting not complute in veiw 
                    context.TbSettings.Add(suppliers);
                }
                else // edit existe setting
                {
                    context.Entry(suppliers).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var suppliers = GetById(id);
                //suppliers.CurrentState = 0;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
