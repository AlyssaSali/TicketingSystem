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
    public class CategoryListController : Controller
    {
        private readonly IGenericService<CategoryListVM> categorylistService;

        public CategoryListController(CategoryListService _categorylistService)
        {
            categorylistService = _categorylistService;
        }
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create
            ([FromBody] CategoryListVM categorylistVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return categorylistService.Create(categorylistVM);
        }
        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return categorylistService.Delete(id);
        }
        [HttpGet("[action]")]
        public IEnumerable<CategoryListVM> GetAll()
        {
            return categorylistService.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public CategoryListVM GetSingleBy(Guid id)
        {
            return categorylistService.GetSingleBy(id);
        }
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update
            ([FromBody] CategoryListVM categorylistVM)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return categorylistService.Update(categorylistVM);
        }
    }

}
