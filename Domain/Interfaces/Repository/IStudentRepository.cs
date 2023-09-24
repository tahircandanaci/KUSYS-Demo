using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Interfaces.Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<ResultViewModel> InsertStudentAsync(Student model);
        Task<ResultViewModel> UpdateStudentAsync(Student model);
        Task<ResultViewModel> DeleteStudentAsync(int id);
    }
}