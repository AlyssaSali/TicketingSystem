using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class SeverityVM
    {
        public Guid ID { get; set; }

        [Required]
        public string SeverityCode { get; set; }
        public string SeverityDesc { get; set; }
    }
}
