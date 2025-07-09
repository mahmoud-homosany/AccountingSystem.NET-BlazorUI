using ApplicationLayer.Contract;
using AutoMapper;
using DTOS.ACC;
using DTOS.JV;
using EContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class AccService : IAccService
    {
        //private readonly IAccReposatiry _ACCRepo;
        private readonly IGenericReposatiry<Account,int> _ACCRepo;
        private readonly IMapper _Map;

        public AccService(IAccReposatiry ACCRepo,IMapper Map)
        {
            _ACCRepo = ACCRepo;
            _Map = Map;
        }
        public async Task<List<AccountGetAllDTO>> GetAllAsync()
        {
            try
            {
                var Acc = (await _ACCRepo.GetAllAsync());
                    



                if (!Acc.Any())
                {
                    return new List<AccountGetAllDTO>();
                }
                var Sucess = _Map.Map<List<AccountGetAllDTO>>(Acc);

                return Sucess;

            }
            catch (Exception ex)
            {
                throw new Exception("No Acc found.");
            }
        }
    }
}
