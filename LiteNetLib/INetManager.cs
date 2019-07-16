using System;
using System.Collections.Generic;
using System.Net;
using LiteNetLib.Utils;

namespace LiteNetLib
{
    public interface INetManager
    {
        /// <summary>
        /// Returns true if socket listening and update thread is running
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Local EndPoint (host and port)
        /// </summary>
        int LocalPort { get; }

        /// <summary>
        /// First peer. Useful for Client mode
        /// </summary>
        NetPeer FirstPeer { get; }

        /// <summary>
        /// QoS channel count per message type (value must be between 1 and 64 channels)
        /// </summary>
        byte ChannelsCount { get; set; }

        /// <summary>
        /// Returns connected peers list (with internal cached list)
        /// </summary>
        List<NetPeer> ConnectedPeerList { get; }

        /// <summary>
        /// Returns connected peers count
        /// </summary>
        int PeersCount { get; }

        /// <summary>
        /// Send data to all connected peers (channel - 0)
        /// </summary>
        /// <param name="writer">DataWriter with data</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        void SendToAll(INetDataWriter writer, DeliveryMethod options);

        /// <summary>
        /// Send data to all connected peers (channel - 0)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        void SendToAll(byte[] data, DeliveryMethod options);

        /// <summary>
        /// Send data to all connected peers (channel - 0)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="start">Start of data</param>
        /// <param name="length">Length of data</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        void SendToAll(byte[] data, int start, int length, DeliveryMethod options);

        /// <summary>
        /// Send data to all connected peers
        /// </summary>
        /// <param name="writer">DataWriter with data</param>
        /// <param name="channelNumber">Number of channel (from 0 to channelsCount - 1)</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        void SendToAll(INetDataWriter writer, byte channelNumber, DeliveryMethod options);

        /// <summary>
        /// Send data to all connected peers
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="channelNumber">Number of channel (from 0 to channelsCount - 1)</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        void SendToAll(byte[] data, byte channelNumber, DeliveryMethod options);

        /// <summary>
        /// Send data to all connected peers
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="start">Start of data</param>
        /// <param name="length">Length of data</param>
        /// <param name="channelNumber">Number of channel (from 0 to channelsCount - 1)</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        void SendToAll(byte[] data, int start, int length, byte channelNumber, DeliveryMethod options);

        /// <summary>
        /// Send data to all connected peers (channel - 0)
        /// </summary>
        /// <param name="writer">DataWriter with data</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <param name="excludePeer">Excluded peer</param>
        void SendToAll(INetDataWriter writer, DeliveryMethod options, NetPeer excludePeer);

        /// <summary>
        /// Send data to all connected peers (channel - 0)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <param name="excludePeer">Excluded peer</param>
        void SendToAll(byte[] data, DeliveryMethod options, NetPeer excludePeer);

        /// <summary>
        /// Send data to all connected peers (channel - 0)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="start">Start of data</param>
        /// <param name="length">Length of data</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <param name="excludePeer">Excluded peer</param>
        void SendToAll(byte[] data, int start, int length, DeliveryMethod options, NetPeer excludePeer);

        /// <summary>
        /// Send data to all connected peers
        /// </summary>
        /// <param name="writer">DataWriter with data</param>
        /// <param name="channelNumber">Number of channel (from 0 to channelsCount - 1)</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <param name="excludePeer">Excluded peer</param>
        void SendToAll(INetDataWriter writer, byte channelNumber, DeliveryMethod options, NetPeer excludePeer);

        /// <summary>
        /// Send data to all connected peers
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="channelNumber">Number of channel (from 0 to channelsCount - 1)</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <param name="excludePeer">Excluded peer</param>
        void SendToAll(byte[] data, byte channelNumber, DeliveryMethod options, NetPeer excludePeer);

        /// <summary>
        /// Send data to all connected peers
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="start">Start of data</param>
        /// <param name="length">Length of data</param>
        /// <param name="channelNumber">Number of channel (from 0 to channelsCount - 1)</param>
        /// <param name="options">Send options (reliable, unreliable, etc.)</param>
        /// <param name="excludePeer">Excluded peer</param>
        void SendToAll(byte[] data, int start, int length, byte channelNumber, DeliveryMethod options, NetPeer excludePeer);

        /// <summary>
        /// Start logic thread and listening on available port
        /// </summary>
        bool Start();

        /// <summary>
        /// Start logic thread and listening on selected port
        /// </summary>
        /// <param name="addressIPv4">bind to specific ipv4 address</param>
        /// <param name="addressIPv6">bind to specific ipv6 address</param>
        /// <param name="port">port to listen</param>
        bool Start(IPAddress addressIPv4, IPAddress addressIPv6, int port);

        /// <summary>
        /// Start logic thread and listening on selected port
        /// </summary>
        /// <param name="addressIPv4">bind to specific ipv4 address</param>
        /// <param name="addressIPv6">bind to specific ipv6 address</param>
        /// <param name="port">port to listen</param>
        bool Start(string addressIPv4, string addressIPv6, int port);

        /// <summary>
        /// Start logic thread and listening on selected port
        /// </summary>
        /// <param name="port">port to listen</param>
        bool Start(int port);

        /// <summary>
        /// Send message without connection
        /// </summary>
        /// <param name="message">Raw data</param>
        /// <param name="remoteEndPoint">Packet destination</param>
        /// <returns>Operation result</returns>
        bool SendUnconnectedMessage(byte[] message, IPEndPoint remoteEndPoint);

        /// <summary>
        /// Send message without connection
        /// </summary>
        /// <param name="writer">Data serializer</param>
        /// <param name="remoteEndPoint">Packet destination</param>
        /// <returns>Operation result</returns>
        bool SendUnconnectedMessage(INetDataWriter writer, IPEndPoint remoteEndPoint);

