using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;



[XmlRoot("GameData")]
public class GameData{
    public static GameData Instance = new GameData();

    private static string XMLFileName = "/GameData.xml";
    private static string gameDataFile = Application.persistentDataPath + XMLFileName;

    private static bool isLoaded = false;
    public delegate void LoadEvent();
    public static event LoadEvent OnLoad;
    public int isNewGame;
    

    [XmlElement("GameLocation")]
    public GameLocation locationId;

    [XmlElement("Item")]
    public InventoryItem item;

    [XmlArray("Items")]
    public List<InventoryItem> items = new List<InventoryItem>();

    [XmlArray("InventoryItems")]
    public List<InventoryItem> pickups = new List<InventoryItem>();

    [XmlArray("SkillSlots")]
    public List<InventoryItem> skillSlots = new List<InventoryItem>();

    public static void NewGame()
    {
        Instance.pickups.Clear();
        Instance.items.Clear();
        //Power.Instance.itemsInHand.Clear();
        Instance.locationId = GameLocation.Location1;

        Instance.items.Add(new InventoryItem(0, 0, 1, "name1", "description1"));
        Instance.items.Add(new InventoryItem(1, 0, 1, "name2", "description2"));
        Instance.items.Add(new InventoryItem(2, 0, 1, "name3", "description3"));
        Instance.items.Add(new InventoryItem(3, 0, 1, "name4", "description4"));


        Power.Reload();
        Save();
        Load();
    }

    public static void Load()
    {
        
        Debug.Log(gameDataFile);
        if (File.Exists(gameDataFile))
        {
            // Load info from XML
            var serializer = new XmlSerializer(typeof(GameData));
            var stream = new FileStream(gameDataFile, FileMode.Open);
            try
            {
                Instance = serializer.Deserialize(stream) as GameData;
                stream.Close();

                Debug.Log("Gameplay loaded: " + gameDataFile);
                
                isLoaded = true;
                if (OnLoad != null)
                {
                    OnLoad();
                }
                
            }
            catch (System.Exception e)
            {
                stream.Close();
                //NewGame();
                Save();
            }
            
        }
        else
        {
            NewGame();
            Save();
        }
        SceneManager2.Instance.isNewGame = -1;
    }

    public static void Save()
    {
        if (Power.Instance.itemsInHand.Count != 0)
        {
            foreach (var itm in Power.Instance.itemsInHand)
            {
                Instance.pickups.Add(itm);
                Instance.items.Remove(itm);
            }
            Power.Instance.itemsInHand.Clear();
        }

        var serializer = new XmlSerializer(typeof(GameData));
        var stream = new FileStream(gameDataFile, FileMode.Create);
        serializer.Serialize(stream, Instance);
        stream.Close();

        Debug.Log("Gameplay saved again: " + gameDataFile);
        Debug.Log(Application.persistentDataPath);
    }

    public static void OnDataInit(LoadEvent callback)
    {
        OnLoad += callback;

        if (isLoaded == true)
        {
            callback();
        }
        else
        {
            Debug.Log("Game Data Not loaded!");
        }
    }

    public static void RemoveCallback(LoadEvent callback)
    {
        OnLoad -= callback;
    }

    public static void PickItem(InventoryItem item)
    {
        //Instance.pickups.Add(item);

        Power.Instance.itemsInHand.Add(item);
        //Instance.items.Remove(item);
    }
}
