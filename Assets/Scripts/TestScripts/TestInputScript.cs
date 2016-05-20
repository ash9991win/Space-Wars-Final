using UnityEngine;
using System.Collections;

public class TestInputScript : MonoBehaviour {

    // Use this for initialization
    public LobbyManager manager;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyUp(KeyCode.A))
        {
            manager.StartupServer();
        }
	}
}
