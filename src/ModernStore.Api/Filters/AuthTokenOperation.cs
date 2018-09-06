using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Filters
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Paths.Add("/api/token", new PathItem
            {
                Post = new Operation
                {
                    Tags = new List<string> { "Auth" },
                    Consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded"
                    }
                }
            });
        }
    }
}
