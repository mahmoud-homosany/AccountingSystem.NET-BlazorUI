using DTOS.JV;
using EContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contract
{
    public interface IJvReposatiry:IGenericReposatiry<Jv,int>
    {
        Task<Jv> GetByJvNoAsync(int jvNo);
    }
}

