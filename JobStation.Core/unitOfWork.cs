using JobStation.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStation.Core
{
    public class unitOfWork :IunitOfWork
    {
        public AppDbContext _context { get; }
        public IJobCategoryRepository JobCategory { get; }
        public IUserRepository UserRepository { get; }
        public ILogInHistoryRepository LogInHistoryRepository { get; }

        public unitOfWork(AppDbContext context,
            IJobCategoryRepository jobCategory,
            IUserRepository userRepository,
            ILogInHistoryRepository logInHistoryRepository)
        {
            _context = context;
            JobCategory =  jobCategory;
            UserRepository = userRepository;
            LogInHistoryRepository = logInHistoryRepository;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
