using Dominos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos
{
    internal class VmProductDetails
    {
        public VmProductDetails() {
            Product = new ProductsModel();
            lstImages = new List<ImagesModel>();
        }   
        public ProductsModel Product { get; set; }
        public List<ImagesModel> lstImages { get; set; }

    }
}
