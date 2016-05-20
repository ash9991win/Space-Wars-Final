using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public static class ClientMessages {

    public static short Death = 0x55;
    public static short Kill = 0x56;
    public static short Taunt = 0x57;
    public static short Rematch = 0x58;
    public static short Exit = 0x59;
    public static short Ship = 0x68;
    public static short SuperAttack = 0x69;
    public static short CharacterChosen = 0x70;
}
public static class ServerMessages
{
    public static short MainMenu = 0x60, ConnectingToLobby = 0x61, WaitingForPlayers = 0x62, CharacterSelect = 0x63, GameLoading = 0x64, GameStarting = 0x65, GameRunning = 0x66, GameEnding = 0x67;
}
public class DeathMessage : MessageBase
{
    public string mClientWhoDied { get; set; }
    public string mClientWhoKilled { get; set; }
    public string mShipThatDied { get; set; }
    
    public override void Deserialize(NetworkReader reader)
    {
        mClientWhoDied = reader.ReadString();
        mClientWhoKilled = reader.ReadString();
        mShipThatDied = reader.ReadString();
    }
    public override void Serialize(NetworkWriter writer)
    {
        writer.Write(mClientWhoDied);
        writer.Write(mClientWhoKilled);
        writer.Write(mShipThatDied);
    }
}
public class TauntMessage : MessageBase
{
    public string mSourceID { get; set; }
    public string mDestID { get; set; }
    public override void Deserialize(NetworkReader reader)
    {
        mSourceID = reader.ReadString();
        mDestID = reader.ReadString();
    }
    public override void Serialize(NetworkWriter writer)
    {
        writer.Write(mSourceID);
        writer.Write(mDestID);
    }
}
public class ShipMessage : MessageBase
{
    public string mShipID { get; set; }
}
public class CharacterChosenMessage : MessageBase
{
    public int mCharacterID { get; set; }
    public string mClientID { get; set; }
    public override void Deserialize(NetworkReader reader)
    {
        mClientID = reader.ReadString();
        mCharacterID = reader.ReadInt32();
    }
    public override void Serialize(NetworkWriter writer)
    {
        writer.Write(mClientID);
        writer.Write(mCharacterID);
    }
}
public class CharacterSelectMessage :MessageBase
{

}