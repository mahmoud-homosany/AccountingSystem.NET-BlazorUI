using DTOS.JV;
using DTOS.JVDetails;
using DTOS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IJVDetailsService
    {
        Task<ResultView<JVDetailCreateOrUpdateDTO>> CreateAsync(JVDetailCreateOrUpdateDTO Entity);
        Task<ResultView<JVDetailCreateOrUpdateDTO>> UpdateAsync(JVDetailCreateOrUpdateDTO Entity);
        Task<List<JVDetailsGetAllDTO>> GetAllAsync();
        Task<ResultView<JVDetailsGetAllDTO>> GetOneAsync(int Id);
        Task<ResultView<JVDetailsGetAllDTO>> DeleteAsync(int Id);
    }
}
