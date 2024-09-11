using Microsoft.EntityFrameworkCore;
using SearchPharmacy.Models;
using Dominos.Models;

namespace Dominos.Bl
{
    public interface IProducts
    {
        public List<ProductsModel> GetAll();
        public List<VmProducts> GetAllItemsData(int? cateId);
        public ProductsModel GetById(int id);
        public bool Save(ProductsModel category);
        public bool Delete(int id);
    }

    public class ClsProducts : IProducts
	{
        PharmacyContext context;
        public ClsProducts(PharmacyContext ctx)
        {
            context = ctx;
        }
        // should be use curentState = 1; becouse show ele result = 1 ,
        // but the curentState result 0 it's deleted  
        public List<ProductsModel> GetAll()
        {
            try
            {// a.Images != null => !string.IsNullOrEmpty(a.Images)
                var lstCategories = context.TbProducts.Where(a => a.CurrentState == 1 &&
                !string.IsNullOrEmpty(a.Images)).ToList();
                return lstCategories;
            }
            catch
            {
                return new List<ProductsModel>();
            }
        }

        public List<VmProducts> GetAllItemsData(int? pharmId) // VwItemCategory   , int? itemId
        {
            try
            {
                // var lstItems = context.VmItemProducts.Where(a => (a.PharmcistId == pharmId && pharmId == null && pharmId == 0)
                // && a.CurrentState == 1 ).OrderByDescending(a => a.CreatedDate).ToList();
                var lstItems = context.VmItemProducts.Where(a => (a.PharmcistId == pharmId && pharmId == null && pharmId == 0)
                   && a.CurrentState == 1 && !string.IsNullOrEmpty(a.ProductName))
                   .OrderByDescending(a => a.CreatedDate).ToList();
                return lstItems;
            }
            catch
            {
                return new List<VmProducts>();
            }
        }

        public ProductsModel GetById(int id)
        {
            try {
               var category = context.TbProducts.FirstOrDefault(a => a.ProductId == id && a.CurrentState == 1);
                return category;
            }
            catch {
                var products = new ProductsModel();
                return products;
            }
        }
    
        public bool Save(ProductsModel products)
        {
            try {
                // category new
                if (products.ProductId == 0)
                {
                    // complute the category not complute in veiw 
                    products.CurrentState = 1;
                    products.UpdatedBy = "admin";
                    products.CreatedBy = "1";
                    products.UpdatedDate = DateTime.Now;
                    context.TbProducts.Add(products);
                }
                else // edit existe category
                {
                    products.CurrentState = 1;
                    products.UpdatedBy = "admin";
                    products.CreatedBy = "1";
                    products.UpdatedDate = DateTime.Now;
                    context.Entry(products).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try { 
                var products = GetById(id);
                products.CurrentState = 0;
                context.SaveChanges();
                return true;
            }catch { 
                return false;
            }
        }
        
    }
}
