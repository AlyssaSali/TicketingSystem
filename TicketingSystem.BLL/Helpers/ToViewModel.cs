using System;
using System.Collections.Generic;
using System.Text;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModels;

namespace TicketingSystem.BLL.Helpers
{
    public class ToViewModel
    {
       public SeverityVM Severity(Severity severity)
       {
            return new SeverityVM
            {
                ID = severity.ID,
                SeverityCode = severity.SeverityCode,
                SeverityDesc = severity.SeverityDesc
            };
       }
    }
}
