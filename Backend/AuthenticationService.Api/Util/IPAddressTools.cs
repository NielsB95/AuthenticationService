using System;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace AuthenticationService.Api.Util
{
    public interface IIPAddressTools
    {
        IPAddress GetIPAddress(HttpContext context);
    }

    public class IPAddressTools : IIPAddressTools
    {
        public IPAddress GetIPAddress(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return context.Connection.RemoteIpAddress;
        }
    }
}
