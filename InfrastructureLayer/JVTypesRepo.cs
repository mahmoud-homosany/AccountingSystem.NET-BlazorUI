using ApplicationLayer.Contract;
using EContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class JVTypesRepo:GenericRepo<Jvtype ,int>,IJVTypesReposatiry
    {
        public JVTypesRepo(TContext con):base(con) 
        {
            
        }
    }
}
