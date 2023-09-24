using Domain.Entities;

namespace Domain.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int UserId { get; set; }

        public Student Convert()
        {
            return new Student(Id,FirstName, LastName, BirthDate, UserId);
        }
    }
}