using DTOS.JVDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.JV
{
    public class JVGetAllDTO
    {
        public int Id { get; set; }
        public int? JvNo { get; set; }
        public int JVTypeId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal TotalDebit => Details?.Sum(x => x.Debit) ?? 0;
        public decimal TotalCredit => Details?.Sum(x => x.Credit) ?? 0;
        public List<JVDetailsGetAllDTO> Details { get; set; }
    }
}
