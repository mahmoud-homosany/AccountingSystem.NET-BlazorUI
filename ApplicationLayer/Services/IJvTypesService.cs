using DTOS.ACC;
using DTOS.JvTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IJvTypesService
    {
        Task<List<JvTyprsDTO>> GetAllAsync();
    }
}
