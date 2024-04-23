using UnitOfWorkPractise.Interface;

namespace UnitOfWorkPractise.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        public IMemorandumRepository Memorandum { get; }
        void Save();
    }
}
