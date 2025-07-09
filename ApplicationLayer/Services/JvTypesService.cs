using ApplicationLayer.Contract;
using AutoMapper;
using DTOS.ACC;
using DTOS.JvTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class JvTypesService : IJvTypesService
    {
        private readonly IJVTypesReposatiry _JvType;
        private readonly IMapper _Mapper;

        public JvTypesService(IJVTypesReposatiry JvType,IMapper Mapper)
        {
            _JvType = JvType;
            _Mapper = Mapper;
        }
        public async Task<List<JvTyprsDTO>> GetAllAsync()
        {
            try
            {
                var Jv = (await _JvType.GetAllAsync());




                if (!Jv.Any())
                {
                    return new List<JvTyprsDTO>();
                }
                var Sucess = _Mapper.Map<List<JvTyprsDTO>>(Jv);

                return Sucess;

            }
            catch (Exception ex)
            {
                throw new Exception("No Jv found.");
            }
        }
    }
}
