using Data.EFCore.Context;
using Data.EFCore.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Data.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        private CourseRepository _courseRepository;
        public ICourseRepository CourseRepository => _courseRepository ?? (_courseRepository = new CourseRepository(_dbContext));

        private StudentRepository _studentRepository;
        public IStudentRepository StudentRepository => _studentRepository ?? (_studentRepository = new StudentRepository(_dbContext));

        private StudentCourseRepository _studentCourseRepository;
        public IStudentCourseRepository StudentCourseRepository => _studentCourseRepository ?? (_studentCourseRepository = new StudentCourseRepository(_dbContext));

        private UserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_dbContext));

        #endregion

        #region Readonlys

        private readonly KUSYSContext _dbContext;

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dbContext">The Database Context</param>
        public UnitOfWork(KUSYSContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region Methods

        /// <summary>
        /// Completes the unit of work, saving all repository changes to the underlying data-store.
        /// </summary>
        /// <returns><see cref="Task"/></returns>
        public async Task CompleteAsync() => await _dbContext.SaveChangesAsync();

        #endregion

        #region Implements IDisposable

        #region Private Dispose Fields

        private bool _disposed;

        #endregion

        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <returns><see cref="ValueTask"/></returns>
        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);

            // Take this object off the finalization queue to prevent 
            // finalization code for this object from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <param name="disposing">Whether or not we are disposing</param> 
        /// <returns><see cref="ValueTask"/></returns>
        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    await _dbContext.DisposeAsync();
                }

                // Dispose any unmanaged resources here...

                _disposed = true;
            }
        }
        #endregion
    }
}