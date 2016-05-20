using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ClientDiscovery : NetworkDiscovery {



    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        //base.OnReceivedBroadcast(fromAddress, data);
        Debug.LogError("Receved connection");
        NetworkManager.singleton.networkAddress = fromAddress;
        NetworkManager.singleton.StartClient();
        
    }
}
