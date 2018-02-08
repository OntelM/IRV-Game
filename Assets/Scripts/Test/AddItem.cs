using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {

    public InventoryItem item;
    public int ID;
    bool enable = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enable && Input.GetKeyDown(KeyCode.E))
        {
            foreach (var item in GameData.Instance.items)
            {
                if (item.ID == ID)
                {
                    addItemToInventory(item);
                    Debug.Log("Obiect Colectat");
                    Destroy(gameObject);
                }
            }
            enable = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Exista coliziune");
        enable = true;


    }



    public void addItemToInventory(InventoryItem item)
    {
        GameData.PickItem(item);

        InventoryPanel.Refresh();


    }



}
