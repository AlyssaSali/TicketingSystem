using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketingSystem.ViewModel.ViewModels
{
    public class CategoryListVM
    {
        public Guid CategoryListid { get; set; }
        public string CategoryListName { get; set; }
        public int SlaResponseTime { get; set; }
        public int SlaResolvedTime { get; set; }
        public string ItGroup { get; set; }

        [Required]
        public Guid categoryid { get; set; }
        public CategoryVM Category { get; set; }

        [Required]
        public Guid severityid { get; set; }
        public SeverityVM Severity { get; set; }

    }
}
