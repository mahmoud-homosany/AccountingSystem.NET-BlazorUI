using ApplicationLayer.Contract;
using EContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class SubAccRepo:GenericRepo<SubAccount,int>,ISubAccReposatiry
    {

        public SubAccRepo(TContext con):base(con)
        {
            
        }

    }
}
