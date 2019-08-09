using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Services;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;

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

        //api/Severity/Create

        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create([FromBody]SeverityVM severityVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong!");

            }
            return severityService.Create(severityVM);
        }

        //api/Severity/Delete

        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> Delete(Guid id)
        {
            return severityService.Delete(id);
        }

        //api/Severity/GetAll

        [HttpGet("[action]")]
        public IEnumerable<SeverityVM> GetAll()
        {
            return severityService.GetAll();

        }


        //api/Severity/GetSingleBy

        [HttpGet("[action]/{id}")]
        public SeverityVM GetSingleBy(Guid id)
        {
            return severityService.GetSingleBy(id);

        }

        //api/Severity/Update

        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update([FromBody] SeverityVM severityVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong!");

            }
            return severityService.Update(severityVM);
        }

    }
}
