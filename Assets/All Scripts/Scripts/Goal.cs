using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // parameter
    public static Goal singleton;
    [SerializeField] GameObject goalPrefab;
    [SerializeField] float sceneDelay = 2.5f;
    
    //configs
    AudioSource myAudioSource;
    ArrowAnimation arrowAnimation;

    
    int currentLevel = 0;

    void Awake()
    {
        Physics2D.queriesHitTriggers = true;
        singleton = this;
        
    }
    void Start()
    {

        myAudioSource = GetComponent<AudioSource>();
        arrowAnimation = FindObjectOfType<ArrowAnimation>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            DisablePlayerControls(); // Player controls are being disabled once the level is achieved
            DisableYellowJoiner(); // spectre is disable once the player wins the level
            PlaySound(); // plays win sound
            InstantiateParticle(); // plays the particle effect on goal
            NextLevel(); // trigger the next level
            FindObjectOfType<SwipeCounter>().DeactivateGameOverScreen(); //deactivates game over screen if win is true and moves is 0.
            ArrowsDeactivate(); // deactivates the  arrows when win is true.
            FindObjectOfType<SwipeCounter>().StopAnimation(); // stops the moves the animation when the level is achieved
            FindObjectOfType<SwipeCounter>().SetGameParticle(); // sets the game particle to true when the level is won
          
            
        }

        

    }
    void ArrowsDeactivate()
    {
        if (arrowAnimation == null) return;
        arrowAnimation.DeactivateArrowImage(); // deactivates the arrow images 
    }

    void PlaySound() // play win sound
    {
        myAudioSource.Play(); // win sound
        
    }

    private void DisableYellowJoiner()
    {
        var YellowPlayer = FindObjectsOfType<YellowJoiner>(); // spectre script disabled on win
        foreach (YellowJoiner yellowJoiner in YellowPlayer)
        {
            yellowJoiner.enabled = false;
        }
    }
    private void DisablePlayerControls()
    {
        var player = FindObjectsOfType<PlayerController>(); // all player controls being disabled on win
        foreach (PlayerController controller in player)
        {
            controller.enabled = false;
        }
    }


    private void InstantiateParticle()
    {
        Instantiate(goalPrefab, transform.position, Quaternion.identity); // creates a clone of the particle system
        Destroy(gameObject, 5.5f); // destroying the particle system
    }


    public void NextLevel()
    {
        StartCoroutine(LoadScene()); // delays the next level for animation to play
    }
    public void UnlockNextLevel() // unlocks a new level on goal
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        
        
        if(currentLevel > PlayerPrefs.GetInt("levelUnlock"))
        {
            PlayerPrefs.SetInt("levelUnlock", currentLevel); // finds the playerprefs and saves it in the player profile
        }

        Debug.Log(" LevelUnlock " + PlayerPrefs.GetInt("levelUnlock") + " Unlocked "); // for debugging purposes, print to the console which level has been unlocked
    }

    
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(sceneDelay); //scene delay
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // next scene load
        UnlockNextLevel();


    }



    private void OnTriggerStay2D(Collider2D collision)
    {
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    CanTeleport = false;
    //    TeleportB._instance.CanTeleport = false;
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }




}
