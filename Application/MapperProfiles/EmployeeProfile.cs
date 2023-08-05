using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
    }
}