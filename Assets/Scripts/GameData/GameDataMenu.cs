using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMenu {

    public GameDataMenu Instance = new GameDataMenu();

    private static bool isLoaded = false;
    public delegate void LoadEvent();
    public static event LoadEvent OnLoad;


    public static void Load()
    {
        Debug.Log("GameDataMenu Menu is Loaded");
    }


}
