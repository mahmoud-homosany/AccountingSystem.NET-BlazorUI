using ApplicationLayer.Contract;
using AutoMapper;
using DTOS.ACC;
using DTOS.SubAccType;
using EContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class SubAccTypeService : ISubAccTypeService
    {
        private readonly ISubAccType _SubACCRepo;
        private readonly IMapper _Map;
        public SubAccTypeService(IMapper Map, ISubAccType SubACCRepo)
        {
            _Map = Map;
            _SubACCRepo= SubACCRepo;
        }
        public async Task<List<SubAccTypeDto>> GetAllAsync()
        {
            try
            {
                var Acc = (await _SubACCRepo.GetAllAsync());




                if (!Acc.Any())
                {
                    return new List<SubAccTypeDto>();
                }
                var Sucess = _Map.Map<List<SubAccTypeDto>>(Acc);

                return Sucess;

            }
            catch (Exception ex)
            {
                throw new Exception("No SubAcc found.");
            }
        }
    }
}
