using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using NSwag_WebApi_Example.Models;
using NSwag_WebApi_Example.OperationProcs;
using System;

namespace NSwag_WebApi_Example.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [SwaggerTag("SimpleAPI", Description = "Does Stuff.")]
    public class SimpleAPIController : Controller
    {
        /// <summary>
        /// This is a test get.
        /// </summary>
        /// <returns>Some default response</returns>
        [HttpGet]
        [SwaggerOperationProcessor(typeof(SimpleResponseOperationProc))]
        [SwaggerResponse(200, typeof(SimpleResponse))]
        [SwaggerResponse(404, typeof(void), Description = "This should never happen.")]
        public SimpleResponse Get()
        {
            return new SimpleResponse
            {
                Message = "Get Success",
                UserID = Guid.Empty.ToString()
            };
        }

        /// <summary>
        /// This is a test post.
        /// </summary>
        /// <param name="request">This is a request model.</param>
        /// <returns>Some default response</returns>
        [HttpPost]
        [SwaggerOperationProcessor(typeof(SimpleRequestOperationProc))]
        [SwaggerOperationProcessor(typeof(SimpleResponseOperationProc))]
        [SwaggerResponse(200, typeof(SimpleResponse))]
        [SwaggerResponse(404, typeof(void), Description = "This should never happen.")]
        public SimpleResponse Post([FromBody]SimpleRequest request)
        {
            return new SimpleResponse
            {
                Message = "You are " + request.Name + " with email " + request.Email + " and maybe phone " + request?.Phone,
                UserID = request.ID.ToString()
            };
        }
    }
}