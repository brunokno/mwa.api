﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            //RegistrationDate = DateTime.Now;
        }

        //[Column(Order = 0)]
        //public Guid Id { get; set; }
        //public bool Active { get; set; }
        //public DateTime RegistrationDate { get; set; }
        //public DateTime? DateModified { get; set; }
    }
}
