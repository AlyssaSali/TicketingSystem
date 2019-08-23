using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class CategoryVM
    {
        
            public Guid Categoryid { get; set; }
            [Required]
            public string CategoryName { get; set; }
<<<<<<< HEAD
=======
            public DateTime DateCreated { get; set; }

>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15

    }
}
