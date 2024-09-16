using AutoMapper;
using ScurityApp.ApiModel.RequestApiModel;
using ScurityApp.ApiModel.ResponseApiModel;
using ScurityApp.DAL.Model;

namespace ScurityApp.Mapping
{
    public class MiscProfile : Profile
    {
        public MiscProfile()
        {
            CreateMap<Employee, EmployeeRequestApiModel>().ReverseMap();
            CreateMap<Employee, EmployeeResponseApiModel>();
            CreateMap<Role, RoleResponseApiModel>();
            CreateMap<Country, CountryResponseApiModel>();
            CreateMap<Country, CountryRequestApiModel>().ReverseMap();
            CreateMap<Department, DepartmentResponseApiModel>();
            CreateMap<Department, DepartmentRequestApiModel>().ReverseMap();
            CreateMap<WorkSchedule, WorkScheduleResponseApiModel>();
            CreateMap<WorkSchedule, WorkScheduleRequestApiModel>().ReverseMap();
            CreateMap<Shift, ShiftResponseApiModel>();
            CreateMap<Shift, ShiftRequestApiModel>().ReverseMap();
            CreateMap<SecurityObject, SecurityObjectRequestApiModel>().ReverseMap();
            CreateMap<SecurityObject, SecurityObjectResponceApiModel>();
        }


    }
}
