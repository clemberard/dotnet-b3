
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models;

public enum Field
{
    MATHS, ENGLISH, CS, BIOLOGY, CHEMISTRY, PHYSICS
}

public class Teacher : Account
{

    // [Required]
    // public int Id { get; set; }


    public Field Field { get; set; }

    public int Salary { get; set; }
}