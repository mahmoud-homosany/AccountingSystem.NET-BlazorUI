using ApplicationLayer.Contract;
using EContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class JVDetailsRepo:GenericRepo<Jvdetail,int>,IJVDetailsReposatiry
    {
        public JVDetailsRepo(TContext con):base(con)
        {
            
        }
    }
}
