using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AvcolCanteen.Models;
using Microsoft.AspNetCore.Identity;

namespace AvcolCanteen.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AvcolCanteenUser class
public class AvcolCanteenUser : IdentityUser
{
    [Required] // requires user to fill in 
    public string FirstName { get; set; }
    [Required] // requires user to fill in
    public string LastName { get; set; }

    public ICollection<Orders> Orders { get; set; } = new List<Orders>();

}

