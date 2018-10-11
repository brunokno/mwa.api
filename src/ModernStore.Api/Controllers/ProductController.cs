using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Core.Notifications;
using ModernStore.Domain.Repositories;
//using ModernStore.Infra.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWT.Controllers
{

    public class ProductController : ApiController
    {
        private readonly IProductRepository _repository;

        public ProductController(//IUow uow, 
            IProductRepository repository,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        //:base(uow)
        {
            _repository = repository;
        }

        [Route("v1/products")]
        [HttpGet, Authorize]
        public async Task<IEnumerable<GetProductListCommandResult>> Get()
        {
            //var currentUser = HttpContext.User;
            return _repository.Get();
        }
    }

}