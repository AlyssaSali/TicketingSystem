using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Helpers;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Services
{
    public class CategoryService : IGenericService<CategoryVM>
    {
        private ToViewModel toViewModel = new ToViewModel();
        private ToModel toModel = new ToModel();
        private readonly TicketingSystemContext context;

        public CategoryService(TicketingSystemContext _context)
        {
            context = _context;
        }
        public ResponseVM Create(CategoryVM categoryVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        categoryVM.categoryid = Guid.NewGuid();
                        context.Categories.Add(toModel.Category(categoryVM));
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("created", true, "Category");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("created", false, "Category", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public ResponseVM Delete(Guid id)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Category categoryToBeDeleted = context.Categories.Find(id);
                        if (categoryToBeDeleted == null)
                            return new ResponseVM("deleted", false, "Category", ResponseVM.DOES_NOT_EXIST);

                        context.Categories.Remove(categoryToBeDeleted);
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("deleted", true, "Category");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("deleted", false, "Category", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public IEnumerable<CategoryVM> GetAll()
        {
            using (context)
            {
                try
                {
                    var categories = context.Categories.ToList().OrderByDescending(x => x.categoryid);
                    var categoriesVm = categories.Select(x => toViewModel.Category(x));
                    return categoriesVm;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public CategoryVM GetSingleBy(Guid id)
        {
            using (context)
            {
                try
                {
                    var categories = context.Categories.Find(id);
                    CategoryVM categoryVM = null;
                    if (categories != null)
                        categoryVM = toViewModel.Category(categories);
                    return categoryVM;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        public ResponseVM Update(CategoryVM categoryVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Category categoryToBeUpdated = context.Categories.Find(categoryVM.categoryid);
                        if (categoryToBeUpdated == null)
                            return new ResponseVM("updated", false, "Category", ResponseVM.DOES_NOT_EXIST);

                        categoryToBeUpdated.CategoryName = categoryVM.CategoryName;
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("updated", true, "Category");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("updated", false, "Category", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
    }
}

