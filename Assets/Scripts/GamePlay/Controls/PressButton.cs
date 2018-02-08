using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour {

    public GameObject menu; // Assign in inspector
    private bool menubool;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            menubool = !menubool;
            menu.SetActive(menubool);
        }
    }
}
