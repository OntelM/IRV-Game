using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System.IO;
using System;

[XmlRoot("GameData")]
public class GameData{
    public static GameData Instance = new GameData();

    private static string XMLFileName = "/GameData.xml";
    private static string gameDataFile = Application.persistentDataPath + XMLFileName;

    private static bool isLoaded;
    public delegate void LoadEvent();
    public static event LoadEvent OnLoad;

    [XmlElement("GameLocation")]
    public GameLocation locationId;

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
                    Debug.Log("OnLoad......................");
                }

            }
            catch (System.Exception e)
            {
                stream.Close();
                
            }
        }



    }

    private static void print(string v)
    {
        throw new NotImplementedException();
    }

    public static void Save()
    {
        var serializer = new XmlSerializer(typeof(GameData));
        var stream = new FileStream(gameDataFile, FileMode.Create);
        serializer.Serialize(stream, Instance);
        stream.Close();

        Debug.Log("Gameplay saved again: " + gameDataFile);
    }

    public static void OnDataInit(LoadEvent callBack)
    {
        OnLoad += callBack;
        if (isLoaded == true)
        {
            callBack();
        }else
        {
            Debug.Log("Game Data Not loaded!");
        }
    }

    public static void RemoveCallBack(LoadEvent callBack)
    {
        OnLoad -= callBack;
    }


}
