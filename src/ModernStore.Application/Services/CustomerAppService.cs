using AutoMapper;
using AutoMapper.QueryableExtensions;
using ModernStore.Application.Interfaces;
using ModernStore.Application.ViewModels;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Interfaces;
using ModernStore.Infra.Repositories.EventSourcing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public CustomerAppService(
            IMapper mapper,
            ICustomerRepository customerRepository,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _customerRepository.GetAll().ProjectTo<CustomerViewModel>();
        }

        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterCustomerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void RegisterCustomerBuy(CustomerBuyViewModel customerBuyViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
