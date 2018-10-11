using ModernStore.Application.Interfaces;
using ModernStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Application.Services
{
    public class MarkupAppService : IMarkupAppService
    {
        public MarkupListViewModel GetAll()
        {
            var markups = new MarkupListViewModel();

            markups.items.Add(
                new MarkupViewModel
                {
                    Visible = false,
                    CategoryName = "Office 365",
                    PartNumber = "O365_BUS_PREMIUM",
                    Name = "Office 365 Business Premium",
                    BasePriceBRL = 51.83m,
                    MarkupPercentual = 0.00m,
                    PriceSale = 51.83m,
                    EffectivePrice = 0.00m,
                    BasePriceUSD = 0.00m,
                    Description = "",
                    ShortDescription = ""
                });

            markups.items.Add(
            new MarkupViewModel
            {
                Visible = false,
                CategoryName = "Office 365",
                PartNumber = "OFFICESUBSCRIPTION",
                Name = "Office 365 Pro Plus",
                BasePriceBRL = 49.75m,
                MarkupPercentual = 0.00m,
                PriceSale = 49.75m,
                EffectivePrice = 0.00m,
                BasePriceUSD = 0.00m,
                Description = "",
                ShortDescription = ""
            });

            markups.items.Add(
                new MarkupViewModel
                {
                    Visible = false,
                    CategoryName = "Serviços",
                    PartNumber = "IMP-365",
                    Name = "Implementação Office 365 com pagamento à vista",
                    BasePriceBRL = 77.70m,
                    MarkupPercentual = 0.00m,
                    PriceSale = 77.70m,
                    EffectivePrice = 0.00m,
                    BasePriceUSD = 0.00m,
                    Description = "",
                    ShortDescription = ""
                });

            markups.items.Add(
                new MarkupViewModel
                {
                    Visible = false,
                    CategoryName = "Soluções",
                    PartNumber = "PREMIUM-MIGD-DIR",
                    Name = "Office 365 Premium com migrações de e-mail e dados e senhas sincronizadas",
                    BasePriceBRL = 256.12m,
                    MarkupPercentual = 0.00m,
                    PriceSale = 45.12m,
                    EffectivePrice = 0.00m,
                    BasePriceUSD = 0.00m,
                    Description = "",
                    ShortDescription = ""
                });

            markups.items.Add(
                new MarkupViewModel
                {
                    Visible = true,
                    CategoryName = "Azure",
                    PartNumber = "VIR-MAC-A2",
                    Name = "Máquina Virtual P",
                    BasePriceBRL = 56.20m,
                    MarkupPercentual = 0.00m,
                    PriceSale = 56.20m,
                    EffectivePrice = 1.07m,
                    BasePriceUSD = 0.00m,
                    Description = "",
                    ShortDescription = ""
                });

            return markups;
        }

        public void Register(MarkupListViewModel markupListViewModel)
        {
           
        }
    }
}
