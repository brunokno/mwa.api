using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Application.Interfaces;
using ModernStore.Application.ViewModels;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Core.Notifications;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;
        private IHostingEnvironment _hostingEnvironment;

        public CustomerController(
            ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IHostingEnvironment hostingEnvironment) : base(notifications, mediator)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer")]
        public IActionResult Get()
        {
            return Response(_customerAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("customer/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = _customerAppService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost]
        [Route("v1/customer")]
        public async Task<IActionResult> Post([FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Register(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpPost]
        [Route("v1/customerBuy")]
        public async Task<IActionResult> Post([FromBody]CustomerBuyViewModel customerBuyViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerBuyViewModel);
            }

            _customerAppService.RegisterCustomerBuy(customerBuyViewModel);

            return Response(customerBuyViewModel);
        }


        [HttpPut]
        //[Authorize(Policy = "CanWriteCustomerData")]
        [Route("v1/customer/{id:guid}")]
        public IActionResult Put(Guid Id, [FromBody]CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _customerAppService.Update(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpDelete]
        //[Authorize(Policy = "CanRemoveCustomerData")]
        [Route("customer")]
        public IActionResult Delete(Guid id)
        {
            _customerAppService.Remove(id);

            return Response();
        }
        
        //[HttpGet]
        //[AllowAnonymous]
        //[Route("customer/history/{id:guid}")]
        //public IActionResult History(Guid id)
        //{
        //    var customerHistoryData = _customerAppService.GetAllHistory(id);
        //    return Response(customerHistoryData);
        //}

    }
}