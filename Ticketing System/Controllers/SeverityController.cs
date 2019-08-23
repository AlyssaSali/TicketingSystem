using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Services;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;
using static TicketingSystem.ViewModel.ViewModels.DatatableVM;

namespace Ticketing_System.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SeverityController : Controller
    {
        private readonly IGenericService<SeverityVM> severityService;

        public SeverityController(SeverityService _severityService)
        {
            severityService = _severityService;
        }
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create
            ([FromBody] SeverityVM severityVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return severityService.Create(severityVM);
        }
        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return severityService.Delete(id);
        }
        [HttpGet("[action]")]
        public IEnumerable<SeverityVM> GetAll()
        {
            return severityService.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public SeverityVM GetSingleBy(Guid id)
        {
            return severityService.GetSingleBy(id);
        }
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update
            ([FromBody] SeverityVM severityVM)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return severityService.Update(severityVM);
        }
        public ActionResult<PagingResponse<SeverityVM>> GetDataServerSide([FromBody]PagingRequest paging)
        {
            return severityService.GetDataServerSide(paging);
        }
    }

}
