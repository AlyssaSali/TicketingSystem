using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class ApplicationSettingsVM
    {
        public string JWT_Secret { get; set; }
        public string Client_Url { get; set; }
    }
}
