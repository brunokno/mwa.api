using JWT.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Application.Interfaces;
using ModernStore.Application.ViewModels;
using ModernStore.Domain.Core.Bus;
using ModernStore.Domain.Core.Notifications;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class MarkupController : ApiController
    {
        private readonly IMarkupAppService _markupAppService;

        public MarkupController(IMarkupAppService markupAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _markupAppService = markupAppService;
        }

        [HttpGet]
        [Route("v1/markup")]
        public IActionResult GetAll()
        {
            var list = _markupAppService.GetAll();
            return Response(list);
        }

        [HttpPost]
        //[AllowAnonymous]
        [Route("v1/markup")]
        public async Task<IActionResult> Post([FromBody]MarkupListViewModel Items)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(Items);
            }

            _markupAppService.Register(Items);

            return Response(Items);
        }
        
    }
}
