using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static TicketingSystem.ViewModel.ViewModels.DatatableVM;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Services;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;

namespace Ticketing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeEmployeeTypeController : Controller
    {
        private readonly IGenericService<EmployeeEmployeeTypeVM> employeeEmployeeTypeService;

        public EmployeeEmployeeTypeController(EmployeeEmployeeTypeService _employeeEmployeeTypeService)
        {
            employeeEmployeeTypeService = _employeeEmployeeTypeService;
        }
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create
            ([FromBody] EmployeeEmployeeTypeVM employeeEmployeeTypeVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return employeeEmployeeTypeService.Create(employeeEmployeeTypeVM);
        }
        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> Delete
            (Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return employeeEmployeeTypeService.Delete(id);
        }
        [HttpGet("[action]")]
        public IEnumerable<EmployeeEmployeeTypeVM> GetAll()
        {
            return employeeEmployeeTypeService.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public EmployeeEmployeeTypeVM GetSingleBy(Guid id)
        {
            return employeeEmployeeTypeService.GetSingleBy(id);
        }
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update
            ([FromBody] EmployeeEmployeeTypeVM employeeEmployeeTypeVM)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return employeeEmployeeTypeService.Update(employeeEmployeeTypeVM);
        }
        [HttpPost("[action]")]
        public ActionResult<PagingResponse<EmployeeEmployeeTypeVM>> GetDataServerSide([FromBody]PagingRequest paging)
        {
            return employeeEmployeeTypeService.GetDataServerSide(paging);
        }
    }

}