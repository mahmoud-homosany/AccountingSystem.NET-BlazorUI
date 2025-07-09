using DTOS.JVDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.JV
{
    public class JVCreateOrUpdateDTO
    {
        public int Id { get; set; }
        public int? Jvno { get; set; } 
        public int JVTypeId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Notes { get; set; }
        public int? BranchId { get; set; } = 1;
        public decimal TotalDebit {  get; set; }
        public decimal TotalCredit {  get; set; }
        public List<JVDetailCreateOrUpdateDTO> Details { get; set; } = new List<JVDetailCreateOrUpdateDTO>();
    }
}
