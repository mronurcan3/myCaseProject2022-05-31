using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.ModelVM
{
    public class AppUserVM
    {
        public AppUser AppUser { get; set; }

        public UserProfile UserProfile { get; set; }

        public List<Product> Products { get; set; }
    }
}