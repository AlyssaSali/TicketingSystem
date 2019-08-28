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
        public ResponseVM Delete(Guid guid) {
            using (context)
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {

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
        }

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

                }

                var taken = query.Skip(paging.Start).Take(paging.Length).ToArray();
                // converts model(query) into viewmodel then assigns it to response which is displayed as "data"
                pagingResponse.Reponse = taken.Select(x => toViewModel.Ticket(x));
                pagingResponse.RecordsTotal = recordsTotal;
                pagingResponse.RecordsFiltered = recordsTotal;

                return pagingResponse;
            }
        }
    }
}
