using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AsphaltsProducts.Domain.Models.ECommerce
{
    public class Product
    {
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }
        public string product_url { get; set; }
        public string product_name { get; set; }
        public string product_category_tree { get; set; }        
        public string retail_price { get; set; }
        public string discounted_price { get; set; }
        public string image { get; set; }
        //public string is_FK_Advantage_product { get; set; }
        public string description { get; set; }
        [MaxLength(50)]
        public string product_rating { get; set; }
        public string overall_rating { get; set; }
        [MaxLength(50)]
        public string brand { get; set; }
        public string product_specifications { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory CategoryId { get; set; }

    }
}
