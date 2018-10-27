using NSwag;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace NSwag_WebApi_Example.OperationProcs.Responses
{
    public abstract class AbstractResponseProc : IOperationProcessor
    {
        private dynamic _responseObj;

        public AbstractResponseProc(dynamic responseObj)
        {
            _responseObj = responseObj;
        }
        
        public Task<bool> ProcessAsync(OperationProcessorContext context)
        {
            SwaggerOperation operation = context.OperationDescription.Operation;
            var mediaType = operation.Responses.First().Value;

            mediaType.Examples = _responseObj;

            return Task.FromResult(true);
        }
    }
}
