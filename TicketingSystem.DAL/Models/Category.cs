using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class Category
    {
        [Key]
        public Guid categoryid { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}
