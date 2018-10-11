using ModernStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Application.Interfaces
{
    public interface ICustomerAppService
    {
        void Register(CustomerViewModel customerViewModel);
        void RegisterCustomerBuy(CustomerBuyViewModel customerBuyViewModel);        
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
