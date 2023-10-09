using System.ComponentModel.DataAnnotations.Schema;

namespace onlineCourses.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        
        [ForeignKey("Instructor")]
        public int ins_id{ get; set; }
        public Instructor Instructor { get; set; }

    }
}
