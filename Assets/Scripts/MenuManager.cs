using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public enum MenuState
    {
        main,
        shop,
        records
    }

    private MenuState state;

    [SerializeField]
    private List<GameObject> menus;

    // Start is called before the first frame update
    void Start()
    {
        state = MenuState.main;
        ParseState();
    }

    public void OnPlayButtonDown()
    {
        LoadGame();
    }

    public void SwitchToMenu(string menu)
    {
        state = (MenuState)Enum.Parse(typeof(MenuState), menu);
        ParseState();
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    private void ParseState()
    {
        switch (state)
        {
            case MenuState.main:
                SwitchToMenuType(menus[0]);
                break;
            case MenuState.shop:
                SwitchToMenuType(menus[1]);
                break;
            case MenuState.records:
                SwitchToMenuType(menus[2]);
                break;
        }
    }

    private void SwitchToMenuType(GameObject menuToEnable)
    {
        foreach(GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        menuToEnable.SetActive(true);
    }
}
