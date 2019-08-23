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
    public class CategoryListService : IGenericService<CategoryListVM>
    {
        private ToViewModel toViewModel = new ToViewModel();
        private ToModel toModel = new ToModel();
        private readonly TicketingSystemContext context;

        public CategoryListService(TicketingSystemContext _context)
        {
            context = _context;
        }
        public ResponseVM Create(CategoryListVM categoryListVM)
        {
            using (context)
            {
                if (context.CategoryLists.Where(x => x.CategoryListName == categoryListVM.CategoryListName).Any())
                {
                    return new ResponseVM("created", false, "CategoryList", ResponseVM.ALREADY_EXIST);
                }

                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        categoryListVM.CategoryListid = Guid.NewGuid();
                        context.CategoryLists.Add(toModel.CategoryList(categoryListVM));
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("created", true, "CategoryList");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("created", false, "CategoryList", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
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
                        CategoryList categoryListToBeDeleted = context.CategoryLists.Find(id);
                        if (categoryListToBeDeleted == null)
                            return new ResponseVM("deleted", false, "CategoryList", ResponseVM.DOES_NOT_EXIST);

                        context.CategoryLists.Remove(categoryListToBeDeleted);
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("deleted", true, "CategoryList");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("deleted", false, "CategoryList", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
        public IEnumerable<CategoryListVM> GetAll()
        {
            using (context)
            {
                try
                {
                    var categories = context.CategoryLists
                        .Include(x => x.Category)
                        .Include(x => x.Severity)
                        .Include(x => x.ITGroup)
                        .ToList().OrderByDescending(x => x.CategoryListid);
                    var categoriesVm = categories.Select(x => toViewModel.CategoryList(x));
                    return categoriesVm;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public CategoryListVM GetSingleBy(Guid id)
        {
            using (context)
            {
                try
                {
                    var categories = context.CategoryLists.Find(id);
                    CategoryListVM categoryListVM = null;
                    if (categories != null)
                        categoryListVM = toViewModel.CategoryList(categories);
                    return categoryListVM;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        public ResponseVM Update(CategoryListVM categoryListVM)
        {
            using (context)
            {
                if (context.CategoryLists.Where(x => x.CategoryListName == categoryListVM.CategoryListName &&
                                                     x.CategoryType == categoryListVM.CategoryType &&
                                                     x.SlaResponseTime == categoryListVM.SlaResponseTime &&
                                                     x.SlaResponseTimeExt == categoryListVM.SlaResponseTimeExt &&
                                                     x.SlaResolvedTime == categoryListVM.SlaResolvedTime &&
                                                     x.SlaResolvedTimeExt == categoryListVM.SlaResolvedTimeExt &&
                                                     x.Categoryid == Guid.Parse(categoryListVM.Categoryid) &&
                                                     x.Severityid == Guid.Parse(categoryListVM.Severityid) &&
                                                     x.ITGroupid == Guid.Parse(categoryListVM.ITGroupid)).Any())
                {
                    return new ResponseVM("updated", false, "CategoryList", ResponseVM.NO_NEW_DATA);
                }
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CategoryList categoryListToBeUpdated = context.CategoryLists.Find(categoryListVM.CategoryListid);
                        if (categoryListToBeUpdated == null)
                            return new ResponseVM("updated", false, "CategoryList", ResponseVM.DOES_NOT_EXIST);

                        categoryListToBeUpdated.CategoryListName = categoryListVM.CategoryListName;
                        categoryListToBeUpdated.CategoryType = categoryListVM.CategoryType;
                        categoryListToBeUpdated.SlaResponseTime = categoryListVM.SlaResponseTime;
                        categoryListToBeUpdated.SlaResponseTimeExt = categoryListVM.SlaResponseTimeExt;
                        categoryListToBeUpdated.SlaResolvedTime = categoryListVM.SlaResolvedTime;
                        categoryListToBeUpdated.SlaResolvedTimeExt = categoryListVM.SlaResolvedTimeExt;
                        categoryListToBeUpdated.Categoryid = Guid.Parse(categoryListVM.Categoryid);
                        categoryListToBeUpdated.Severityid = Guid.Parse(categoryListVM.Severityid);
                        categoryListToBeUpdated.ITGroupid = Guid.Parse(categoryListVM.ITGroupid);
                        context.SaveChanges();

                        dbTransaction.Commit();
                        return new ResponseVM("updated", true, "CategoryList");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("updated", false, "CategoryList", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
    }
}

