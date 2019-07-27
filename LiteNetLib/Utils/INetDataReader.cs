using System;
using System.Net;

namespace LiteNetLib.Utils
{
    public interface INetDataReader
    {
        byte[] RawData { get; }
        int RawDataSize { get; }
        int UserDataOffset { get; }
        int UserDataSize { get; }
        bool IsNull { get; }
        int Position { get; }
        bool EndOfData { get; }
        int AvailableBytes { get; }
        void SetSource(NetDataWriter dataWriter);
        void SetSource(byte[] source);
        void SetSource(byte[] source, int offset);
        void SetSource(byte[] source, int offset, int maxSize);
        IPEndPoint GetNetEndPoint();
        byte GetByte();
        sbyte GetSByte();
        bool[] GetBoolArray();
        ushort[] GetUShortArray();
        short[] GetShortArray();
        long[] GetLongArray();
        ulong[] GetULongArray();
        int[] GetIntArray();
        uint[] GetUIntArray();
        float[] GetFloatArray();
        double[] GetDoubleArray();
        string[] GetStringArray();
        string[] GetStringArray(int maxStringLength);
        bool GetBool();
        char GetChar();
        ushort GetUShort();
        short GetShort();
        long GetLong();
        ulong GetULong();
        int GetInt();
        uint GetUInt();
        float GetFloat();
        double GetDouble();
        string GetString(int maxLength);
        string GetString();
        ArraySegment<byte> GetRemainingBytesSegment();
        T Get<T>() where T : INetSerializable, new();
        byte[] GetRemainingBytes();
        void GetBytes(byte[] destination, int start, int count);
        void GetBytes(byte[] destination, int count);
        sbyte[] GetSBytesWithLength();
        byte[] GetBytesWithLength();
        byte PeekByte();
        sbyte PeekSByte();
        bool PeekBool();
        char PeekChar();
        ushort PeekUShort();
        short PeekShort();
        long PeekLong();
        ulong PeekULong();
        int PeekInt();
        uint PeekUInt();
        float PeekFloat();
        double PeekDouble();
        string PeekString(int maxLength);
        string PeekString();
        bool TryGetByte(out byte result);
        bool TryGetSByte(out sbyte result);
        bool TryGetBool(out bool result);
        bool TryGetChar(out char result);
        bool TryGetShort(out short result);
        bool TryGetUShort(out ushort result);
        bool TryGetInt(out int result);
        bool TryGetUInt(out uint result);
        bool TryGetLong(out long result);
        bool TryGetULong(out ulong result);
        bool TryGetFloat(out float result);
        bool TryGetDouble(out double result);
        bool TryGetString(out string result);
        bool TryGetStringArray(out string[] result);
        bool TryGetBytesWithLength(out byte[] result);
        void Clear();
    }
}