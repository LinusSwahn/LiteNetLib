using System.Net;
using LiteNetLib.Utils;

namespace LiteNetLib
{
    public interface IPeer
    {
        int Id { get; }
        IPEndPoint EndPoint { get; }
        object Tag { get; }
        NetManager NetManager { get; }
        void Send(byte[] data, DeliveryMethod deliveryMethod);
        void Send(NetDataWriter dataWriter, DeliveryMethod deliveryMethod);
        int GetMaxSinglePacketSize(DeliveryMethod deliveryMethod);
    }
}
