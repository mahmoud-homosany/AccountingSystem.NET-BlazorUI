using ApplicationLayer.Contract;
using AutoMapper;
using DTOS.JV;
using DTOS.JVDetails;
using DTOS.Shared;
using EContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class JVDetailsService : IJVDetailsService
    {
        private readonly IJVDetailsReposatiry _JvDetail;
        private readonly IMapper _Map;

        public JVDetailsService(IJVDetailsReposatiry JvDetail,IMapper Map)
        {
            _JvDetail = JvDetail;
            _Map = Map;
        }
        public async Task<ResultView<JVDetailCreateOrUpdateDTO>> CreateAsync(JVDetailCreateOrUpdateDTO Entity)
        {
            var res = new ResultView<JVDetailCreateOrUpdateDTO>();
            try
            {

                if (Entity != null)
                {
                    //if (Entity.JvNo == null || Entity.JvNo == 0)
                    //{
                    //    var lastJvNo = (await _JvRepo.GetAllAsync())
                    //                    .Where(j => j.Jvno.HasValue)
                    //                    .Max(j => (int?)j.Jvno) ?? 0;

                    //    Entity.JvNo = lastJvNo + 1;
                    //}


                    var entity = _Map.Map<Jvdetail>(Entity);

                    var Sucess = await _JvDetail.CreateAsync(entity);
                    var Save = await _JvDetail.SaveChangesAsync();

                    var Returend = _Map.Map<JVDetailCreateOrUpdateDTO>(Sucess);


                    res.IsSucess = true;
                    res.Entity = Returend;
                    res.MSG = "JvDetails created successfully.";

                    return res;

                }


                res.IsSucess = false;
                res.MSG = "Already Exist";
                return res;



            }
            catch (Exception ex)
            {
                res.IsSucess = false;
                res.MSG = "Already Exist";

            }
            return res;
        }

        public async Task<ResultView<JVDetailsGetAllDTO>> DeleteAsync(int Id)
        {
            var result = new ResultView<JVDetailsGetAllDTO>();

            try
            {
                if (Id == null || Id == 0)
                {
                    result.IsSucess = false;
                    result.MSG = "The entity to delete cannot be null.";
                    return result;
                }


                var JvDetail = (await _JvDetail.GetAllAsync()).FirstOrDefault(p => p.Id == Id);
                if (JvDetail == null)
                {
                    result.IsSucess = false;
                    result.MSG = "No JvDetail found with the provided ID.";
                    return result;
                }

                await _JvDetail.DeleteAsync(JvDetail);
                await _JvDetail.SaveChangesAsync();

                var deletedProductDto = _Map.Map<JVDetailsGetAllDTO>(JvDetail);

                result.IsSucess = true;
                result.Entity = deletedProductDto;
                result.MSG = "JvDetail deleted successfully.";
            }
            catch (Exception ex)
            {
                // Handle exceptions and populate the result
                result.IsSucess = false;
                result.MSG = $"An error occurred while deleting the JvDetail: {ex.Message}";
            }

            return result;
        }

        public async Task<List<JVDetailsGetAllDTO>> GetAllAsync()
        {
            try
            {
                var JvDetail = (await _JvDetail.GetAllAsync())
                    .Include(p => p.Account)
                    .Include(p => p.Branch)
                    .Include(p => p.SubAccount);



                if (!JvDetail.Any())
                {
                    return new List<JVDetailsGetAllDTO>();
                }
                var Sucess = _Map.Map<List<JVDetailsGetAllDTO>>(JvDetail);

                return Sucess;

            }
            catch (Exception ex)
            {
                throw new Exception("No JvDetail found.");
            }
        }

        public async Task<ResultView<JVDetailsGetAllDTO>> GetOneAsync(int Id)
        {
            var result = new ResultView<JVDetailsGetAllDTO>();

            try
            {
                var Getone = (await _JvDetail.GetAllAsync())
                    .Include(p => p.Account)
                    .Include(p => p.Branch)
                    .Include(p => p.SubAccount)
                    .FirstOrDefault(p => p.Id == Id);

                if (Getone == null)
                {
                    result.IsSucess = false;
                    result.MSG = "No JvDetail found with the provided ID.";
                    return result;
                }

                var successEntity = _Map.Map<JVDetailsGetAllDTO>(Getone);
                result.IsSucess = true;
                result.Entity = successEntity;
                result.MSG = "JvDetail retrieved successfully.";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.MSG = $"An error occurred while retrieving the JvDetail: {ex.Message}";
            }

            return result;
        }

        public async Task<ResultView<JVDetailCreateOrUpdateDTO>> UpdateAsync(JVDetailCreateOrUpdateDTO Entity)
        {
            var res = new ResultView<JVDetailCreateOrUpdateDTO>();
            try
            {

                if (Entity != null)
                {


                    var Exist = (await _JvDetail.GetAllAsync()).Any(p => p.Id == Entity.Id);
                    if (Exist)
                    {

                        var entity = _Map.Map<Jvdetail>(Entity);

                        var Sucess = await _JvDetail.UpdateAsync(entity);
                        var Save = await _JvDetail.SaveChangesAsync();

                        var Returend = _Map.Map<JVDetailCreateOrUpdateDTO>(Sucess);


                        res.IsSucess = true;
                        res.Entity = Returend;
                        res.MSG = "JvDetail Update successfully.";


                    }


                }


                res.IsSucess = false;
                res.MSG = "Already Exist";
                return res;



            }
            catch (Exception ex)
            {
                res.IsSucess = false;
                res.MSG = "Already Exist";

            }
            return res;
        }
    }
}
