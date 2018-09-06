using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Infra.Transaction;

namespace JWT.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        errors = result
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] {"Ocorreu uma falha inesperada no servidor."}
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }
    }
}