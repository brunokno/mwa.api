using AutoMapper;
using ModernStore.Application.Interfaces;
using ModernStore.Application.ViewModels;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Core.Notifications;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Application.Services
{
    public class UserAppService:IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler Bus;

        public UserAppService(
            IMapper mapper,
            IUserRepository userRepository,
                   IMediatorHandler bus)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            Bus = bus;
        }

        public AuthenticateUserViewModel AuthenticatedUser(string userName, string password)
        {
            var user = _userRepository.GetUser(userName);
            var authenticated = user.Authenticate(userName, password);

            //AddNotifications(user.Notifications);

            if (!authenticated)
            {
                Bus.RaiseEvent(new DomainNotification("Login", "Usuário e senha inválidos."));
                return null;
            }

            //return _mapper.Map<AuthenticateUserViewModel>(user);
            return new AuthenticateUserViewModel {
                Active=true,
                Birthdate= DateTime.Now,
                Document="3432432423423",
                Email="brunokno@gmail.com",
                Name="bruno",
                Password="123456",
                Username="brunokno@gmail.com"
            };
            
        }
    }
}
