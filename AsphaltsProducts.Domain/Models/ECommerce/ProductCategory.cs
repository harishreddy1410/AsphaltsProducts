using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace AsphaltsProducts.Domain.Models.ECommerce
{
    public class ProductCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 Id { get; set; }
        public ProductCategoryNames Category { get; set; }

        //[InverseProperty("Id")]
        public List<Product> ProductList { get; set; }
    }

    public enum ProductCategoryNames
    {
        CLOTHING,
        FURNITURE
    }
}
