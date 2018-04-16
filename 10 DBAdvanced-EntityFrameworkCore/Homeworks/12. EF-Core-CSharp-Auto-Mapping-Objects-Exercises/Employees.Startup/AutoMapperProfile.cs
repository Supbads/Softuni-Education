namespace Employees.Startup
{
    using AutoMapper;
    using Employees.DataModels;
    using Employees.Models;

    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeePersonalDto, Employee>();
            CreateMap<Employee, EmployeePersonalDto>();
            CreateMap<ManagerDto, Employee>();
            CreateMap<Employee, ManagerDto>();

            CreateMap<Employee, EmployeeWorkDto>()
                .ForMember(e => e.EmployeeFullName, opt => opt.MapFrom(e => $"{e.FirstName} {e.LastName}"))
                .ForMember(e => e.Salary, opt => opt.MapFrom(e => e.Salary))
                .ForMember(e => e.ManagerFullName,
                    opt => opt.MapFrom(e => $"{e.Manager.FirstName} {e.Manager.LastName}"));
            //if this works holy cow

        }
    }
}