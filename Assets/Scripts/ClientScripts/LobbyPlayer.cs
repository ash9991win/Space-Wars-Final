using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LobbyPlayer : NetworkLobbyPlayer
{ 
    private Client mClient;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
	 if(mClient != null)
        {
            mClient.Update();
        }
	}
    public void ToggleReady()
    {
        if(isLocalPlayer)
        {
            if (!readyToBegin)
            {
                readyToBegin = true;
                SendReadyToBeginMessage();
            }
            else
            {
                readyToBegin = false;
            }
        }
    }
    
    public void SetClient(Client client)
    {
        mClient = client;
    }
}
