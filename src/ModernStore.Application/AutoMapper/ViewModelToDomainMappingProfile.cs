using AutoMapper;
using ModernStore.Application.ViewModels;
using ModernStore.Domain.Commands.Inputs;

namespace ModernStore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterCustomerCommand>()
                .ConstructUsing(c => new RegisterCustomerCommand(
                    c.FirstName, 
                    c.LastName,
                    c.Email, 
                    c.BirthDate,
                    c.Document,
                    c.Username,
                    c.Password,
                    c.ConfirmPassword,
                    c.InscricaoEstadual,
                    c.CompanyName,
                    c.Phone,
                    c.CellPhone,
                    c.Endereco,
                    c.Numero,
                    c.Complemento,
                    c.Cidade,
                    c.Bairro,
                    c.Estado));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(
                    c.Id, 
                    c.FirstName, 
                    c.LastName, 
                    c.Email, 
                    c.BirthDate,
                    c.Phone,
                    c.CellPhone,
                    c.Endereco,
                    c.Numero,
                    c.Complemento,
                    c.Cidade,
                    c.Bairro,
                    c.Estado,
                    c.InscricaoEstadual,
                    c.CompanyName));
        }
    }
}
