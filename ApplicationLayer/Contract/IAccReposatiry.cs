using EContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contract
{
    public interface IAccReposatiry:IGenericReposatiry<Account , int>
    {
    }
}
