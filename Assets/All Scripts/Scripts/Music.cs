using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefController.GetMasterVolume();

        int currentGameSession = FindObjectsOfType<Music>().Length;
        if (currentGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
      
    }
    public void SetVolume(float volume )
    {
        audioSource.volume = volume;
    }
   
}
