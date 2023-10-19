using onlineCourses.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onlineCourses.Models
{
    public class Student : AppUser
    {
        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be from 3 to 50 characters")]
        [Unique]
        public string Name { get; set; }
        [Required]
        [Range(8, 25, ErrorMessage = "Age must be from 8 to 25")]
        public int Age { get; set; }
        public string? ImageURL { get; set; }
        [Required]
        [Column(TypeName = "varchar(1)")]
        public char Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Student_Course>? Student_Course { get; set; }

    }
}
