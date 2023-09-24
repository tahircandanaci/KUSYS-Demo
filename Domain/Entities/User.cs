using Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }


        public Role Role { get; set; }

        public User(int id, string username, string password, int roleId) : base(id)
        {
            Username = username;
            Password = password;
            RoleId = roleId;
        }
    }
}