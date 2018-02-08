using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager Instance;

    //public delegate void InitFunc(bool state);
    //public static event InitFunc OnInit;
    //public LevelInit leveInit;

    private int currentSceneId = -1;
    private int isNewGame = -1;

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
        AudioManager.Init();
        //GameData.Load();
        SceneManager2.Init();
        GameDataMenu.Load();
        
        //currentSceneId = SceneManager.GetActiveScene().buildIndex;
    }

    public void playSaund()
    {
        //Loadul se face inainte ca audio resource sa fie instantata
        if ((currentSceneId != SceneManager.GetActiveScene().buildIndex) || (currentSceneId == -1))
        {
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 0:
                    AudioManager.StopAmbientalSound(AudioResources.Instance.ambientalMusic[0]);
                    AudioManager.StopAmbientalSound(AudioResources.Instance.ambientalMusic[1]);
                    
                    AudioManager.StopBackgroundMusic(AudioResources.Instance.backgroundMusic[1]);
                    AudioManager.StopBackgroundMusic(AudioResources.Instance.backgroundMusic[2]);
                    AudioManager.PlayBackgroundMusic(AudioResources.Instance.backgroundMusic[0]);

                    break;
                case 1:
                    //Start Ambinetal and background soung
                    AudioManager.StopBackgroundMusic(AudioResources.Instance.backgroundMusic[0]);
                    AudioManager.PlayBackgroundMusic(AudioResources.Instance.backgroundMusic[1]);

                    AudioManager.PlayAmbientalSound(AudioResources.Instance.ambientalMusic[0]);
                    AudioManager.PlayAmbientalSound(AudioResources.Instance.ambientalMusic[1]);

                    break;
                case 2:
                    //Start Ambinetal and background soung
                    AudioManager.StopBackgroundMusic(AudioResources.Instance.backgroundMusic[0]);
                    AudioManager.StopBackgroundMusic(AudioResources.Instance.backgroundMusic[1]);
                    AudioManager.PlayBackgroundMusic(AudioResources.Instance.backgroundMusic[2]);

                    AudioManager.PlayAmbientalSound(AudioResources.Instance.ambientalMusic[0]);
                    AudioManager.PlayAmbientalSound(AudioResources.Instance.ambientalMusic[1]);

                    break;
            }
            currentSceneId = SceneManager.GetActiveScene().buildIndex;
        }

    }

    public void NewGame()
    {
        if (SceneManager2.Instance.isNewGame != -1)
        {
            if (SceneManager2.Instance.isNewGame == 1)  //LoadingScreenControll.Instance.isActiveAndEnabled
            {
                GameData.NewGame();
            }
            else if(SceneManager2.Instance.isNewGame == 0)
            {
                GameData.Load();
            }
            //SceneManager2.Instance.isNewGame = -1;
        }
        
    }

	// Use this for initialization
	void Start () {
        
    }
    // Update is called once per frame
    void Update () {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {

                GameData.NewGame();
                Debug.Log("New Game");
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("GameLocation");
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                //Power.Instance.EmptyHand();
                GameData.Load();
                Debug.Log("Load");
            }
        }

        NewGame();
        playSaund();

        
    }


}
