using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWT.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IProductRepository _repository;

        public ProductController(IUow uow, IProductRepository repository):base(uow)
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