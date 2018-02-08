using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager2{

    public static SceneManager2 Instance = new SceneManager2();

    public int isNewGame = -1;
    public int lvl = 0;

    public List<GameLocation> lvl1 = new List<GameLocation>();
    public List<GameLocation> lvl2 = new List<GameLocation>();

    public static void Init()
    {
        Instance.lvl1.Add(GameLocation.Location1);
        Instance.lvl1.Add(GameLocation.Location2);
        Instance.lvl1.Add(GameLocation.Location3);

        Instance.lvl2.Add(GameLocation.Location4);
        Instance.lvl2.Add(GameLocation.Location5);
        Instance.lvl2.Add(GameLocation.Location6);
    }
    
}
