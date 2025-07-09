using DTOS.JV;
using DTOS.SubAccType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface ISubAccTypeService
    {
        Task<List<SubAccTypeDto>> GetAllAsync();
    }
}
