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
            var currentUser = HttpContext.User;
            //var resultBookList = new Product[] {
            //    new Product { Id=Guid.NewGuid(), Image = "https://picsum.photos/400/300",Title = "Fahrenheit 451", Price=20m },
            //    new Product { Id=Guid.NewGuid(), Image = "https://picsum.photos/400/300", Title = "One Hundred years of Solitude",Price=25m },
            //    new Product { Id=Guid.NewGuid(), Image = "https://picsum.photos/400/300", Title = "1984", Price=37m },
            //    new Product { Id=Guid.NewGuid(), Image = "https://picsum.photos/400/300", Title = "Delta of Venus", Price=56m }
            //};
            //
            //return resultBookList;

            return _repository.Get();
        }
    }
    //public class Product
    //{
    //    public Guid Id { get;set; }
    //    public string Image { get; set; }
    //    public string Title { get; set; }
    //    public string Segment { get; set; }
    //    public decimal Price { get; set; }
    //}

}