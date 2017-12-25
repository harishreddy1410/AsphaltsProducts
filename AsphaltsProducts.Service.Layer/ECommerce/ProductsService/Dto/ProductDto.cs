using System;
using System.Collections.Generic;
using System.Text;

namespace AsphaltsProducts.Service.Layer.ECommerce.ProductsService.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductUrl { get; set; }
        public string ProductName { get; set; }
        //public string product_category_tree { get; set; }        
        public string RetailPrice { get; set; }
        public string DiscountedPrice { get; set; }
        public string ProductImage { get; set; }
        //public string is_FK_Advantage_product { get; set; }
        public string Description { get; set; }
        
        public string ProductRating { get; set; }
        public string OverallRating { get; set; }
        
        public string Brand { get; set; }
        public string ProductSpecifications { get; set; }

        //[ForeignKey("ProductCategory")]
        //public ProductCategory CategoryId { get; set; }
    }
}
