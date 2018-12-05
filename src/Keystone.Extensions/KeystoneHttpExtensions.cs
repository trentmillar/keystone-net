using System;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace Keystone.Extensions
{
    public static class KeystoneHttpExtensions
    {
        public static async Task<HttpContext> ApiResponse(this HttpContext context, [NotNull] object anonymousType)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(anonymousType);
            context.Response.StatusCode = StatusCodes.Status200OK;
            context.Response.ContentType = KeystoneHttpMediaTypes.JSON;
            await context.Response.WriteAsync(json, Encoding.UTF8);
            
            //flag context
            context.Items.Add(Constants.Constants.HTTP_CONTEXT_ITEM_KEY, Constants.Constants.HTTP_CONTEXT_ITEM_VALUE_KILL);
            
            return context;
        }
    }
}