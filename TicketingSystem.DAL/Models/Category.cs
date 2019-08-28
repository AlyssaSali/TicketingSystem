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
        public DateTime DateCreated { get; set; }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD

=======
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
        public virtual ICollection<CategoryList> CategoryLists { get; set; }
    }
}
