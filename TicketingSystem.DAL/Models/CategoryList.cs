using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class CategoryList
    {
        [Key]
        public Guid CategoryListid { get; set; }
        public string CategoryListName { get; set; }
        public int SlaResponseTime { get; set; }
        public int SlaResolvedTime { get; set; }
        public string ItGroup { get; set; }

        [ForeignKey("Category")]
        public Guid categoryid { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Severity")]
        public Guid severityid { get; set; }
        public Severity Severity { get; set; }
    }
}
