using System;
using System.Net;
using LiteNetLib.Utils;

namespace LiteNetLib
{
    public interface INetPeer
    {
        /// <summary>
        /// Peer id can be used as key in your dictionary of peers
        /// </summary>
        int Id { get; }
        
        /// <summary>
        /// Current connection state
        /// </summary>
        ConnectionState ConnectionState { get; }

        /// <summary>
        /// Peer ip address and port
        /// </summary>
        IPEndPoint EndPoint { get; }

        /// <summary>
        /// Current ping in milliseconds
        /// </summary>
        int Ping { get; }

        /// <summary>
        /// Current MTU - Maximum Transfer Unit ( maximum udp packet size without fragmentation )
        /// </summary>
        int Mtu { get; }

        /// <summary>
        /// Delta with remote time in ticks (not accurate)
        /// positive - remote time > our time
        /// </summary>
        long RemoteTimeDelta { get; }

        /// <summary>
        /// Remote UTC time (not accurate)
        /// </summary>
        DateTime RemoteUtcTime { get; }

        /// <summary>
        /// Time since last packet received (including internal library packets)
        /// </summary>
        int TimeSinceLastPacket { get; }

        /// <summary>
        /// Peer parent NetManager
        /// </summary>
        NetManager NetManager { get; }

        /// <summary>
        /// Application defined object containing data about the connection
        /// </summary>
        object Tag { get; set; }
        
        /// <summary>
        /// Gets maximum size of packet that will be not fragmented.
        /// </summary>
        /// <param name="options">Type of packet that you want send</param>
        /// <returns>size in bytes</returns>
        int GetMaxSinglePacketSize(DeliveryMethod options);

        /// <summary>
        /// Send data to peer (channel - 0)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <exception cref="TooBigPacketException">
        ///     If size exceeds maximum limit:<para/>
        ///     MTU - headerSize bytes for Unreliable<para/>
        ///     Fragment count exceeded ushort.MaxValue<para/>
        /// </exception>
        void Send(byte[] data, DeliveryMethod options);

        /// <summary>
        /// Send data to peer (channel - 0)
        /// </summary>
        /// <param name="dataWriter">DataWriter with data</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <exception cref="TooBigPacketException">
        ///     If size exceeds maximum limit:<para/>
        ///     MTU - headerSize bytes for Unreliable<para/>
        ///     Fragment count exceeded ushort.MaxValue<para/>
        /// </exception>
        void Send(INetDataWriter dataWriter, DeliveryMethod options);

        /// <summary>
        /// Send data to peer (channel - 0)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="start">Start of data</param>
        /// <param name="length">Length of data</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <exception cref="TooBigPacketException">
        ///     If size exceeds maximum limit:<para/>
        ///     MTU - headerSize bytes for Unreliable<para/>
        ///     Fragment count exceeded ushort.MaxValue<para/>
        /// </exception>
        void Send(byte[] data, int start, int length, DeliveryMethod options);

        /// <summary>
        /// Send data to peer
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="channelNumber">Number of channel (from 0 to channelsCount - 1)</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <exception cref="TooBigPacketException">
        ///     If size exceeds maximum limit:<para/>
        ///     MTU - headerSize bytes for Unreliable<para/>
        ///     Fragment count exceeded ushort.MaxValue<para/>
        /// </exception>
        void Send(byte[] data, byte channelNumber, DeliveryMethod options);

        /// <summary>
        /// Send data to peer
        /// </summary>
        /// <param name="dataWriter">DataWriter with data</param>
        /// <param name="channelNumber">Number of channel (from 0 to channelsCount - 1)</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <exception cref="TooBigPacketException">
        ///     If size exceeds maximum limit:<para/>
        ///     MTU - headerSize bytes for Unreliable<para/>
        ///     Fragment count exceeded ushort.MaxValue<para/>
        /// </exception>
        void Send(NetDataWriter dataWriter, byte channelNumber, DeliveryMethod options);

        /// <summary>
        /// Send data to peer
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="start">Start of data</param>
        /// <param name="length">Length of data</param>
        /// <param name="channelNumber">Number of channel (from 0 to channelsCount - 1)</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <exception cref="TooBigPacketException">
        ///     If size exceeds maximum limit:<para/>
        ///     MTU - headerSize bytes for Unreliable<para/>
        ///     Fragment count exceeded ushort.MaxValue<para/>
        /// </exception>
        void Send(byte[] data, int start, int length, byte channelNumber, DeliveryMethod options);

        void Disconnect(byte[] data);
        void Disconnect(NetDataWriter writer);
        void Disconnect(byte[] data, int start, int count);
        void Disconnect();

        /// <summary>
        /// Flush all queued packets
        /// </summary>
        void Flush();
    }
}