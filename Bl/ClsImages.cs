using Microsoft.EntityFrameworkCore;
using SearchPharmacy.Models;
using Dominos.Models;

namespace Dominos.Bl
{
    public interface IImages
    {
        public new List<ImagesModel> GetByImageId(int id);
    }

    public class ClsImages : IImages
    {
        PharmacyContext context;
        public ClsImages(PharmacyContext ctx)
        {
            context = ctx;
        }

        public List<ImagesModel> GetByImageId(int id)
        {
            try {
               var images = context.TbImages.Where(a => a.ProductId == id).ToList();
                return images;
            }
            catch {
                var images = new List<ImagesModel>();
                return images;
            }
        }
    
    }
}
