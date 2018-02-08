using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour {
    
    public InventoryItem item;
    public int ID;
    public Vector3 position;
    bool enable = false;
    bool isActive = true;





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
                    reloadObj();
                    break;
                }
            }
            enable = false;
        }
    }

    public void reloadObj()
    {
        this.gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void addItemToInventory(InventoryItem item)
    {
        AudioManager.PlaySFX(AudioResources.Instance.collectItems);
        GameData.PickItem(item);
        InventoryPanel.Refresh();


    }
    public void SetItem(InventoryItem item)
    {
        this.item = item;
        this.ID = item.ID;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Exista coliziune");
        enable = true;


    }
}
