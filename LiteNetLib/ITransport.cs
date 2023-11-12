using System.Net;

namespace LiteNetLib
{
    public interface ITransport
    {
        void Send(byte[] message, int start, int length, IPEndPoint remoteEndPoint);
    }
}