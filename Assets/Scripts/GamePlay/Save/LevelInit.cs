using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelInit : MonoBehaviour
{
    

    public GameObject player;
    public CheckPoint[] locations;


    int i = 0;

    // Use this for initialization
    void Start()
    {
        GameData.OnDataInit(SpawnPlayer);
        Power.Reload();
        

    }

    private void RefreshObj()
    {
        Power.Refresh();
        InventoryPanel.Refresh();
    }

    private void SpawnPlayer()
    {

        RefreshObj();

        CheckPoint loc;
        foreach (var location in locations)
        {
            if (location.location == GameData.Instance.locationId)
            {
                loc = location;
                if (player != null)
                {
                    player.transform.position = new Vector3(0, 0, 0) + location.transform.position;
                    
                }
                break;
            }
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnPlayer();
        }
    }

    

}
