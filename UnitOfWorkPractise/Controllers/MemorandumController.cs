using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnitOfWorkPractise.UnitOfWork;

namespace UnitOfWorkPractise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemorandumController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemorandumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetMemorandum")]
        public IActionResult GetMemorandum(byte month, short year, string branchCode)
        {
            var data = _unitOfWork.Memorandum.GetMemorandum(month, year, branchCode);
            return Ok(JsonConvert.SerializeObject(data));
        }
    }
}
