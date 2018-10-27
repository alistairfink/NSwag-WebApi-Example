using NSwag_WebApi_Example.Models;

namespace NSwag_WebApi_Example.OperationProcs.Responses
{
    public class SimpleResponseOperationProc : AbstractResponseProc
    {
        private static SimpleResponse responseExample = new SimpleResponse
        {
            Message = "This is a test message.",
            UserID = "User id goes here I guess"
        };

        public SimpleResponseOperationProc() : base(responseExample) { }
    }
}
