using DTOS.ACC;
using DTOS.JVDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IAccService
    {
        Task<List<AccountGetAllDTO>> GetAllAsync();
    }
}
