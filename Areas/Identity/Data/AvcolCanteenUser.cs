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
    [StringLength(30, ErrorMessage = "Field must be less than 30 characters")] // limits the amount of data that can be entered
    [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
    [Required] // requires user to fill in 
    public string FirstName { get; set; }
    [StringLength(30, ErrorMessage = "Field must be less than 30 characters")] // limits the amount of data that can be entered
    [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter must be capitalised and only letters are allowed")] // defines a specific way of entering data
    [Required] // requires user to fill in
    public string LastName { get; set; }

    public ICollection<Orders> Orders { get; set; } = new List<Orders>();

}

