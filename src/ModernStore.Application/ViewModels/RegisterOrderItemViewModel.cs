using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Application.ViewModels
{
    public class RegisterOrderItemViewModel
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}
