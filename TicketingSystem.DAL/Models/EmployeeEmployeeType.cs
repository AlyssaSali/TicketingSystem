using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketingSystem.DAL.Models
{
    public class EmployeeEmployeeType
    {
        [Key]
        public Guid EmployeeEmployeeTypeid { get; set; }
        [ForeignKey("EmployeeType")]
        public Guid EmployeeTypeid { get; set; }
        public EmployeeType EmployeeType { get; set; }


        public List<TypeEmployee> TypeEmployees { get; set; }
    }
}
