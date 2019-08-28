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
        public string CategoryType { get; set; }
        public int SlaResponseTime { get; set; }
        public string SlaResponseTimeExt { get; set; }
        public int SlaResolvedTime { get; set; }
        public string SlaResolvedTimeExt { get; set; }
        public string Categoryid { get; set; }
        public CategoryVM Category { get; set; }
        public string Severityid { get; set; }
        public SeverityVM Severity { get; set; }
        public string ITGroupid { get; set; }
        public ITGroupVM ITGroup { get; set; }

    }
}
