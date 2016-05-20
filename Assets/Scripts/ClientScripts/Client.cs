using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public enum ClientStates
{
    MainMenu,ConnectingToLobby,WaitingForPlayers,CharacterSelect,GameLoading,GameStarting,GameRunning,GameEnding
}
public class Client : NetworkBehaviour {

    // Use this for initialization
    private NetworkConnection mConnection;
    private LobbyPlayer mPlayer;
    private string mID;
    private int mPort;
    private static Client ClientObject;
    public ClientStates mCurrentState
    {
        get { return mCurrentState; }
        set {  }
    }
    public Client()
        :base()
    {

    }
    public void AssignID(string id)
    {
        mID = id;
    }
    public string GetID()
    {
        return mID;
    }
	void Start () {
    
	}
    public NetworkConnection GetConnection()
    {
        return mConnection;
    }
    public void SetPort(int port)
    {
        mPort = port;
    }
    public void SetLobbyPlayer(LobbyPlayer player)
    {
        mPlayer = player;
    }
    public void SetConnection(NetworkConnection conn)
    {
        mConnection = conn;

    }
    public void RegisterHandlers()
    {
        Debug.Log("Registering handlers");
        mConnection.RegisterHandler(ClientMessages.CharacterChosen, CharacterSelectedMessageHandler);
        mConnection.RegisterHandler(ServerMessages.CharacterSelect, CharacterSelectAbility);
        Send(ClientMessages.Ship, new ShipMessage());
    }
    public void ToggleReady()
    {
        if(mPlayer != null)
        {
            mPlayer.ToggleReady();
        }
        else
        {
            Debug.Log("Lobby plater is empty");
        }
    }
	// Update is called once per frame
	public void Update () {
	
	}

    public void Send(short msgType,MessageBase msg)
    {
        if(mConnection != null)
        {
            mConnection.Send(msgType, msg);
        }
    }
    
    public void CharacterSelectedMessageHandler(NetworkMessage m)
    {

            CharacterChosenMessage msg = m.ReadMessage<CharacterChosenMessage>();
            SelectCharacter.instance.ClientSelectedACharacter(msg);

    }
    public void CharacterSelectAbility(NetworkMessage m)
    {
            MenuManager.instance.SwitchMenu(Menus.CharacterSelectMenu);
    }
 
   public static Client GetClient()
    {
        return ClientObject;
    }
    public static void SetClient(Client client)
    {
        ClientObject = client;
    }
}
