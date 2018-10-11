﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using ModernStore.Domain.Commands.Handlers;
//using ModernStore.Domain.Commands.Inputs;
//using ModernStore.Infra.Transaction;

//namespace JWT.Controllers
//{
//    public class OrderController : ApiController
//    {
//        private readonly OrderCommandHandler _handler;
//        public OrderController(IUow uow, OrderCommandHandler handler) : base(uow)
//        {
//            _handler = handler;
//        }

//        [HttpPost]
//        [Route("v1/orders"),Authorize]
//        public async Task<IActionResult>  Post([FromBody]RegisterOrderCommand command)
//        {
//            var result = _handler.Handle(command);
//            return await Response(result, _handler.Notifications);
//        }
//    }
//}