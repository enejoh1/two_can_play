using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPrefController : MonoBehaviour
{
    
    const string MASTER_VOLUME_KEY = "master volume";
   
    const float MIN_VOLUME = 0;
    const float MAX_VOLUME = 1;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Master Volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    
}
