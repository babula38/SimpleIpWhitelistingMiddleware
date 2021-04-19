using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
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
            if (!_option.Value.AllowedIp(context.Connection.RemoteIpAddress))
                return;//Return no access error to client

            await _next(context);
        }

    }
}
