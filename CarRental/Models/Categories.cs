using CarRental.Validations;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Categories
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "The length of the {0} field must be between {2} and {1} characters")]
        [FirstLetterToUppercase]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The {0} field is required")]
        [Display(Name = "Cost per Day")]
        public decimal CostPerDay { get; set; }
        
        [Required(ErrorMessage = "The number of {0} is required")]
        public int Passengers { get; set; }
        
        [Required(ErrorMessage = "The number of {0} is required")]
        public int Luggages { get; set; }
        
        [Required(ErrorMessage = "The cost of {0} is required")]
        [Display(Name = "Late Fee per Hour")]
        public decimal LateFeePerHour { get; set; }
    }
}
