using Data.EFCore.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.EFCore.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository, IDisposable
    {
        public CourseRepository(KUSYSContext context) : base(context)
        {
        }
    }
}