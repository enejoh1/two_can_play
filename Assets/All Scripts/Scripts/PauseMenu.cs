using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButtonImage;
    [SerializeField] GameObject playButtonImage;
    [SerializeField] GameObject pausefadeImage;
    [SerializeField] GameObject Fade_Out_Image;
    public static PauseMenu _instance;

    void Start()
    {
        pauseMenu.SetActive(false);
        pausefadeImage.SetActive(false);
        playButtonImage.SetActive(false);
        Fade_Out_Image.SetActive(false);
    }
    
    public void PlayButton()
    {
        EnablePlayerControls();
        EnableYellowJoiner();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseButtonImage.SetActive(true);
        playButtonImage.SetActive(false);
        pausefadeImage.SetActive(false);
        Fade_Out_Image.SetActive(false);



    }

    public void PauseGame() // on click event 
    {
        pauseMenu.SetActive(true);
        DisableYellowJoiner();
        DisablePlayerControls();
        pauseButtonImage.SetActive(false);
        Time.timeScale = 0;
        playButtonImage.SetActive(true);
        pausefadeImage.SetActive(true);
        Fade_Out_Image.SetActive(true);
    }

    void DisableYellowJoiner()
    {
        var YellowPlayer = FindObjectsOfType<YellowJoiner>(); // finds the current player script and disables them on pause
        foreach (YellowJoiner yellowJoiner in YellowPlayer)
        {
            yellowJoiner.enabled = false;

        }
    }

    void DisablePlayerControls()
    {
        var player = FindObjectsOfType<PlayerController>(); //circles both player script and disables them on pause
        foreach (PlayerController controller in player)
        {
            controller.enabled = false;
        }
    }

    public  void EnableYellowJoiner()
    {
        var YellowPlayer = FindObjectsOfType<YellowJoiner>(); // finds the current player script and disables them on Game over
        foreach (YellowJoiner yellowJoiner in YellowPlayer)
        {
            yellowJoiner.enabled = true;

        }
    }

    public  void EnablePlayerControls()
    {
        var player = FindObjectsOfType<PlayerController>(); //circles both player script and enables them 
        foreach (PlayerController controller in player)
        {
            controller.enabled = true;
        }
    }
    public void ResumeGame() // onclick event re-enables the player scripts when the player hits 'resume'.
    {
        EnablePlayerControls();
        EnableYellowJoiner();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseButtonImage.SetActive(true);

    }

    public void RestartScene() // reloads the current scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene("1_StartScreen");
    }
}
