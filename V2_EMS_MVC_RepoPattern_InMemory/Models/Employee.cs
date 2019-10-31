using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace V2_EMS_MVC_RepoPattern_InMemory.Models
{
    public class Employee: IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DisplayName("Date of Joining")]
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(1000000000, 9999999999, ErrorMessage = "Phone has to be 10 digits")]
        public long Phone { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [DisplayName("Job Title")]
        public JobTitle JobTitle { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (DateOfBirth >= DateTime.Now)
            {
                yield return new ValidationResult(
                    "Date of birth should be in the past",
                    new[] { nameof(DateOfBirth) });
            }
        }
    }
}
