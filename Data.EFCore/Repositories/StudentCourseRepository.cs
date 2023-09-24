using Data.EFCore.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore.Repositories
{
    public class StudentCourseRepository : GenericRepository<StudentCourse>, IStudentCourseRepository, IDisposable
    {
        public StudentCourseRepository(KUSYSContext context) : base(context)
        {
        }

        public async Task<object> GetAllStudentCourseByStudentId(int Id)
        {
            var r = await
            (from sC in Context.StudentCourses
             join s in Context.Students on sC.StudentId equals s.Id
             join c in Context.Courses on sC.CourseId equals c.Id
             where s.Id == Id
             select new
             {
                 sC.Id,
                 sC.StudentId,
                 sC.CourseId,
                 sC.CreateDate,
                 StudentName = s.FirstName + " " + s.LastName,
                 CourseName = c.Name
             }).ToListAsync();

            return r;
        }

        public async Task<ResultViewModel> InsertStudentCourseAsync(StudentCourse model)
        {
            try
            {
                var controlUniqueList = await GetWhere(w => w.StudentId == model.StudentId && w.CourseId == model.CourseId);
                if (controlUniqueList.Any())
                    throw new Exception();
                await Insert(model);
                await Context.SaveChangesAsync();
                return new ResultViewModel(true, OperationType.Insert);
            }
            catch (Exception)
            {
                return new ResultViewModel(false, OperationType.Insert);
            }
        }

        public async Task<ResultViewModel> DeleteStudentCourseAsync(int id)
        {
            try
            {
                await Delete(id);
                await Context.SaveChangesAsync();
                return new ResultViewModel(true, OperationType.Delete);
            }
            catch (Exception)
            {
                return new ResultViewModel(false, OperationType.Delete);
            }
        }
    }
}
