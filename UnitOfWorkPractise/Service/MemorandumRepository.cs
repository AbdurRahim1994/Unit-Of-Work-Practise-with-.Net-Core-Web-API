using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UnitOfWorkPractise.Context;
using UnitOfWorkPractise.Interface;
using UnitOfWorkPractise.Models;
using UnitOfWorkPractise.ViewModel;

namespace UnitOfWorkPractise.Service
{
    public class MemorandumRepository : GenericRepository<Homemo>, IMemorandumRepository
    {
        public MemorandumRepository(MemorandumDbContext context) : base(context) 
		{ 

		}
        public List<MemorandumVM> GetMemorandum(byte month, short year, string branchCode)
        {
			try
			{
				var memos = (from hm in _context.Homemos
							 where hm.TrMonth == month && hm.TrYear == year && hm.BranchCode == branchCode
							 select new MemorandumVM
							 {
								 HomemoId = hm.HomemoId,
								 BranchCode = hm.BranchCode,
								 TrDate = hm.TrDate,
								 TrMonth = hm.TrMonth,
								 TrYear = hm.TrYear,
								 TrAmount = hm.TrAmount,
								 Accode = hm.Accode,
								 MemoDesc = hm.MemoDesc,
								 Remarks = hm.Remarks
							 }).ToList();
				return memos;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
