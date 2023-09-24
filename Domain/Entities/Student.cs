using Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }


        public User User { get; set; }

        public Student(int id, string firstName, string lastName, DateTime birthDate, int userId) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            UserId = userId;
        }
    }
}
