using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = .4f;
    [SerializeField] GameObject soundOff, soundOn;
    
    int volume;
    
    string StartScreen = "1_StartScreen";
    private bool isMuted;
  
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefController.GetMasterVolume();
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        volume = PlayerPrefs.GetInt ("Mute", volume);
    }

    public void MutePressed()
    {
        AudioListener.volume = 0f;
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        PlayerPrefs.GetInt("Mute", volume);
    }

    public void UnMutePressed()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.GetInt("Mute", volume);
    }

   


    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<Music>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.Log("Warning no music found, Go to start screen!");
        }
    }

    public void SaveandExit()
    {
        PlayerPrefController.SetMasterVolume(volumeSlider.value);

        
    }
    public void Home()
    {
        SceneManager.LoadScene(StartScreen);
    }

    public void ResetDefaultSettings()
    {
        volumeSlider.value = defaultVolume;

        
    }

}
