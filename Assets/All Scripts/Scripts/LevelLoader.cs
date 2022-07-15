using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float transitionTime = 1.5f;
    [SerializeField] float timeToDestroy = 2f;
    [SerializeField]  Animator myAnimator;
    [SerializeField] GameObject quitNotice;
    
    private void Start()
    {
        if (quitNotice == null) { return; } // dont do anything, go about your business.
        quitNotice.SetActive(false);

    }
    private void Awake()
    {

        Time.timeScale = 1;
    }
    public void LoadNextScene()
    {
        StartCoroutine(LoadNextLevel()); // scene delay
    }

    public IEnumerator LoadNextLevel()
    {
        myAnimator.SetTrigger("crossfade"); // plays the animation first
        yield return new WaitForSeconds(transitionTime); // delays the scene load
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
    public IEnumerator NewGame()
    {
        myAnimator.SetTrigger("crossfade"); // plays the animation first
        yield return new WaitForSeconds(transitionTime); // delays the scene load
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex + 1);
        

    }

    public void Back()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // gets thee current scene index ie the current scene you are currently on
        SceneManager.LoadScene(currentSceneIndex - 1); //  then takes you back to the previous scene you left
    }

    public void BackToStartScreen()
    {
        SceneManager.LoadScene("1_StartScreen"); // load the startscreen
    }

    public void OnApplicationQuit() // closes the game
    {
        if (quitNotice == null) { return; }
        quitNotice.SetActive(true);
        Time.timeScale = 1;
    }

    public void YesQuitGame() // closes the game after player agrees
    {
        Application.Quit();
        quitNotice.SetActive(false);
        print("Closing Game");
        Time.timeScale = 1;
    }
    public void NoQuit() // closes the quit notification 
    {
        quitNotice.SetActive(false);
        Time.timeScale = 1;
    }



    public void Options() // Options menu
    {
        SceneManager.LoadScene("Options");
    }
    
    public void RestartScene() // reload the current scene and returns it back
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // gets the current scene and returns the current level
        Time.timeScale = 1;
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void Home()
    {
        SceneManager.LoadScene("1_StartScreen");
        Time.timeScale = 1;
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
        
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevelFour()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevelFive()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevelSix()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadLevelSeven()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadLevelEight()
    {
        SceneManager.LoadScene(8);
    }

    public void LoadLevelNine()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadLevelTen()
    {
        SceneManager.LoadScene(10);
    }
    public void LoadLevelEleven()
    {
        SceneManager.LoadScene(11);
    }
    public void LoadLevelTwelve()
    {
        SceneManager.LoadScene(12);
    }

    public void LoadLevelThirteen()
    {
        SceneManager.LoadScene(13);
    }
    public void LoadLevelFourteen()
    {
        SceneManager.LoadScene(14);
        
    }
     public void LoadLevelFifteen()
    {
        SceneManager.LoadScene(15);
        
    }
    public void LoadLevelSixteen()
    {
        SceneManager.LoadScene(16);

    }
    public void LoadLevelSeventeen()
    {
        SceneManager.LoadScene(17);

    }
    public void LoadLevelEighteen()
    {
        SceneManager.LoadScene(18);

    }

    public void LoadLevelNineTeen()
    {
        SceneManager.LoadScene(19);

    }
    public void LoadLevelTwenty()
    {
        SceneManager.LoadScene(20);

    }


}
