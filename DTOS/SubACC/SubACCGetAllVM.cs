using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.SubACC
{
    public class SubACCGetAllVM
    {
        
        public int Id { get; set; }
      
        public string SubAccountNumber { get; set; }

       
        public string SubAccountNameAr { get; set; }

    
        public string SubAccountNameEn { get; set; }

      
        public bool? IsMain { get; set; }


        public int? SubAccountTypeId { get; set; }
        public string? SubAccountTypeNames { get; set; }

        public int? BranchId { get; set; }
        public string? BranchName { get; set; }



    }
}
