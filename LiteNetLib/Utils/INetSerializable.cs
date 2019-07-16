namespace LiteNetLib.Utils
{
    public interface INetSerializable
    {
        void Serialize(INetDataWriter writer);
        void Deserialize(NetDataReader reader);
    }
}
