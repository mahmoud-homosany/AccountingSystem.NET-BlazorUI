using DTOS.Shared;
using DTOS.SubACC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface ISubAccService
    {
        Task<ResultView<CreateOrUpdateVM>> CreateAsync(CreateOrUpdateVM Entity);
        Task<ResultView<CreateOrUpdateVM>> UpdateAsync(CreateOrUpdateVM Entity);
        Task<List<SubACCGetAllVM>> GetAllAsync();
        Task<ResultView<SubACCGetAllVM>> GetOneAsync(int Id);
        Task<ResultView<SubACCGetAllVM>> DeleteAsync(int Id);
    }
}
