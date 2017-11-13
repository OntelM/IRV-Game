using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager Instance;

    //public delegate void InitFunc(bool state);
    //public static event InitFunc OnInit;
    //public LevelInit levelInit;


    public static GameManager Get()
    {
        return Instance;
    }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            Init();
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("GameManager Instance: " + (Instance == this));
        }
    }

    public void Init()
    {
        GameData.Load();
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("GameLocation");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameData.Load();
            print("Load");
        }

    }
}
