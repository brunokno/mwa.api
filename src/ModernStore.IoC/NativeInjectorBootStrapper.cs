using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModernStore.Application.Interfaces;
using ModernStore.Application.Services;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Core.Events;
using ModernStore.Domain.Core.Notifications;
using ModernStore.Domain.EventHandlers;
using ModernStore.Domain.Events;
using ModernStore.Domain.Interfaces;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Infra.Contexts;
using ModernStore.Infra.CrossCutting.Bus;
using ModernStore.Infra.EventSourcing;
using ModernStore.Infra.Repositories;
using ModernStore.Infra.Repositories.EventSourcing;
using ModernStore.Infra.Services;
using ModernStore.Infra.UoW;
//using ModernStore.Infra.Transaction;

namespace ModernStore.IoC
{
    public class NativeInjectorBootStrapper
    {
        //*******************************************************//
        // Pacore necessário para funcionar:
        // Microsoft.Extensions.DependencyInjection.Abstractions
        //*******************************************************//

        public static void RegisterServices(IServiceCollection services)
        {
            //Transient - toda vez que vc chamar um construtor ele vai gerar uma nova interface
            //Scoped - ele vai criar uma interface só para todo o contexto
            //Então o banco de dados que vamos passar de uma classe para outra não é legal criar um transient, é  melhor criar um scoped
            services.AddScoped<ModernStoreDataContext, ModernStoreDataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Então assim:
            //Toda vez que alguém pedir um ModernStoreDataContext eu vou dar um ModernStoreDataContext que já existe, e se não existir nenhum eu vou criar um novo.
            //Toda vez que alguém pedir um ICustomerRepository, eu vou dar uma nova instância de CustomerRepository.
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IEmailService, EmailService>();

            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<OrderCommandHandler, OrderCommandHandler>();
            services.AddTransient<UserCommandHandler, UserCommandHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();


            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();


            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<ICustomerAppService, CustomerAppService>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IMarkupAppService, MarkupAppService>();

            //Scoped é singleton *Vai ser instanciado uma vez por request
            //transient é uma nova instancia *vai ser instanciado toda vez que for preciso
        }
    }
}
