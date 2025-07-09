using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.SubACC
{
    public class CreateOrUpdateVM
    {
        public int Id { get; set; }
 
        [StringLength(50)]
       // /Code of Sub acc/
        public string? SubAccountNumber { get; set; }

     
        [StringLength(100)]
        public string? SubAccountNameAr { get; set; }

        [StringLength(100)]
        public string SubAccountNameEn { get; set; }


        public bool? IsMain { get; set; }


        public int? SubAccountTypeId { get; set; }


        public int? BranchId { get; set; } = 1;



    }
}
