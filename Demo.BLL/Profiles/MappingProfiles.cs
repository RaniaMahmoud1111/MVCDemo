using AutoMapper;
using Demo.BLL.DTO.EmployeeDtos;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.EmpGender, options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmpType, Options => Options.MapFrom(src => src.EmployeeType));
             


            CreateMap<Employee, EmployeeDetailsDto>()
            .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
               .ForMember(dest => dest.EmployeeType, Options => Options.MapFrom(src => src.EmployeeType))
               .ForMember(dest=>dest.HiringDate,options=>options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));


            //CreateMap<CreatedEmployeeDto, Employee>().ReverseMap(); if we  need the  reverse 
            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, opt=>opt.MapFrom(src=>src.HiringDate.ToDateTime(TimeOnly.MinValue)));



            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, opt => opt.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));



        }

    }
}
