using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BloggerSample.WebAPI.API_Core
{
    public class HttpResponseMessageResult
    {
        private readonly HttpResponseMessage _responseMessage;

        public HttpResponseMessageResult(HttpResponseMessage responseMessage)
        {
            _responseMessage = responseMessage; // could add throw if null
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)_responseMessage.StatusCode;

            foreach (var header in _responseMessage.Headers)
            {
                context.HttpContext.Response.Headers.TryAdd(header.Key, new StringValues(header.Value.ToArray()));
            }

            using (var stream = await _responseMessage.Content.ReadAsStreamAsync())
            {
                await stream.CopyToAsync(context.HttpContext.Response.Body);
                await context.HttpContext.Response.Body.FlushAsync();
            }
        }
    }


    //public async Task<IActionResult> Routes([FromBody]JObject request)
    //{
    //    var httpClient = new HttpClient();

    //    HttpResponseMessage response = await httpClient.GetAsync("");

    //    Here we ask the framework to dispose the response object a the end of the user resquest
    //    this.HttpContext.Response.RegisterForDispose(response);

    //    return new HttpResponseMessageResult(response);
    //}
}
