using System.Collections.Generic;
using System.Net;

namespace Simple.IpWhiteListing
{
    public class WhiteListingIpOption
    {
        public List<Ip> IpList { get; set; }

        internal bool AllowedIp(IPAddress remoteIpAddress)
        {
            if (remoteIpAddress == null)
                return false;
            if (!IpList.Exists(x => x == remoteIpAddress.ToString()))
                return false;

            return true;
        }
    }

    public class Ip
    {
        public Ip(string ip)
        {
            value = ip;
        }
        private string value;

        public static implicit operator string(Ip ip) => ip.value;
        public static implicit operator Ip(string ip) => new Ip(ip);
    }
}
