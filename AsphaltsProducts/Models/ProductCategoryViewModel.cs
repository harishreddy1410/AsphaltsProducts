using System.Collections.Generic;

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
