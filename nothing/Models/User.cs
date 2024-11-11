using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Username")]
    public string Name { get; set; }

    [Required]
    [Range(1, 123, ErrorMessage = "Dude, cmon, be real")]
    [Display(Name = "Age")]
    public int Age { get; set; }

    public int ProductQuantity { get; set; }
}