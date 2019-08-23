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
        public string CategoryType { get; set; }
        public int SlaResponseTime { get; set; }
        public string SlaResponseTimeExt { get; set; }
        public int SlaResolvedTime { get; set; }
        public string SlaResolvedTimeExt { get; set; }

        [ForeignKey("Category")]
        public Guid Categoryid { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Severity")]
        public Guid Severityid { get; set; }
        public Severity Severity { get; set; }

        [ForeignKey("ITGroup")]
        public Guid ITGroupid { get; set; }
        public ITGroup ITGroup { get; set; }

        public virtual ICollection<TicketMinor> TicketMinors { get; set; }
    }
}
