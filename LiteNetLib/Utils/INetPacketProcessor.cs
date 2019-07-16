using System;

namespace LiteNetLib.Utils
{
    public interface INetPacketProcessor
    {
        //FNV-1 64 bit hash
        ulong GetHash(Type type);
        
        /// <summary>
        /// Register nested property type
        /// </summary>
        /// <typeparam name="T">INetSerializable structure</typeparam>
        /// <returns>True - if register successful, false - if type already registered</returns>
        bool RegisterNestedType<T>() where T : struct, INetSerializable;

        /// <summary>
        /// Register nested property type
        /// </summary>
        /// <param name="writeDelegate"></param>
        /// <param name="readDelegate"></param>
        /// <returns>True - if register successful, false - if type already registered</returns>
        bool RegisterNestedType<T>(Action<INetDataWriter, T> writeDelegate, Func<NetDataReader, T> readDelegate);

        /// <summary>
        /// Reads all available data from NetDataReader and calls OnReceive delegates
        /// </summary>
        /// <param name="reader">NetDataReader with packets data</param>
        void ReadAllPackets(NetDataReader reader);

        /// <summary>
        /// Reads all available data from NetDataReader and calls OnReceive delegates
        /// </summary>
        /// <param name="reader">NetDataReader with packets data</param>
        /// <param name="userData">Argument that passed to OnReceivedEvent</param>
        /// <exception cref="ParseException">Malformed packet</exception>
        void ReadAllPackets(NetDataReader reader, object userData);

        /// <summary>
        /// Reads one packet from NetDataReader and calls OnReceive delegate
        /// </summary>
        /// <param name="reader">NetDataReader with packet</param>
        /// <exception cref="ParseException">Malformed packet</exception>
        void ReadPacket(NetDataReader reader);

        void Send<T>(NetPeer peer, T packet, DeliveryMethod options) where T : class, new();
        void SendNetSerializable<T>(NetPeer peer, T packet, DeliveryMethod options) where T : INetSerializable;
        void Send<T>(NetManager manager, T packet, DeliveryMethod options) where T : class, new();
        void SendNetSerializable<T>(NetManager manager, T packet, DeliveryMethod options) where T : INetSerializable;
        void Write<T>(INetDataWriter writer, T packet) where T : class, new();
        void WriteNetSerializable<T>(INetDataWriter writer, T packet) where T : INetSerializable;
        byte[] Write<T>(T packet) where T : class, new();
        byte[] WriteNetSerializable<T>(T packet) where T : INetSerializable;

        /// <summary>
        /// Reads one packet from NetDataReader and calls OnReceive delegate
        /// </summary>
        /// <param name="reader">NetDataReader with packet</param>
        /// <param name="userData">Argument that passed to OnReceivedEvent</param>
        /// <exception cref="ParseException">Malformed packet</exception>
        void ReadPacket(NetDataReader reader, object userData);

        /// <summary>
        /// Register and subscribe to packet receive event
        /// </summary>
        /// <param name="onReceive">event that will be called when packet deserialized with ReadPacket method</param>
        /// <param name="packetConstructor">Method that constructs packet intead of slow Activator.CreateInstance</param>
        /// <exception cref="InvalidTypeException"><typeparamref name="T"/>'s fields are not supported, or it has no fields</exception>
        void Subscribe<T>(Action<T> onReceive, Func<T> packetConstructor) where T : class, new();

        /// <summary>
        /// Register and subscribe to packet receive event (with userData)
        /// </summary>
        /// <param name="onReceive">event that will be called when packet deserialized with ReadPacket method</param>
        /// <param name="packetConstructor">Method that constructs packet intead of slow Activator.CreateInstance</param>
        /// <exception cref="InvalidTypeException"><typeparamref name="T"/>'s fields are not supported, or it has no fields</exception>
        void Subscribe<T, TUserData>(Action<T, TUserData> onReceive, Func<T> packetConstructor) where T : class, new();

        /// <summary>
        /// Register and subscribe to packet receive event
        /// This metod will overwrite last received packet class on receive (less garbage)
        /// </summary>
        /// <param name="onReceive">event that will be called when packet deserialized with ReadPacket method</param>
        /// <exception cref="InvalidTypeException"><typeparamref name="T"/>'s fields are not supported, or it has no fields</exception>
        void SubscribeReusable<T>(Action<T> onReceive) where T : class, new();

        /// <summary>
        /// Register and subscribe to packet receive event
        /// This metod will overwrite last received packet class on receive (less garbage)
        /// </summary>
        /// <param name="onReceive">event that will be called when packet deserialized with ReadPacket method</param>
        /// <exception cref="InvalidTypeException"><typeparamref name="T"/>'s fields are not supported, or it has no fields</exception>
        void SubscribeReusable<T, TUserData>(Action<T, TUserData> onReceive) where T : class, new();

        void SubscribeNetSerializable<T, TUserData>(
            Action<T, TUserData> onReceive, 
            Func<T> packetConstructor) where T : INetSerializable;

        void SubscribeNetSerializable<T>(
            Action<T> onReceive,
            Func<T> packetConstructor) where T : INetSerializable;

        void SubscribeNetSerializable<T, TUserData>(
            Action<T, TUserData> onReceive) where T : INetSerializable, new();

        void SubscribeNetSerializable<T>(
            Action<T> onReceive) where T : INetSerializable, new();

        /// <summary>
        /// Remove any subscriptions by type
        /// </summary>
        /// <typeparam name="T">Packet type</typeparam>
        /// <returns>true if remove is success</returns>
        bool RemoveSubscription<T>();
    }
}