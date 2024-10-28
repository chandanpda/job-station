using JobStation.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core
{
    public interface IunitOfWork :IDisposable
    {
        IJobCategoryRepository JobCategory { get; }

        IUserRepository UserRepository { get; }
        ILogInHistoryRepository LogInHistoryRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
