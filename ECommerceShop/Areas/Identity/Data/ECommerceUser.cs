using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ECommerceShop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ECommerceUser class
public class ECommerceUser : IdentityUser
{
    public string FullName { get; set; }

}

