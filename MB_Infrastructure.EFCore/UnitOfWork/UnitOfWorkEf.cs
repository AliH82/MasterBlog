using _01_Framework.Infrastructure;
using MB_Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace MB_Infrastructure.EFCore.UnitOfWork
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly MasterBlogContext _context;

        public UnitOfWorkEf(MasterBlogContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
