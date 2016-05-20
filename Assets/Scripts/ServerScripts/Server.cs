using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Server : NetworkBehaviour {

    // Use this for initialization
    private static List<Client> mClientsConnected = new List<Client>();
    private static Dictionary<string, Client> mClientTable = new Dictionary<string, Client>();
    public static Server mSingleton { get; private set; }
    void Awake()
    {
        mSingleton = this;
        NetworkServer.RegisterHandler(ClientMessages.Ship, ReceiveShipMessage);
        NetworkServer.RegisterHandler(ClientMessages.CharacterChosen, CharacterSelectedMessage);
        LobbyManager.MaxPlayersEvent += ClientsCanSelectCharacters;
    }
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetClientList(List<Client> client)
    {
        mClientsConnected = client;
        
    }
    public void SendMessageTo(string id,short msgType, MessageBase msg)
    {
        if(mClientTable.ContainsKey(id))
        {
            mClientTable[id].Send(msgType, msg);
        }
    }
    public static void BroadCast(short msgType,MessageBase msg)
    {
        NetworkServer.SendToAll(msgType, msg);
    }
    public void ReceiveShipMessage(NetworkMessage msg)
    {
        Debug.Log("Received message from client about ship");
        
    }
    public void CharacterSelectedMessage(NetworkMessage msg)
    {
        CharacterChosenMessage charMsg = msg.ReadMessage<CharacterChosenMessage>();
        BroadCast(ClientMessages.CharacterChosen, charMsg);
    }
    public void ClientsCanSelectCharacters()
    {
        BroadCast(ServerMessages.CharacterSelect, new CharacterSelectMessage());
    }
}
