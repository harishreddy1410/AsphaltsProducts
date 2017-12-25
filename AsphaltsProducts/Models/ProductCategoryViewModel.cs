using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsphaltsProducts.Presentation.Layer.Models
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public ProductCategoryName Category { get; set; }
        
        public List<ProductViewModel> ProductList { get; set; }
    }
    public enum ProductCategoryName
    {
        CLOTHING,
        FURNITURE
    }
}
