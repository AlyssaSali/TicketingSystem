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
    public class OfficeController : Controller
    {
        private readonly IGenericService<OfficeVM> officeService;

        public OfficeController(OfficeService _officeService)
        {
            officeService = _officeService;
        }
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create
            ([FromBody] OfficeVM officeVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return officeService.Create(officeVM);
        }
        [HttpDelete("[action]/{id}")]
<<<<<<< HEAD
        public ActionResult<ResponseVM> Delete(Guid id)
=======
<<<<<<< HEAD
        public ActionResult<ResponseVM> Delete(Guid id)
=======
        public ActionResult<ResponseVM> Delete
            (Guid id)
>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
>>>>>>> af8a36911860fc01eb54fa1355606495cc985b86
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return officeService.Delete(id);
        }
        [HttpGet("[action]")]
        public IEnumerable<OfficeVM> GetAll()
        {
            return officeService.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public OfficeVM GetSingleBy(Guid id)
        {
            return officeService.GetSingleBy(id);
        }
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update
            ([FromBody] OfficeVM officeVM)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return officeService.Update(officeVM);
        }
    }

}
