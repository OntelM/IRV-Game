using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControll : MonoBehaviour {

    public static LoadingScreenControll Instance;

    public GameObject loadingScreen;
    public Slider slider;

    private bool isNewGame;

    void Start()
    {
        Instance = this;
    }

    public void NewGame(bool isNew)
    {
        isNewGame = isNew;
    }

    public void LoadLevel(int sceneIndex)
    {
        
        if (sceneIndex != 0)
        {
            //if (SceneManager2.Instance.lvl == 1)
            //{
            //    GameData.Instance.locationId = GameLocation.Location1;
            //}
            //else if ((SceneManager2.Instance.lvl == 2) && ())
            //{
            //    GameData.Instance.locationId = GameLocation.Location4;
            //}
            if (!isNewGame)
            {
                if ((SceneManager2.Instance.lvl == 1) && (!SceneManager2.Instance.lvl1.Contains(GameData.Instance.locationId)))
                {
                    GameData.Instance.locationId = GameLocation.Location1;
                }
                else if ((SceneManager2.Instance.lvl == 2) && (!SceneManager2.Instance.lvl2.Contains(GameData.Instance.locationId)))
                {
                    GameData.Instance.locationId = GameLocation.Location4;
                }
            }
            else
            {
                SceneManager2.Instance.lvl = 1;
                GameData.Instance.locationId = GameLocation.Location1;
            }
            

            var sL = GameData.Instance.locationId;
            if ((sL == GameLocation.Location1) || (sL == GameLocation.Location2) || (sL == GameLocation.Location3))
            {
                sceneIndex = 1;
            }
            else if ((sL == GameLocation.Location4) || (sL == GameLocation.Location5) || (sL == GameLocation.Location6))
            {
                sceneIndex = 2;
            }
        }   
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
   
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        float isDone = 0.0f;
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            

            if (isDone == 1.0f)
            {
                if (isNewGame)
                {
                    //SceneManager2.Instance.lvl = 1;
                    SceneManager2.Instance.isNewGame = 1;
                }
                else
                {
                    SceneManager2.Instance.isNewGame = 0;
                }
            }

            slider.value = progress;
            isDone = progress;

            yield return null;
        }
        
    }
	
}
