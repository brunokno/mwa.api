using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Models
{
    public class MyPageModel
    {

        public Microsoft.AspNetCore.Http.IFormFile Image { get; set; }
        public string Alias { get; set; }

    }
}
