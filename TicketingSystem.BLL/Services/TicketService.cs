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
using static TicketingSystem.ViewModel.ViewModels.DatatableVM;

namespace TicketingSystem.BLL.Services
{
    public class TicketService : IGenericService<TicketVM>
    {
        private ToViewModel toViewModel = new ToViewModel();
        private ToModel toModel = new ToModel();
        private readonly TicketingSystemContext context;

        //inject dependencies
        public TicketService(TicketingSystemContext _context)
        {
            context = _context;
        }

      
        public ResponseVM Create(TicketVM ticketVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ticketVM.Ticketid = Guid.NewGuid();
                        ticketVM.TrackingStatus = "Request for approval";
                        ticketVM.IsOpen = "True";
                        ticketVM.RequestedBy = "ridz";
                        //converts to book type then save to context
                        context.Tickets.Add(toModel.Ticket(ticketVM));
                        context.SaveChanges();

                        //commits changes to db
                        dbTransaction.Commit();
                        return new ResponseVM("created", true, "Ticket");
                    }
                    catch (Exception ex)
                    {

                        dbTransaction.Rollback();
                        return new ResponseVM("created", false, "Ticket", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }

        public ResponseVM Update(TicketVM ticketVM)
        {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //find ticket from the database
                        Ticket ticketToBeUpdated = context.Tickets.Find(ticketVM.Ticketid);
                        //ends function if ticket does not exists
                        if (ticketToBeUpdated == null)
                        {
                            return new ResponseVM("updated", false, "Ticket", ResponseVM.DOES_NOT_EXIST);
                        }

                        //update changes then save to context
                        ticketToBeUpdated.EmployeeID = ticketVM.EmployeeID;
                        ticketToBeUpdated.Officeid = ticketVM.Officeid;
                        ticketToBeUpdated.DateOfRequest = DateTime.ParseExact(ticketVM.Date + " " + ticketVM.Time, "dd/MM/yyyy HH:mm:ss", null);
                        ticketToBeUpdated.RequestTitle = ticketVM.RequestTitle;
                        ticketToBeUpdated.RequestDesc = ticketVM.RequestDesc;
                        context.SaveChanges();

                        //commit changes to db
                        dbTransaction.Commit();
                        return new ResponseVM("updated", true, "Ticket");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("updated", false, "Ticket", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                    }
                }
            }
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
        public ResponseVM Delete(Guid guid) {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
<<<<<<< HEAD
=======

                    try
                    {
                        Ticket ticketToBeDeleted = context.Tickets.Find(guid);
                        //ends function if employee does not exists
                        if (ticketToBeDeleted == null)
                        {
                            return new ResponseVM("deleted", false, "Employee", ResponseVM.DOES_NOT_EXIST);
                        }
                        //delete employee then save to context
                        context.Tickets.Remove(ticketToBeDeleted);
                        context.SaveChanges();

                        //commit changes to db
                        dbTransaction.Commit();
                        return new ResponseVM("deleted", true, "Ticket");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("deleted", false, "Ticket", ResponseVM.SOMETHING_WENT_WRONG, "", ex);

                    }
                }
            }
        }

        public IEnumerable<TicketVM> GetAll() {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var tickets = context.Tickets
                            .Include(x => x.Office)
                            .Include(x => x.Employee)
                            .ThenInclude(x=>x.EmployeeType)
                            .ToList()
                            .OrderByDescending(x => x.Ticketid);
                        var ticketsVM = tickets.Select(x => toViewModel.Ticket(x));
                        return ticketsVM;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public TicketVM GetSingleBy(Guid id) {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var ticket = context.Tickets
                            .Include(x => x.Office)
                            .Include(x => x.Employee)
                            .Where(x => x.Ticketid == id)
                            .FirstOrDefault();
                        TicketVM ticketVM = null;
                        if (ticket != null)
                        {
                            ticketVM = toViewModel.Ticket(ticket);
                        }
                        return ticketVM;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
<<<<<<< HEAD
=======
<<<<<<< HEAD
        }
=======
        }//dummy data
