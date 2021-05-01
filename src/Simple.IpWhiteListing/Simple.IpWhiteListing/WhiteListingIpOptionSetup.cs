using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Simple.IpWhiteListing
{
    public class WhiteListingIpOptionSetup : IConfigureOptions<WhiteListingIpOption>
    {
        private readonly IConfiguration configuration;

        public WhiteListingIpOptionSetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Configure(WhiteListingIpOption options)
        {
            var ipList = configuration.GetSection("AllowedIp").Value?.Split(",")
                                                                     .Select(x => new Ip(x));
            if (ipList != null)
            {
                options.IpList ??= new();
                options.IpList.AddRange(ipList);
            }
        }
    }
}
