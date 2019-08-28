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
        public virtual ICollection<CategoryList> CategoryLists { get; set; }
    }
}
