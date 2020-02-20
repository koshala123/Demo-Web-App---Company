using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.DTO
{
    public class CompanyTableDTO
    {
        public int id { get; set; }
        public string CompanyName { get; set; }
        public string SystemName { get; set; }
        public string IssueType { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DateTime { get; set; }
        public int RequestNumber { get; set; }
        public string RequestName { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string Error { get; set; }
        public bool? Active { get; set; }
        public int DueDate { get; set; }
    }
}
