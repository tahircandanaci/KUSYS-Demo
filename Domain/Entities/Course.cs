using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Course : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public Course(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
