using NSwag;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using NSwag_WebApi_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSwag_WebApi_Example.OperationProcs
{
    public class SimpleResponseOperationProc : IOperationProcessor
    {
        private SimpleResponse responseExample = new SimpleResponse
        {
            Message = "This is a test message.",
            UserID = "User id goes here I guess"
        };

        public Task<bool> ProcessAsync(OperationProcessorContext context)
        {
            SwaggerOperation operation = context.OperationDescription.Operation;
            var mediaType = operation.Responses.First().Value;
            mediaType.Examples = responseExample;

            return Task.FromResult(true);
        }
    }
}
