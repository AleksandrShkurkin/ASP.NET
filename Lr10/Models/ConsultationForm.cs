using System.ComponentModel.DataAnnotations;

public class ConsultationForm
{
    [Required(ErrorMessage = "Name and Surname are mandatory.")]
    [StringLength(30, ErrorMessage = "Name and Surname must not exceed 100 characters.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email is mandatory.")]
    [EmailAddress(ErrorMessage = "Enter a correct email adress.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Date is mandatory.")]
    [FutureDate(ErrorMessage = "Date of consultation can not be in the past.")]
    [NonWeekendDate(ErrorMessage = "Consultations are not held at weekends.")]
    public DateTime ConsultationDate { get; set; }

    [Required(ErrorMessage = "Оберіть продукт.")]
    public string Product { get; set; }
}