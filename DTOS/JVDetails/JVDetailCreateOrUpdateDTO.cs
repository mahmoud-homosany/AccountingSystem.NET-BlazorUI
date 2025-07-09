using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.JVDetails
{
    public class JVDetailCreateOrUpdateDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? SubAccountId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string? Notes { get; set; }
        public string? DocumentNumber { get; set; }
    }
}
