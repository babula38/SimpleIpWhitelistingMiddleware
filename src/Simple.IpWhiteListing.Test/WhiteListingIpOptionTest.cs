using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Simple.IpWhiteListing.Test
{
    public class WhiteListingIpOptionTest
    {
        [Fact]
        public void Should_be_true_when_configured_ip_addresses_found()
        {
            var ip = "1.1.1";

            WhiteListingIpOption option = new() { IpList = new List<Ip>() };
            option.IpList.Add(new Ip(ip));

            option.AllowedIp(ip).Should().BeTrue();
        }
        
        [Fact]
        public void Should_be_false_when_configured_ip_addresses_found()
        {
            var ip = "1.1.1";

            WhiteListingIpOption option = new() { IpList = new List<Ip>() };
            option.IpList.Add(new Ip(ip));

            option.AllowedIp("1.1.2").Should().BeFalse();
        }
    }
}
