using ApplicationLayer.Contract;
using ApplicationLayer.Mapper;
using AutoMapper;
using DTOS.JV;
using DTOS.Shared;
using DTOS.SubACC;
using EContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class JVService : IJvService
    {
        private readonly IJvReposatiry _JvRepo;
        private readonly IMapper _Map;

        public JVService(IJvReposatiry JvRepo, IMapper Map)
        {
            _JvRepo = JvRepo;
            _Map = Map;
        }

        public async Task<ResultView<JVCreateOrUpdateDTO>> CreateAsync(JVCreateOrUpdateDTO Entity)
        {
            var res = new ResultView<JVCreateOrUpdateDTO>();
            try
            {

                if (Entity != null)
                {
                    if (Entity.Jvno == null || Entity.Jvno == 0)
                    {
                        var lastJvNo = (await _JvRepo.GetAllAsync())
                                        .Where(j => j.Jvno.HasValue)
                                        .Max(j => (int?)j.Jvno) ?? 0;

                        Entity.Jvno = lastJvNo + 1;
                        
                    }


                    var entity = _Map.Map<Jv>(Entity);
                    entity.TotalDebit = entity.Jvdetails.Sum(x => x.Debit);
                    entity.TotalCredit = entity.Jvdetails.Sum(x => x.Credit);
                    var Sucess = await _JvRepo.CreateAsync(entity);
                    var Save = await _JvRepo.SaveChangesAsync();

                    var Returend = _Map.Map<JVCreateOrUpdateDTO>(Sucess);


                    res.IsSucess = true;
                    res.Entity = Returend;
                    res.MSG = "Jv created successfully.";

                    return res;

                }


                res.IsSucess = false;
                res.MSG = "Error Exist";
                return res;



            }
            catch (Exception ex)
            {
                res.IsSucess = false;
                res.MSG = $"Exception: {ex.Message}";

            }
            return res;
        }

        public async Task<ResultView<JVGetAllDTO>> DeleteAsync(int Id)
        {
            var result = new ResultView<JVGetAllDTO>();

            try
            {
                if (Id == null || Id == 0)
                {
                    result.IsSucess = false;
                    result.MSG = "The entity to delete cannot be null.";
                    return result;
                }


                var Jv = (await _JvRepo.GetAllAsync()).FirstOrDefault(p => p.Id == Id);
                if (Jv == null)
                {
                    result.IsSucess = false;
                    result.MSG = "No Jv found with the provided ID.";
                    return result;
                }

                await _JvRepo.DeleteAsync(Jv);
                await _JvRepo.SaveChangesAsync();

                var deletedProductDto = _Map.Map<JVGetAllDTO>(Jv);

                result.IsSucess = true;
                result.Entity = deletedProductDto;
                result.MSG = "Jv deleted successfully.";
            }
            catch (Exception ex)
            {
                
                result.IsSucess = false;
                result.MSG = $"An error occurred while deleting the Jv: {ex.Message}";
            }

            return result;
        }

        public async Task<List<JVGetAllDTO>> GetAllAsync()
        {
            try
            {
                var Jv = (await _JvRepo.GetAllAsync())
                    .Include(p => p.Jvdetails)
                    .Include(p => p.Branch);



                if (!Jv.Any())
                {
                    return new List<JVGetAllDTO>();
                }
                var Sucess = _Map.Map<List<JVGetAllDTO>>(Jv);

                return Sucess;

            }
            catch (Exception ex)
            {
                throw new Exception("No Jv found.");
            }
        }

        public async Task<ResultView<JVGetAllDTO>> GetOneAsync(int Id)
        {
            var result = new ResultView<JVGetAllDTO>();

            try
            {
                var Getone = (await _JvRepo.GetAllAsync())
                    .Include(p => p.Jvdetails)
                    .Include(p => p.Branch)
                    .FirstOrDefault(p => p.Id == Id);

                if (Getone == null)
                {
                    result.IsSucess = false;
                    result.MSG = "No Jv found with the provided ID.";
                    return result;
                }

                var successEntity = _Map.Map<JVGetAllDTO>(Getone);
                result.IsSucess = true;
                result.Entity = successEntity;
                result.MSG = "Jv retrieved successfully.";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.MSG = $"An error occurred while retrieving the Jv: {ex.Message}";
            }

            return result;
        }
        public async Task<JVGetAllDTO> GetByJvNoAsync(int jvNo)
        {

            var jvEntity = (await _JvRepo.GetByJvNoAsync(jvNo));
            if (jvEntity == null)
                return null;

            return _Map.Map<JVGetAllDTO>(jvEntity);
        }

        public async Task<ResultView<JVCreateOrUpdateDTO>> UpdateAsync(JVCreateOrUpdateDTO Entity)
        {
            var res = new ResultView<JVCreateOrUpdateDTO>();
            try
            {
                if (Entity != null)
                {
                    var Exist = (await _JvRepo.GetAllAsync()).Any(p => p.Id == Entity.Id);

                    if (!Exist)
                    {
                        res.IsSucess = false;
                        res.MSG = "JV not found.";
                        return res;
                    }

                    var entity = _Map.Map<Jv>(Entity);
                    entity.TotalDebit = entity.Jvdetails.Sum(x => x.Debit);
                    entity.TotalCredit = entity.Jvdetails.Sum(x => x.Credit);

                    var Sucess = await _JvRepo.UpdateAsync(entity);
                    var Save = await _JvRepo.SaveChangesAsync();

                    var Returned = _Map.Map<JVCreateOrUpdateDTO>(Sucess);

                    res.IsSucess = true;
                    res.Entity = Returned;
                    res.MSG = "JV updated successfully.";
                    return res;
                }

                res.IsSucess = false;
                res.MSG = "Invalid data.";
                return res;
            }
            catch (Exception ex)
            {
                res.IsSucess = false;
                res.MSG = $"Exception: {ex.Message}";
                return res;
            }
        }
    }
}
