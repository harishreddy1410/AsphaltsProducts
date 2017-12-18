using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AsphaltsProducts.Domain.Models
{
   public class ApplicationUser : IdentityUser
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
