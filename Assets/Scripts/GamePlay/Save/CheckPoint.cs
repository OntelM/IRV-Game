using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameLocation
{
    NotSet,

    Location1,
    Location2,
    Location3,

    Location4,
    Location5,
    Location6,

    Count
}




public class CheckPoint : MonoBehaviour {

    public GameLocation location;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerArea");
        GameData.Instance.locationId = location;
        GameData.Save();
    }
}
