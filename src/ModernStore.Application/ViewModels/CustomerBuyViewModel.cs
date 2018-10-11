using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Application.ViewModels
{
    public class CustomerBuyViewModel
    {
        public CustomerViewModel CustomerReseller { get; set; }
        public CustomerViewModel CustomerBilling { get; set; }
        public CustomerViewModel CustomerMicrosoft { get; set; }
    }
}
