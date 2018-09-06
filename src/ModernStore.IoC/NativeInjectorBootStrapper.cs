using Microsoft.Extensions.DependencyInjection;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Infra.Contexts;
using ModernStore.Infra.Repositories;
using ModernStore.Infra.Services;
using ModernStore.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

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
            services.AddTransient<IUow, Uow>();
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

            //Scoped é singleton *Vai ser instanciado uma vez por request
            //transient é uma nova instancia *vai ser instanciado toda vez que for preciso
        }
    }
}
