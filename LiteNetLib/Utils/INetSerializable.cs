namespace LiteNetLib.Utils
{
    public interface INetSerializable
    {
        void Serialize(INetDataWriter writer);
        void Deserialize(INetDataReader reader);
    }
}
