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
    public class EmployeeController : Controller
    {
        private readonly IGenericService<EmployeeVM> employeeService;

        public EmployeeController(EmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        //finds specific employee/s
        //api/Book/FindEmployee/id
        [HttpGet("[action]/{id}")]
        public EmployeeVM FindEmployee(Guid id) {
            return employeeService.GetSingleBy(id);
        }

        //populates employee table
        //api/Book/GetSingleBy/id
        [HttpGet("[action]")]
        public IEnumerable<EmployeeVM> ListEmployees() {
            return employeeService.GetAll();
        }

        //create employee
        //api/Book/Create
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> CreateEmployee([FromBody]EmployeeVM employeeVM) {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            return employeeService.Create(employeeVM);
        }

        //edit employee
        //api/Book/Update
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> UpdateEmployee([FromBody]EmployeeVM employeeVM) {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            return employeeService.Update(employeeVM);
        }


        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> DeleteEmployee(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            return employeeService.Delete(id);
        }
    }
}