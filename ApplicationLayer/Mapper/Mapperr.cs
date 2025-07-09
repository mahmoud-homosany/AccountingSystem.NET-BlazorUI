using AutoMapper;
using DTOS.ACC;
using DTOS.JV;
using DTOS.JVDetails;
using DTOS.JvTypes;
using DTOS.SubACC;
using DTOS.SubAccType;
using EContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Mapper
{
    public class Mapperr:Profile
    {


        public Mapperr()
        {
            CreateMap<Account, AccountGetAllDTO>().ReverseMap();
            CreateMap<Jvtype, JvTyprsDTO>().ReverseMap();
            CreateMap<SubAccountsType, SubAccTypeDto>().ReverseMap();
            CreateMap<CreateOrUpdateVM, SubAccount>().ReverseMap();

            CreateMap<SubACCGetAllVM ,SubAccount>().ReverseMap()
                .ForMember(des => des.SubAccountTypeNames, opt => opt.MapFrom(src => src.SubAccountType.SubAccountTypeNameEn))
                .ForMember(des => des.BranchName, opt => opt.MapFrom(src => src.Branch.BranchNameEn));



            CreateMap<JVCreateOrUpdateDTO, Jv>()
               .ForMember(dest => dest.Jvdate, opt => opt.MapFrom(src => src.Date))
               .ForMember(dest => dest.Jvdetails, opt => opt.MapFrom(src => src.Details))
               .ReverseMap()
               .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Jvdate))
               .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Jvdetails));

            // JV GetAll
            CreateMap<JVGetAllDTO, Jv>()
                .ForMember(dest => dest.Jvdate, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Jvdetails, opt => opt.MapFrom(src => src.Details))
                .ReverseMap()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Jvdate))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Jvdetails))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchNameEn));

            // JVDetail Create/Update
            CreateMap<JVDetailCreateOrUpdateDTO, Jvdetail>()
                .ReverseMap();

            // JVDetail GetAll
            CreateMap<JVDetailsGetAllDTO, Jvdetail>()
                .ReverseMap()
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.AccountNameEn))
                .ForMember(dest => dest.SubAccountName, opt => opt.MapFrom(src => src.SubAccount.SubAccountNameEn));

        }

    }
}
