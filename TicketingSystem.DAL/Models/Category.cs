using System;
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
<<<<<<< HEAD

=======
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
        public virtual ICollection<CategoryList> CategoryLists { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
