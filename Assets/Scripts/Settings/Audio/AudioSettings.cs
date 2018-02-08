using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioSettings : MonoBehaviour {

    
    public Slider Music;
    public Slider Ambiental;
    public Slider Voice;
    public Slider SFX;

    public Button Save;


    // Use this for initialization
    void Start () {
        
        ConfigureSlider(Music, AudioManager.AudioChannel.Music);
        ConfigureSlider(Ambiental, AudioManager.AudioChannel.Ambiental);
        ConfigureSlider(Voice, AudioManager.AudioChannel.Voice);
        ConfigureSlider(SFX, AudioManager.AudioChannel.SFX);
        
        Save.onClick.AddListener(SaveAudioSettings);
    }

    private void ConfigureSlider(Slider slider, AudioManager.AudioChannel channel)
    {
        if (!slider)
            return;

        slider.value = AudioManager.GetVolume(channel);

        slider.onValueChanged.AddListener((float value) => {
            AudioManager.SetVolume(channel, value);
        });
    }

    public void SaveAudioSettings()
    {
        AudioManager.SaveSettings();
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SaveAudioSettings();
        }
    }
}
