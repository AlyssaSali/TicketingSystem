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
    public class CategoryController : Controller
    {
        private readonly IGenericService<CategoryVM> categoryService;

        public CategoryController(CategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        [HttpPost("[action]")]
        public ActionResult<ResponseVM> Create
            ([FromBody] CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return categoryService.Create(categoryVM);
        }
        [HttpDelete("[action]/{id}")]
        public ActionResult<ResponseVM> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return categoryService.Delete(id);
        }
        [HttpGet("[action]")]
        public IEnumerable<CategoryVM> GetAll()
        {
            return categoryService.GetAll();
        }
        [HttpGet("[action]/{id}")]
        public CategoryVM GetSingleBy(Guid id)
        {
            return categoryService.GetSingleBy(id);
        }
        [HttpPut("[action]")]
        public ActionResult<ResponseVM> Update
            ([FromBody] CategoryVM categoryVM)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            return categoryService.Update(categoryVM);
        }
    }

}
