using UnitOfWorkPractise.Models;
using UnitOfWorkPractise.ViewModel;

namespace UnitOfWorkPractise.Interface
{
    public interface IMemorandumRepository:IGenericRepository<Homemo>
    {
        List<MemorandumVM> GetMemorandum(byte month, short year, string branchCode);
    }
}
