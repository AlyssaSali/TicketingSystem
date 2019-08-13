using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class OfficeVM
    {
        
            public Guid Officeid { get; set; }

            public string OfficeCode { get; set; }
            [Required]
            public string OfficeDesc { get; set; }
        

    }
}
