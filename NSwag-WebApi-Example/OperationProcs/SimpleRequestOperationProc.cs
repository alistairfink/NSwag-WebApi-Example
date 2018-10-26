using NSwag;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using NSwag_WebApi_Example.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NSwag_WebApi_Example.OperationProcs
{
    public class SimpleRequestOperationProc : IOperationProcessor
    {
        private SimpleRequest requestExample = new SimpleRequest
        {
            ID = Guid.NewGuid(),
            Name = "Steve",
            Email = "Steve@steve.com",
            Phone = "123-123-1234"
        };

        public Task<bool> ProcessAsync(OperationProcessorContext context)
        {
            SwaggerOperation operation = context.OperationDescription.Operation;
            OpenApiMediaType mediaType = operation.RequestBody.Content.First().Value;

            mediaType.Example = requestExample;

            return Task.FromResult(true);
        }

        
    }
}
