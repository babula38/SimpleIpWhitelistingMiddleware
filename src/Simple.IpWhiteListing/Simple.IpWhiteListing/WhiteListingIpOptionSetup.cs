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
            var ipList = configuration.GetSection("Allowed").Value?.Split(",")
                                                                        .Select(x => new Ip(x));
            options.IpList.AddRange(ipList);
        }
    }
}
