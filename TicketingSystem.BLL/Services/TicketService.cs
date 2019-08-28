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
                        ticketVM.DateOfRequest = DateTime.Now;
                        ticketVM.TrackingStatus = "REQUESTFORAPPROVAL";
                        ticketVM.IsOpen = true;
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
                        ticketToBeUpdated.Ticketid = ticketVM.Ticketid;
                        ticketToBeUpdated.CategoryListid = ticketVM.CategoryListid;
                        ticketToBeUpdated.ITGroupid = ticketVM.ITGroupid;
                        ticketToBeUpdated.EmployeeID = ticketVM.EmployeeID;
                        ticketToBeUpdated.Officeid = ticketVM.Officeid;
                        ticketToBeUpdated.DateOfRequest = ticketVM.DateOfRequest;
                        ticketToBeUpdated.FormOfCommu = ticketVM.FormOfCommu;
                        ticketToBeUpdated.ContactInfo = ticketVM.ContactInfo;
                        ticketToBeUpdated.RequestTitle = ticketVM.RequestTitle;
                        ticketToBeUpdated.RequestDesc = ticketVM.RequestDesc;
                        ticketToBeUpdated.Severity = ticketVM.Severity;
                        ticketToBeUpdated.Category = ticketVM.Category;
                        ticketToBeUpdated.TrackingStatus = ticketVM.TrackingStatus;
                        ticketToBeUpdated.ResponseTime = ticketVM.ResponseTime;
                        ticketToBeUpdated.ResolveTime = ticketVM.ResolveTime;
                        ticketToBeUpdated.IsUrgent = ticketVM.IsUrgent;
                        ticketToBeUpdated.IsOpen = ticketVM.IsOpen;
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
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
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
<<<<<<< HEAD
        }
=======
        }//dummy data
=======
        public IEnumerable<TicketVM> GetAll()
        {
            throw new NotImplementedException();
        }
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

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

        public DatatableVM.PagingResponse<TicketVM> GetDataServerSide(DatatableVM.PagingRequest paging)
        {
            throw new NotImplementedException();
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
    }
}
