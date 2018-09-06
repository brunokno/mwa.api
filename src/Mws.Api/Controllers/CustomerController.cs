using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transaction;

namespace JWT.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerCommandHandler _handler;

        public CustomerController(IUow uol, CustomerCommandHandler handler):base(uol)
        {
            _handler = handler;
        }

        public async Task<IActionResult> Post([FromBody] RegisterCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}