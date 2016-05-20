using UnityEngine;
using System.Collections.Generic;

public enum Menus
{
    LobbyMenuClient,
    LobbyMenuServer,
    ConnectingMenu,
    CharacterSelectMenu,
    InGameMenuClient,
    InGameMenuServer
}


public class MenuManager : MonoBehaviour
{

    public List<GameObject> MenuObjectPrefabs;
    public List<GameObject> MenuObjectInstances;
    public static MenuManager instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }

    public void SetMenuVisibility(Menus menu, bool visibility)
    {
        if(MenuObjectInstances[(int)menu] != null)
        {
            MenuObjectInstances[(int)menu].SetActive(visibility);
            if(visibility == true)
            {
                currentMenu = (int)menu;
            }
        }
        else
        {
            Debug.Log(menu.ToString() + " is null");
        }
    }

    public void SwitchMenu(Menus menu)
    {
        if (MenuObjectInstances[(int)menu] != null)
        {
            SetMenuVisibility((Menus)currentMenu, false);
            SetMenuVisibility(menu, true);
        }
        else
        {
            Debug.Log(menu.ToString() + " is null");
        }
    }

    private int currentMenu;
}
