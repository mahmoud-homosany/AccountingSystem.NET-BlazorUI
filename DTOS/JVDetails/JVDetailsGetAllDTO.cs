using DTOS.JV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.JVDetails
{
    public class JVDetailsGetAllDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int? SubAccountId { get; set; }
        public string SubAccountName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string? Notes { get; set; }
        public string? DocumentNumber { get; set; }
      
    }
}
