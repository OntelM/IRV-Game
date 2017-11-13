using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInit : MonoBehaviour {

    public GameObject player;
    public CheckPoint[] locations;




	// Use this for initialization
	void Start () {
        GameData.OnDataInit(SpawnPlayer);
	}

    private void SpawnPlayer()
    {
        CheckPoint loc;
        foreach (var location in locations)
        {
            if (location.location == GameData.Instance.locationId)
            {
                loc = location;
                player.transform.position = loc.transform.position + new Vector3(0, 0, 0);
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnPlayer();
        }
    }
}
