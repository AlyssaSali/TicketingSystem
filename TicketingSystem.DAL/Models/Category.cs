﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Category
    {
        [Key]
        public Guid Categoryid { get; set; }
        public string CategoryName { get; set; }

<<<<<<< HEAD
=======
        public DateTime DateCreated { get; set; }
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
        public virtual ICollection<CategoryList> CategoryLists { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
