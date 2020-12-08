using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS3750FinalTimeTracker
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IGroupRepository Group { get; }
        void Save();
    }
}
