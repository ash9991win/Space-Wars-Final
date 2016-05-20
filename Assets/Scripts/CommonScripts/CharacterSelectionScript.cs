using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using NetworkClientExtensions;
//This class represents the character selection script. On the client side, it displays the characters available, on the server side it does the processing of chosen characters. 

public class CharacterSelectionScript : NetworkBehaviour
{
    public  Dictionary<string, bool> mTeamIDs = new Dictionary<string, bool>();
    NetworkClient mClient;
	// Use this for initialization
    public CharacterSelectionScript()
    {
     
    }
    
    void Start () {
        PopulateIDs();
	}
	void PopulateIDs()
    {
        mTeamIDs.Add("CAT", false);
        mTeamIDs.Add("DOG", false);
        mTeamIDs.Add("FROG", false);
        mTeamIDs.Add("ROBOT", false);
        
    }
	// Update is called once per frame
	void Update () {
	
	}
    void Init(NetworkClient client)
    {
        mClient = client;
    }
    void AssignCat()
    {
        if (!mTeamIDs["CAT"])
        {
            mClient.AssignUniqueID("CAT");

        }
        
    }
    void AssignFrog()
    {
      
    }
    void AssignRobot()
    {

    }
    void AssignDog()
    {
        
    }
    [Command]
    void CmdTellServerMyChoice(string choice)
    {

    }
}
