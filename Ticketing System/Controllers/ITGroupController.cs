using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Services;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;
using static TicketingSystem.ViewModel.ViewModels.DatatableVM;

namespace Ticketing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITGroupController : Controller
    {
        private readonly IGenericService<ITGroupVM> itgroupService;

        public ITGroupController(ITGroupService _itgroupService)
        {
            itgroupService = _itgroupService;
        }
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create
            ([FromBody] ITGroupVM itgroupVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return itgroupService.Create(itgroupVM);
        }
        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> Delete
            (Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return itgroupService.Delete(id);
        }
        [HttpGet("[action]")]
        public IEnumerable<ITGroupVM> GetAll()
        {
            return itgroupService.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public ITGroupVM GetSingleBy(Guid id)
        {
            return itgroupService.GetSingleBy(id);
        }
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update
            ([FromBody] ITGroupVM itgroupVM)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return itgroupService.Update(itgroupVM);
        }
        public ActionResult<PagingResponse<ITGroupVM>> GetDataServerSide([FromBody]PagingRequest paging)
        {
            return itgroupService.GetDataServerSide(paging);
        }
    }
}