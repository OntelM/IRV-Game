using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

    public static Power Instance;
    public RectTransform rootElement;
    public PowerItem itemPrefab;
    public List<PowerItem> items = new List<PowerItem>();

    public List<InventoryItem> itemsInHand = new List<InventoryItem>();

    public float timeStart = 0.0f;
    private int nrItems = 0;

    // Use this for initialization
    void Start () {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {




        if (items.Count <= GameData.Instance.items.Count)
        {
            timeStart += Time.deltaTime;

            //Debug.Log(timeStart);

            if ((timeStart > 5.0f) && (nrItems < GameData.Instance.items.Count))
            {
                spawnIntems();

                timeStart = 0.0f;
                //startSpownItem = false;
            }
        }


        

    }

    public void spawnIntems()
    {
        var entry = CreateNewItemInstance(GameData.Instance.items[nrItems]);  //aici pot sa le spownez pe rand
        items.Add(entry);
        nrItems++;
    }

    public void Init()
    {
        foreach (var entry in items)
        {
            if (entry != null)
            {
                Destroy(entry.gameObject);
            }
        }
        items.Clear();
        itemsInHand.Clear();
        
    }

    public void Init2()
    {
        if ((items.Count != 0) && (Instance.itemsInHand.Count != 0))
        {

            bool existInScene = false;

            foreach (var item in items)
            {
                foreach (var item2 in Instance.itemsInHand)
                {
                    if (item.item.ID == item2.ID)
                    {
                        existInScene = true;        //verificare daca obiectul din mana este in scena
                        break;
                    }
                }

                foreach (var item2 in GameData.Instance.pickups)
                {
                    if (item.item.ID == item2.ID)
                    {
                        existInScene = true;        //verificare daca obiectul din mana este in scena
                        break;
                    }
                }

                if (existInScene)
                {
                    //item.gameObject(Destroy);
                    item.gameObject.SetActive(true);
                }
                existInScene = false;
            }
            Instance.itemsInHand.Clear();
        }
    }

    public static void Reload()
    {
        Instance.timeStart = 0.0f;
        Instance.nrItems = 0;
        Instance.Init();
    }

    public static void Refresh()
    {
        Instance.timeStart = 0.0f;
        Instance.nrItems = 0;
        Instance.Init2();
    }

    private PowerItem CreateNewItemInstance(InventoryItem item)
    {
        var entry = Instantiate(itemPrefab);
        entry.SetItem(item);
        entry.transform.SetParent(rootElement);
        entry.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        
        var randomX = Random.Range(0.0f, 24.0f);
        var randomY = Random.Range(0.0f, 24.0f);
        entry.position = new Vector3(randomX, 0.1f, randomY);
        entry.transform.localPosition = new Vector3(randomX, 0.1f, randomY);

        return entry;
    }



    public void EmptyHand()
    {
        if (items != null)
        {
            foreach (var item in items)
            {
                foreach (var item2 in Instance.itemsInHand)
                {
                    if (item.item.ID == item2.ID)
                    {
                        item.gameObject.SetActive(true);
                        break;
                    }
                }
                Instance.itemsInHand.Clear();
            }
        }
    }
}
