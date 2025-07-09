using ApplicationLayer.Contract;
using EContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class SubAccTypeRepo:GenericRepo<SubAccountsType, int>, ISubAccType
    {
        public SubAccTypeRepo(TContext con):base(con) 
        {
            
        }
    }
}
