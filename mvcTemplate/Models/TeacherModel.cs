
using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public enum Field
{
    MATHS, ENGLISH, CS, BIOLOGY, CHEMISTRY, PHYSICS
}

public class Teacher
{

    [Required]
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 3)]
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    public int Age { get; set; }

    public Field Field { get; set; }

    public int Salary { get; set; }
}