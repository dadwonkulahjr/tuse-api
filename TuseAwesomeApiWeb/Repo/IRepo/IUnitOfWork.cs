using System;

namespace TuseAwesomeApiWeb.Repo.IRepo
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        public IITemRepository ITemRepository { get; }
        public IUser UserRepository { get; }
    }
}