=======
        public IEnumerable<TicketVM> GetAll()
        {
            throw new NotImplementedException();
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
        }
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

<<<<<<< HEAD
        public DatatableVM.PagingResponse<TicketVM> GetDataServerSide(DatatableVM.PagingRequest paging)
        {
            using (context)
            {

                var pagingResponse = new PagingResponse<TicketVM>()
                {
                    // counts how many times the user draws data
                    Draw = paging.Draw
                };
                // initialized query
                IEnumerable<Ticket> query = null;
                // search if user provided a search value, i.e. search value is not empty
                if (!string.IsNullOrEmpty(paging.Search.Value))
                {
                    // search based from the search value
                    query = context.Tickets.Include(x => x.Office)
                        .Include(x => x.Employee)
                          .Where(v => v.Office.ToString().ToLower().Contains(paging.Search.Value.ToLower()) ||
                          v.Employee.ToString().ToLower().Contains(paging.Search.Value.ToLower()) ||
                          v.RequestTitle.ToString().ToLower().Contains(paging.Search.Value.ToLower()) ||
                          v.RequestDesc.ToString().ToLower().Contains(paging.Search.Value.ToLower()) ||
                          v.IsOpen.ToString().ToLower().Contains(paging.Search.Value.ToLower())
                          );
                }
                else
                {
                    // selects all from table
                    query = context.Tickets;
                }
                // total records from query
                var recordsTotal = query.Count();
                // orders the data by the sorting selected by the user
                // used ternary operator to determine if ascending or descending
                var colOrder = paging.Order[0];
                switch (colOrder.Column)
                {
                    case 0:
                        query = colOrder.Dir == "asc" ? query.OrderBy(v => v.RequestTitle) : query.OrderByDescending(v => v.RequestTitle);
                        break;
=======
                    try
                    {
                        Ticket ticketToBeDeleted = context.Tickets.Find(guid);
                        //ends function if employee does not exists
                        if (ticketToBeDeleted == null)
                        {
                            return new ResponseVM("deleted", false, "Employee", ResponseVM.DOES_NOT_EXIST);
                        }
                        //delete employee then save to context
                        context.Tickets.Remove(ticketToBeDeleted);
                        context.SaveChanges();

                        //commit changes to db
                        dbTransaction.Commit();
                        return new ResponseVM("deleted", true, "Ticket");
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return new ResponseVM("deleted", false, "Ticket", ResponseVM.SOMETHING_WENT_WRONG, "", ex);

                    }
                }
            }
        }
<<<<<<< HEAD

        public IEnumerable<TicketVM> GetAll() {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //gets all employees and order the from last to first
                        var tickets = context.Tickets
                            .Include(x => x.Office)
                            .Include(x => x.Employee)
                            .Include(x => x.CategoryList)
                            .Include(x => x.Severity)
                            .Include(x => x.ITGroup)
                            .ToList()
                            .OrderByDescending(x => x.Ticketid);
                        var ticketsVM = tickets.Select(x => toViewModel.Ticket(x));
                        return ticketsVM;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }//dummy data

        public TicketVM GetSingleBy(Guid id) {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var ticket = context.Tickets
                            .Include(x => x.Office)
                            .Include(x => x.Employee)
                            .Include(x => x.Category)
                            .Include(x => x.Severity)
                            .Include(x => x.ITGroup)
                            .Where(x => x.Ticketid == id)
                            .FirstOrDefault();
                        TicketVM ticketVM = null;
                        if (ticket != null)
                        {
                            ticketVM = toViewModel.Ticket(ticket);
                        }
                        return ticketVM;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }//dummy data
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

                }

                var taken = query.Skip(paging.Start).Take(paging.Length).ToArray();
                // converts model(query) into viewmodel then assigns it to response which is displayed as "data"
                pagingResponse.Reponse = taken.Select(x => toViewModel.Ticket(x));
                pagingResponse.RecordsTotal = recordsTotal;
                pagingResponse.RecordsFiltered = recordsTotal;

                return pagingResponse;
            }
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    }
}
