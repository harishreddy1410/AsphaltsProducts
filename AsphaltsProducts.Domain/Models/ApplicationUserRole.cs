using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsphaltsProducts.Domain.Models
{
    //class ApplicationUserRole
    //{
    //}
    public class ApplicationUserRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
