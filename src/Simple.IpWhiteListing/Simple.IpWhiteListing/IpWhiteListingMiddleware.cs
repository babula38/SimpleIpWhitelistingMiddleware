using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Simple.IpWhiteListing
{
    public class IpWhiteListingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<WhiteListingIpOption> _option;

        public IpWhiteListingMiddleware(RequestDelegate next, IOptions<WhiteListingIpOption> option)
        {
            _next = next;
            this._option = option;
        }

        public async Task Invoke(HttpContext context)
        {
            string? ip = Convert.ToString(context.Connection.RemoteIpAddress);

            if (!_option.Value.AllowedIp(ip))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Server denied the request");

                return;
            }

            await _next(context);
        }
    }
}