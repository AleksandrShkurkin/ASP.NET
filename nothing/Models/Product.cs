using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Pizza title")]
    public string Name { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Wrong amount")]
    [Display(Name = "Amount")]
    public int Quantity { get; set; }
}