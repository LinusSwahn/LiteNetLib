using System.Net;

namespace LiteNetLib.Utils
{
    public static class TargetExtensions
    {
        public static IPEndPoint ToEndpoint(this byte target)
        {
            return new IPEndPoint(new IPAddress(target), 0);
        }

        public static byte ToByteTarget(this IPEndPoint endpoint)
        {
            return endpoint.Address.GetAddressBytes()[0];
        }

        public static short ToShortTarget(this IPEndPoint endpoint)
        {
            var addressBytes = endpoint.Address.GetAddressBytes();
            return (short) (addressBytes[1] << 8 | addressBytes[0]);
        }

        public static IPEndPoint ToEndpoint(this short target)
        {
            return new IPEndPoint(new IPAddress(target), 0);
        }
    }
}
