﻿using ModernStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string name, string email, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
