using ApplicationLayer.Contract;
using ApplicationLayer.Mapper;
using AutoMapper;
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
    public class SubAccService : ISubAccService
    {
        private readonly ISubAccReposatiry _ScuAccRepo;
        private readonly IMapper _map;

        public SubAccService(ISubAccReposatiry ScuAccRepo , IMapper map)
        {

            _ScuAccRepo = ScuAccRepo;
            _map = map;
        }




        public async Task<ResultView<CreateOrUpdateVM>> CreateAsync(CreateOrUpdateVM Entity)
        {
              var res = new ResultView<CreateOrUpdateVM>();
            try
            {

                if(Entity != null)
                {

                   
                    var entity = _map.Map<SubAccount>(Entity);

                    var Sucess = await _ScuAccRepo.CreateAsync(entity);
                    var Save = await _ScuAccRepo.SaveChangesAsync();

                    var Returend = _map.Map<CreateOrUpdateVM>(Sucess);


                    res.IsSucess = true;
                    res.Entity = Returend;
                    res.MSG = "SubAcc created successfully.";

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

        public async Task<ResultView<SubACCGetAllVM>> DeleteAsync(int Id)
        {
            var result = new ResultView<SubACCGetAllVM>();

            try
            {
                if (Id == null || Id == 0)
                {
                    result.IsSucess = false;
                    result.MSG = "The entity to delete cannot be null.";
                    return result;
                }


                var SubAcc = (await _ScuAccRepo.GetAllAsync()).FirstOrDefault(p => p.Id == Id);
                if (SubAcc == null)
                {
                    result.IsSucess = false;
                    result.MSG = "No SubAcc found with the provided ID.";
                    return result;
                }

                await _ScuAccRepo.DeleteAsync(SubAcc);
                await _ScuAccRepo.SaveChangesAsync();

                var deletedProductDto = _map.Map<SubACCGetAllVM>(SubAcc);

                result.IsSucess = true;
                result.Entity = deletedProductDto;
                result.MSG = "SubAcc deleted successfully.";
            }
            catch (Exception ex)
            {
                // Handle exceptions and populate the result
                result.IsSucess = false;
                result.MSG = $"An error occurred while deleting the SubAcc: {ex.Message}";
            }

            return result;
        }

        public async Task<List<SubACCGetAllVM>> GetAllAsync()
        {
            try
            {
                var SubAcc = (await _ScuAccRepo.GetAllAsync())
                    .Include(p => p.SubAccountType)
                    .Include(p => p.Branch);



                if (!SubAcc.Any())
                {
                    return new List<SubACCGetAllVM>();
                }
                var Sucess = _map.Map<List<SubACCGetAllVM>>(SubAcc);

                return Sucess;

            }
            catch (Exception ex)
            {
                throw new Exception("No products found.");
            }

        }

        public async Task<ResultView<SubACCGetAllVM>> GetOneAsync(int Id)
        {
            var result = new ResultView<SubACCGetAllVM>();

            try
            {
                var Getone = (await _ScuAccRepo.GetAllAsync())
                    .Include(p => p.SubAccountType)
                    .Include(p => p.Branch)
                    .FirstOrDefault(p => p.Id == Id); 

                if (Getone == null)
                {
                    result.IsSucess = false;
                    result.MSG = "No SubAcc found with the provided ID.";
                    return result;
                }

                var successEntity = _map.Map<SubACCGetAllVM>(Getone);
                result.IsSucess = true;
                result.Entity = successEntity;
                result.MSG = "SubAcc retrieved successfully.";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.MSG = $"An error occurred while retrieving the SubAcc: {ex.Message}";
            }

            return result;
        }

        public async Task<ResultView<CreateOrUpdateVM>> UpdateAsync(CreateOrUpdateVM Entity)
        {
            var res = new ResultView<CreateOrUpdateVM>();
            try
            {

                if (Entity != null)
                {

                    var Exist = (await _ScuAccRepo.GetAllAsync()).Any(p => p.Id == Entity.Id);
                    if (Exist)
                    {

                    var entity = _map.Map<SubAccount>(Entity);

                    var Sucess = await _ScuAccRepo.UpdateAsync(entity);
                    var Save = await _ScuAccRepo.SaveChangesAsync();

                    var Returend = _map.Map<CreateOrUpdateVM>(Sucess);


                    res.IsSucess = true;
                    res.Entity = Returend;
                    res.MSG = "Product Update successfully.";


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
