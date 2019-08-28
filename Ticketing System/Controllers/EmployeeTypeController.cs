using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Services;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;

namespace Ticketing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : Controller
    {
        private readonly IGenericService<EmployeeTypeVM> employeeTypeService;

        public EmployeeTypeController(EmployeeTypeService _employeeTypeService)
        {
            employeeTypeService = _employeeTypeService;
        }
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create([FromBody] EmployeeTypeVM employeetypeVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return employeeTypeService.Create(employeetypeVM);
        }

        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return employeeTypeService.Delete(id);
        }

        [HttpGet("[action]")]
        public IEnumerable<EmployeeTypeVM> GetAll()
        {
            return employeeTypeService.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public EmployeeTypeVM GetSingleBy(Guid id)
        {
            return employeeTypeService.GetSingleBy(id);
        }
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update([FromBody] EmployeeTypeVM employeetypeVM)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return employeeTypeService.Update(employeetypeVM);
        }
    }
}