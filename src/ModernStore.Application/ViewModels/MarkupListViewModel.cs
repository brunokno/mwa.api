using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Application.ViewModels
{
    public class MarkupListViewModel
    {
        public MarkupListViewModel()
        {
            items = new List<MarkupViewModel>();
        }

        public List<MarkupViewModel> items { get; set; }
    }
}