        /// <summary>
        /// Send message without connection
        /// </summary>
        /// <param name="message">Raw data</param>
        /// <param name="start">data start</param>
        /// <param name="length">data length</param>
        /// <param name="remoteEndPoint">Packet destination</param>
        /// <returns>Operation result</returns>
        bool SendUnconnectedMessage(byte[] message, int start, int length, IPEndPoint remoteEndPoint);

        bool SendBroadcast(INetDataWriter writer, int port);
        bool SendBroadcast(byte[] data, int port);
        bool SendBroadcast(byte[] data, int start, int length, int port);

        /// <summary>
        /// Flush all queued packets of all peers
        /// </summary>
        void Flush();

        /// <summary>
        /// Receive all pending events. Call this in game update code
        /// </summary>
        void PollEvents();

        /// <summary>
        /// Connect to remote host
        /// </summary>
        /// <param name="address">Server IP or hostname</param>
        /// <param name="port">Server Port</param>
        /// <param name="key">Connection key</param>
        /// <returns>New NetPeer if new connection, Old NetPeer if already connected</returns>
        /// <exception cref="InvalidOperationException">Manager is not running. Call <see cref="NetManager.Start()"/></exception>
        NetPeer Connect(string address, int port, string key);

        /// <summary>
        /// Connect to remote host
        /// </summary>
        /// <param name="address">Server IP or hostname</param>
        /// <param name="port">Server Port</param>
        /// <param name="connectionData">Additional data for remote peer</param>
        /// <returns>New NetPeer if new connection, Old NetPeer if already connected</returns>
        /// <exception cref="InvalidOperationException">Manager is not running. Call <see cref="NetManager.Start()"/></exception>
        NetPeer Connect(string address, int port, INetDataWriter connectionData);

        /// <summary>
        /// Connect to remote host
        /// </summary>
        /// <param name="target">Server end point (ip and port)</param>
        /// <param name="key">Connection key</param>
        /// <returns>New NetPeer if new connection, Old NetPeer if already connected</returns>
        /// <exception cref="InvalidOperationException">Manager is not running. Call <see cref="NetManager.Start()"/></exception>
        NetPeer Connect(IPEndPoint target, string key);

        /// <summary>
        /// Connect to remote host
        /// </summary>
        /// <param name="target">Server end point (ip and port)</param>
        /// <param name="connectionData">Additional data for remote peer</param>
        /// <returns>New NetPeer if new connection, Old NetPeer if already connected</returns>
        /// <exception cref="InvalidOperationException">Manager is not running. Call <see cref="NetManager.Start()"/></exception>
        NetPeer Connect(IPEndPoint target, INetDataWriter connectionData);

        /// <summary>
        /// Force closes connection and stop all threads.
        /// </summary>
        void Stop();

        /// <summary>
        /// Force closes connection and stop all threads.
        /// </summary>
        /// <param name="sendDisconnectMessages">Send disconnect messages</param>
        void Stop(bool sendDisconnectMessages);

        /// <summary>
        /// Return peers count with connection state
        /// </summary>
        /// <param name="peerState">peer connection state (you can use as bit flags)</param>
        /// <returns>peers count</returns>
        int GetPeersCount(ConnectionState peerState);

        /// <summary>
        /// Get copy of current connected peers (slow! use GetPeersNonAlloc for best performance)
        /// </summary>
        /// <returns>Array with connected peers</returns>
        NetPeer[] GetPeers();

        /// <summary>
        /// Get copy of current connected peers (slow! use GetPeersNonAlloc for best performance)
        /// </summary>
        /// <returns>Array with connected peers</returns>
        NetPeer[] GetPeers(ConnectionState peerState);

        /// <summary>
        /// Get copy of peers (without allocations)
        /// </summary>
        /// <param name="peers">List that will contain result</param>
        /// <param name="peerState">State of peers</param>
        void GetPeersNonAlloc(List<NetPeer> peers, ConnectionState peerState);

        /// <summary>
        /// Disconnect all peers without any additional data
        /// </summary>
        void DisconnectAll();

        /// <summary>
        /// Disconnect all peers with shutdown message
        /// </summary>
        /// <param name="data">Data to send (must be less or equal MTU)</param>
        /// <param name="start">Data start</param>
        /// <param name="count">Data count</param>
        void DisconnectAll(byte[] data, int start, int count);

        /// <summary>
        /// Immediately disconnect peer from server without additional data
        /// </summary>
        /// <param name="peer">peer to disconnect</param>
        void DisconnectPeerForce(NetPeer peer);

        /// <summary>
        /// Disconnect peer from server
        /// </summary>
        /// <param name="peer">peer to disconnect</param>
        void DisconnectPeer(NetPeer peer);

        /// <summary>
        /// Disconnect peer from server and send additional data (Size must be less or equal MTU - 8)
        /// </summary>
        /// <param name="peer">peer to disconnect</param>
        /// <param name="data">additional data</param>
        void DisconnectPeer(NetPeer peer, byte[] data);

        /// <summary>
        /// Disconnect peer from server and send additional data (Size must be less or equal MTU - 8)
        /// </summary>
        /// <param name="peer">peer to disconnect</param>
        /// <param name="writer">additional data</param>
        void DisconnectPeer(NetPeer peer, INetDataWriter writer);

        /// <summary>
        /// Disconnect peer from server and send additional data (Size must be less or equal MTU - 8)
        /// </summary>
        /// <param name="peer">peer to disconnect</param>
        /// <param name="data">additional data</param>
        /// <param name="start">data start</param>
        /// <param name="count">data length</param>
        void DisconnectPeer(NetPeer peer, byte[] data, int start, int count);

        IEnumerator<NetPeer> GetEnumerator();
    }
}