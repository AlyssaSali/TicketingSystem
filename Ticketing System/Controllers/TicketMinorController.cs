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
    public class TicketMinorController : Controller
    {
        private readonly IGenericService<TicketMinorVM> ticketMinorService;

        public TicketMinorController(TicketMinorService _ticketMinorService)
        {
            ticketMinorService = _ticketMinorService;
        }
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create
            ([FromBody] TicketMinorVM ticketMinorVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return ticketMinorService.Create(ticketMinorVM);
        }
        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return ticketMinorService.Delete(id);
        }
        [HttpGet("[action]")]
        public IEnumerable<TicketMinorVM> GetAll()
        {
            return ticketMinorService.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public TicketMinorVM GetSingleBy(Guid id)
        {
            return ticketMinorService.GetSingleBy(id);
        }
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update
            ([FromBody] TicketMinorVM ticketMinorVM)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return ticketMinorService.Update(ticketMinorVM);
        }
    }

}
