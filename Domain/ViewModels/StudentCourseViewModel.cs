using Domain.Entities;

namespace Domain.ViewModels
{
    public class StudentCourseViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public StudentCourse Convert()
        {
            return new StudentCourse(Id,StudentId,CourseId);
        }
    }
}