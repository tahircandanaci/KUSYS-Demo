using Domain.Interfaces.Repository;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {

        #region Properties
        ICourseRepository CourseRepository { get; }
        IStudentRepository StudentRepository { get; }
        IStudentCourseRepository StudentCourseRepository { get; }
        IUserRepository UserRepository { get; }

        #endregion

        #region Methods
        Task CompleteAsync();
        #endregion
    }
}