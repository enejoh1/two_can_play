using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelProgression : MonoBehaviour
{
    [SerializeField] GameObject[] levelImage; // array of gameobject levelimages
    [SerializeField] Button[] GetButtons;// array of button in the editor
    [SerializeField] GameObject deleteAll; // pops up the delete gameobject
    
    
    int levelUnlock;
    
    void Start()
    {
        deleteAll.SetActive(false);

        levelUnlock = PlayerPrefs.GetInt("levelUnlock", 0); // saves the player progress in the player pref
        for (int i = 0; i < levelImage.Length; i++) // loops through all the lockImages and makes it non interactable
        {

            levelImage[i].SetActive(true); // lock images are set active on start
            GetButtons[i].interactable = false; // makes the buttons non interactable on start
        }
        for (int i = 0; i < levelUnlock; i++) //loops through the level unlocks the level one at a time
        {

            GetButtons[i].interactable = true;
            levelImage[i].SetActive(false);

        }
        
    }

    public void EnableDeleteAll()
    {
        deleteAll.SetActive(true);
        Time.timeScale = 0;
        
        
    }
  
    public void NoDelete()
    {
        deleteAll.SetActive(false);
        Time.timeScale = 1;
    }

    public void YesDeleteAll()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        deleteAll.SetActive(false);
        PlayerPrefs.DeleteAll();

    }

    public void LoadLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }

   

}
