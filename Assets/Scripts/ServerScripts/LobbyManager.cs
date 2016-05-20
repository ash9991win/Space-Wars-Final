using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using System.Net;
using NetworkClientExtensions;
//The lobby manager. This represents the lobby side of the server, it is encapsulated away from the UI and provides hooks 

public class LobbyManager : NetworkLobbyManager
{

    // Use this for initialization
    int mNumberOfClients;
    public static List<Client> mClientsConnected = new List<Client>();
    public static Dictionary<string, Client> mClientTable = new Dictionary<string, Client>();
    public delegate void PlayersConnectedEvent();
    public static event PlayersConnectedEvent MaxPlayersEvent;
    public int mNumberOfMaxClients;
    public NetworkDiscovery Discovery;
    void Start()
    {
        mNumberOfClients = 0;
        Discovery.showGUI = false;

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void StartupServer()
    {
        Debug.Log("Starting server");
        Discovery.Initialize();
        Discovery.StartAsServer();

        //    mDiscovery = gameObject.AddComponent<ClientDiscovery>();
        //mDiscovery.Initialize();
        //mDiscovery.StartAsServer();
        //singleton.networkAddress = IPAddress.Loopback.ToString();
        //singleton.networkPort = 7777;
        //singleton.StartServer();
        //find server script
    }

    public void SetIPAddress(string ipAdd)
    {
        singleton.networkAddress = ipAdd;
    }
    public void SetPort(int port)
    {
        singleton.networkPort = port;
    }
    public void Disconnect()
    {
        singleton.StopHost();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public override void OnLobbyServerConnect(NetworkConnection conn)
    {

        base.OnLobbyServerConnect(conn);

        Debug.Log("Client connected!");
        Client newClient = Server.mSingleton.gameObject.AddComponent<Client>();
        newClient.SetConnection(conn);
        mClientsConnected.Add(newClient);
        mNumberOfClients++;
        if (mNumberOfClients >= minPlayers)
        {
            Server.mSingleton.SetClientList(mClientsConnected);
            if (MaxPlayersEvent != null)
            {
                MaxPlayersEvent.Invoke();
                foreach(var cl in mClientsConnected)
                {
                    
                }
            }

        }
    }
    public override void OnLobbyClientConnect(NetworkConnection conn)
    {
        base.OnLobbyClientConnect(conn);
        Debug.Log("Client side connection!");
        LobbyPlayer player = lobbyPlayerPrefab.GetComponent<LobbyPlayer>();
        Client newClient = lobbyPlayerPrefab.GetComponent<Client>();
        player.SetClient(newClient);
        newClient.SetLobbyPlayer(player);
        newClient.SetConnection(conn);
        newClient.RegisterHandlers();
        Client.SetClient(newClient);
    }
   
   
    //public override void OnClientDisconnect(NetworkConnection conn)
    //{
    //    base.OnClientDisconnect(conn);
    //    //TODO: Change Linq query to normal foreach loop
    //    var clientToRemove = (from client in mClientsConnected
    //                          where (client.GetConnection() == conn)
    //                          where (mClientsConnected.Remove(client))
    //                          select client);

    //    mNumberOfClients--;
    //}
    public void JoinGame()
    {
        MenuManager.instance.SwitchMenu(Menus.ConnectingMenu);
        Discovery.showGUI = true;
       // Discovery.Initialize();
      //  Discovery.StartAsClient();
     //   ClientDiscovery discovery = gameObject.AddComponent<ClientDiscovery>();
        //discovery.Initialize();
        //discovery.StartAsClient();
     //   Debug.LogError("Client" + discovery.isClient);
        //singleton.networkAddress = IPAddress.Loopback.ToString();
        //singleton.networkPort = 7777;
        //singleton.StartClient();
    }
    public void SelectedCharacter()
    {
        //Send a message to the server 

        SelectCharacter.instance.SelectedACharacter();
        Client.GetClient().ToggleReady();
    }
}
