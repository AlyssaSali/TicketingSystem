using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class CategoryVM
    {
        
            public Guid categoryid { get; set; }
            [Required]
            public string CategoryName { get; set; }
        

    }
}
