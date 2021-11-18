using System;
using TuseAwesomeApiWeb.Data;
using TuseAwesomeApiWeb.Repo.IRepo;

namespace TuseAwesomeApiWeb.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            ITemRepository = new ITemRepo(_dbContext);
            UserRepository = new UserRepository(_dbContext);
        }

        public IITemRepository ITemRepository { get; private set; }

        public IUser UserRepository { get; private set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
