using UnitOfWorkPractise.Context;
using UnitOfWorkPractise.Interface;
using UnitOfWorkPractise.Service;

namespace UnitOfWorkPractise.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MemorandumDbContext _context;
        public UnitOfWork(MemorandumDbContext context)
        {
            _context = context;
            Memorandum = new MemorandumRepository(_context);
        }

        public IMemorandumRepository Memorandum { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
