using ApplicationLayer.Contract;
using DTOS.JV;
using EContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public class JVRepo:GenericRepo<Jv , int>, IJvReposatiry
    {
        private readonly TContext _con;

        public JVRepo(TContext con):base(con)
        {
            _con = con;
        }

        public async Task<Jv> GetByJvNoAsync(int jvNo)
        {
            return await _con.Jvs
        .Include(j => j.Jvdetails)
            .ThenInclude(d => d.Account)         
        .Include(j => j.Jvdetails)
            .ThenInclude(d => d.SubAccount)     
            .Include(p=>p.Branch)
        .FirstOrDefaultAsync(j => j.Jvno == jvNo);
        }
    }
}
