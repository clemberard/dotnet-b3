using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models;

public class Account : IdentityUser
{
    [StringLength(50, MinimumLength = 3)]
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    public int Age { get; set; }
}