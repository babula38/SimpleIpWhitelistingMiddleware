using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace Simple.IpWhiteListing.Test
{
    public class WhiteListingIpOptionSetupTest
    {
        [Fact]
        public void should_read_config_values_from_configuration()
        {
            //Arrange
            var ip = "1.1.2.3";
            var inMemorySettings = new Dictionary<string, string> {
                    {"AllowedIp", ip}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            var option = new WhiteListingIpOption();

            var setup = new WhiteListingIpOptionSetup(configuration);
            setup.Configure(option);
            option.IpList.Should().HaveCount(1);
            option.IpList.Find(tmp => tmp == ip).Should().NotBeNull();
        }
    }
}
