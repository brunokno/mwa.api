using AutoMapper;
using ModernStore.Application.ViewModels;
using ModernStore.Domain.Entities;

namespace ModernStore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<User, AuthenticateUserViewModel>();
        }
    }
}
