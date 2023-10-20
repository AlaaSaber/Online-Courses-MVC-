using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace onlineCourses.Data.ViewModels
{
    public class StudentViewModelscs
    {

        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "name lenght must be from 3 to 50 characters")]
        public string Name { get; set; }
        [Required]
        [Range(8, 25, ErrorMessage = "Age must Be from 8 to 25 ")]
        public int Age { get; set; }
        public string Address { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        [Column(TypeName = "varchar(1)")]
        public char Gender { get; set; }
        public int Phone { get; set; }
       
    }
}
