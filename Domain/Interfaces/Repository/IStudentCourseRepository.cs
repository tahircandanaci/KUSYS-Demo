using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Interfaces.Repository
{
    public interface IStudentCourseRepository : IGenericRepository<StudentCourse>
    {
        Task<object> GetAllStudentCourseByStudentId(int Id);
        Task<ResultViewModel> InsertStudentCourseAsync(StudentCourse model);
        Task<ResultViewModel> DeleteStudentCourseAsync(int id);
    }
}