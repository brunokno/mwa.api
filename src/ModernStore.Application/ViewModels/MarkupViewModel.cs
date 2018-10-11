using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Application.ViewModels
{
    public class MarkupViewModel
    {
        public bool Visible { get; set; }
        public string CategoryName { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public decimal MarkupPercentual { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        //decimal:
        public decimal BasePriceBRL { get; set; }
        public decimal BasePriceUSD { get; set; }
        public decimal PriceSale { get; set; }
        public decimal EffectivePrice { get; set; }
    }
}
