using DTOS.JV;
using DTOS.Shared;
using DTOS.SubACC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IJvService
    {
        Task<ResultView<JVCreateOrUpdateDTO>> CreateAsync(JVCreateOrUpdateDTO Entity);
        Task<ResultView<JVCreateOrUpdateDTO>> UpdateAsync(JVCreateOrUpdateDTO Entity);
        Task<JVGetAllDTO> GetByJvNoAsync(int jvNo);
        Task<List<JVGetAllDTO>> GetAllAsync();
        Task<ResultView<JVGetAllDTO>> GetOneAsync(int Id);
        Task<ResultView<JVGetAllDTO>> DeleteAsync(int Id);
    }
}
