using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class ITGroupVM
    {
        public Guid ITGroupid { get; set; }

        public string ITGroupCode { get; set; }
        [Required]
        public string ITGroupName { get; set; }
    }
}
