﻿using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<ResponseVM> Delete (Guid id)
=======
        public ActionResult<ResponseVM> Delete
            (Guid id)
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
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
        public ActionResult<PagingResponse<OfficeVM>> GetDataServerSide([FromBody]PagingRequest paging)
        {
            return officeService.GetDataServerSide(paging);
        }
    }

}
