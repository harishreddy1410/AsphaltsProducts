using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace AsphaltsProducts.Domain.Models.ECommerce
{
    public class ProductCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ProductCategoryNames Category { get; set; }

        [InverseProperty("CategoryId")]
        public List<Product> ProductList { get; set; }
    }

    public enum ProductCategoryNames
    {
        CLOTHING,
        FURNITURE
    }
}
