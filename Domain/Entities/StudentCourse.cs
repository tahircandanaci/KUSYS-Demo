using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class StudentCourse : BaseEntity
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }


        public Student Student { get; set; }
        public Course Course { get; set; }

        public StudentCourse(int id, int studentId, int courseId) : base(id)
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
