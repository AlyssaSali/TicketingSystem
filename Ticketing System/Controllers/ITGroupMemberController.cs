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
    public class ITGroupMemberController : Controller
    {
        private readonly IGenericService<ITGroupMemberVM> itgroupmemberService;

        public ITGroupMemberController(ITGroupMemberService _itgroupmemberService)
        {
            itgroupmemberService = _itgroupmemberService;
        }
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create
            ([FromBody] ITGroupMemberVM itgroupmemberVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return itgroupmemberService.Create(itgroupmemberVM);
        }
        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> Delete
            (Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return itgroupmemberService.Delete(id);
        }
        [HttpGet("[action]")]
        public IEnumerable<ITGroupMemberVM> GetAll()
        {
            return itgroupmemberService.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public ITGroupMemberVM GetSingleBy(Guid id)
        {
            return itgroupmemberService.GetSingleBy(id);
        }
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update
            ([FromBody] ITGroupMemberVM itgroupmemberVM)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return itgroupmemberService.Update(itgroupmemberVM);
        }
        [HttpPost("[action]")]
        public ActionResult<PagingResponse<ITGroupMemberVM>> GetDataServerSide([FromBody]PagingRequest paging)
        {
            return itgroupmemberService.GetDataServerSide(paging);
        }
    }

   
}