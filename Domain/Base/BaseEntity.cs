using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base
{
    public class BaseEntity : IDisposable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public BaseEntity()
        {
            CreateDate = DateTime.Now;
        }

        public BaseEntity(int id) : this()
        {
            Id = id;
        }

        public void Dispose()
        {
        }
    }
}