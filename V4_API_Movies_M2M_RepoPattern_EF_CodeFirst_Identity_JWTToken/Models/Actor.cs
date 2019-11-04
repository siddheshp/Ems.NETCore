using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using V4_API_Movies_M2M_RepoPattern_EF_CodeFirst_Identity_JWTToken.Validators;

namespace V4_API_Movies_M2M_RepoPattern_EF_CodeFirst_Identity_JWTToken.Models
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        [DateValidator]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; } 
    }
}
