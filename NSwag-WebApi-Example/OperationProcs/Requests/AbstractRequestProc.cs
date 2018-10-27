using NSwag;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace NSwag_WebApi_Example.OperationProcs.Requests
{
    public abstract class AbstractRequestProc : IOperationProcessor
    {
        private dynamic _requestObj;

        public AbstractRequestProc(dynamic requestObj)
        {
            _requestObj = requestObj;
        }

        public Task<bool> ProcessAsync(OperationProcessorContext context)
        {
            SwaggerOperation operation = context.OperationDescription.Operation;
            OpenApiMediaType mediaType = operation.RequestBody.Content.First().Value;

            mediaType.Example = _requestObj;

            return Task.FromResult(true);
        }
    }
}
