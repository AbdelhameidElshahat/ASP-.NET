using LinkDev.IKEA.DAL.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace LinkDev.IKEA.PL.ViewModels.Employess
{
    public class EmployeeEditViewModel
    {
        [MaxLength(50, ErrorMessage = "Max Length of name is 50 chars")]
        [MinLength(5, ErrorMessage = "Min Length of name is 5 chars")]
        public string Name { get; set; } = null!;

        [Range(22, 30)]
        public int? Age { get; set; }

        //[RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$", ErrorMessage = "Address Must Be like 123-Street-City-Country")]
        public string? Address { get; set; }

        public decimal? Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int? DepartmentId { get; set; }

    }
}
