using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class TicketController : Controller
    {
        private readonly IGenericService<TicketVM> ticketService;

        public TicketController(TicketService _ticketService)
        {
            ticketService = _ticketService;
        }

        
        //api/Book/SearchTicket/id
        [HttpGet("[action]/{id}")]
        public TicketVM SearchTicket(Guid id)
        {
            return ticketService.GetSingleBy(id);
        }

        //api/Book/ListTicket/id
        [HttpGet("[action]")]
        public IEnumerable<TicketVM> ListTicket()
        {
            return ticketService.GetAll();
        }

        //api/Book/AddTicket
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> AddTicket([FromBody]TicketVM ticketVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            return ticketService.Create(ticketVM);
        }

        //api/Book/UpdateTicket
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> UpdateTicket([FromBody]TicketVM ticketVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            return ticketService.Update(ticketVM);
        }

        //api/Book/DeleteTicket/id
        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> DeleteTicket(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            return ticketService.Delete(id);
        }

        public ActionResult<PagingResponse<TicketVM>> GetDataServerSide([FromBody]PagingRequest paging)
        {
            return ticketService.GetDataServerSide(paging);
        }
    }
}