using Data.EFCore.Context;
using Domain;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.ViewModels;

namespace Data.EFCore.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository, IDisposable
    {
        public StudentRepository(KUSYSContext context) : base(context)
        {
        }

        public async Task<ResultViewModel> InsertStudentAsync(Student model)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var user = new User(0, CreateUsername(model.FirstName, model.LastName), Constants.strNewUserPass, (int)EnumRole.User);
                    Context.Users.Add(user);
                    await Context.SaveChangesAsync();
                    model.UserId = user.Id;
                    Context.Students.Add(model);
                    await Context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return new ResultViewModel(true, OperationType.Insert);
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return new ResultViewModel(false, OperationType.Insert);
                }
            }
        }

        public async Task<ResultViewModel> UpdateStudentAsync(Student model)
        {
            try
            {
                await Update(model);
                await Context.SaveChangesAsync();
                return new ResultViewModel(true, OperationType.Update);
            }
            catch (Exception)
            {
                return new ResultViewModel(false, OperationType.Update);
            }
        }

        public async Task<ResultViewModel> DeleteStudentAsync(int id)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var student = Context.Students.Find(id);
                    var user = Context.Users.Find(student.UserId);
                    Context.Students.Remove(student);
                    Context.Users.Remove(user);
                    await Context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return new ResultViewModel(true, OperationType.Delete);
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return new ResultViewModel(false, OperationType.Delete);
                }
            }
        }

        #region PrivateMethods
        public string CreateUsername(string name, string lastName)
        {
            return name.Trim().Split(' ')[0].ToLower() + "." + lastName.Trim().Split(' ')[0].ToLower();
        }
        #endregion
    }
}
