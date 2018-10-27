using NSwag_WebApi_Example.Models;
using System;

namespace NSwag_WebApi_Example.OperationProcs.Requests
{
    public class SimpleRequestOperationProc : AbstractRequestProc
    {
        private static SimpleRequest requestExample = new SimpleRequest
        {
            ID = Guid.NewGuid(),
            Name = "Steve",
            Email = "Steve@steve.com",
            Phone = "123-123-1234"
        };

        public SimpleRequestOperationProc() : base(requestExample) { }
    }
}
