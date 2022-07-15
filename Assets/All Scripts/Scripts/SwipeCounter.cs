using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class SwipeCounter : MonoBehaviour
{
    // parameters
    [HideInInspector]
    public int movesLeft; 
    public static SwipeCounter _instance;
    public TextMeshProUGUI SwipeCountsText;
    public GameObject gameOver;
    [SerializeField] float timeToDisplayGameOver = 3f;
    [SerializeField] [Range(0, 500)] int totalMoves = 100;
    [SerializeField] GameObject gameParticle;
    [SerializeField] GameObject failsound;
    [SerializeField] Ads adsManager;

    // configuration
    AudioSource wallHitRed;
    AudioSource wallHitBlue;
    Animator myAnimator;
    ArrowAnimation arrowAnimation;
    Action onSuccess;

    int currentMoves;
   
    bool win = false;
    string StopBlinker = "StopBlinker";
    
    

    void Awake()
    {
        _instance = this;
        
    }
    void Start()
    {
        gameOver.SetActive(false);
        failsound.SetActive(false);
        wallHitBlue = GetComponent<AudioSource>();
        wallHitRed = GetComponent<AudioSource>();
        movesLeft = totalMoves;
        currentMoves = movesLeft;
        SwipeCountsText.text = "Move: " + movesLeft.ToString();
        myAnimator = GetComponent<Animator>();
        gameParticle.SetActive(true);
        arrowAnimation = GetComponent<ArrowAnimation>();
        
    }
    void PlayEffectSound()
    {
        failsound.SetActive(true);
    }
  
    
    public void RewardPlayer(int playerMovesReward)
    {
        if(movesLeft == 0)
        {
            movesLeft = playerMovesReward;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {

        SwipeCountsText.text = " Move: " + movesLeft;//onverts the UI texts element to string
        currentMoves = movesLeft;
        if (win) return;

        if (movesLeft == 0 && !win)
        {
           GameOver(); // calls the gameover function when move is 0 and win is false.
           myAnimator.SetTrigger(StopBlinker);
        }

        if (movesLeft <= 5)
        {
            myAnimator.SetTrigger("SetBlinker"); // play animation if moves is <= 5 normal blink speed
        }
        if(movesLeft <= 3)
        {
            myAnimator.SetTrigger("FastBlinker"); // set the blinker even faster after move <= 3.
        }
        
        
    }

    public  void StopAnimation() // stops the moves animation either lose or win
    {
        myAnimator.SetTrigger(StopBlinker);
        if (!arrowAnimation) return;
        arrowAnimation.DeactivateArrowImage();
    }

    public void SetGameParticle() //sets the game particle true after win
    {
        gameParticle.SetActive(true);
    }

    
    void GameOver()
    {
        PlayEffectSound();
        if (!win) // if win is not true
        {
            StartCoroutine(DelayGameOver());
        }

        else
        {
            gameOver.SetActive(false);
        }

        DisablePlayerControls(); // disable character controls
        DisableYellowJoiner(); // Disable spectres control

        // play ads
    }

    private IEnumerator DelayGameOver() // delays the game over screen for a given amount of time.
    {
        yield return new WaitForSeconds(timeToDisplayGameOver); // delays the game over screen for a given amount of time.
        gameOver.SetActive(true); // set the game over to true if win is false
        StopAnimation(); // stops the moves animation on game over.
        win = false;
     //   Time.timeScale = 0;


    }
   
    public void DeactivateGameOverScreen() // called in the goal scripts, deactivate the game over screen if player win is true and move is 0
    {

        gameOver.SetActive(false);
     /*   if (movesLeft == 0 && win == true)
        {
           gameOver.SetActive(false);
        }
        else
        {
            return;
        }
     */
        // deactivates the game over screen, if player wins and move is "0"


    }

    void DisableYellowJoiner()
    {
        var YellowPlayer = FindObjectsOfType<YellowJoiner>(); // finds the current player script and disables them on Game over
        foreach(YellowJoiner yellowJoiner in YellowPlayer)
        {
            yellowJoiner.enabled = false;
            
        }
    }

    void DisablePlayerControls()
    {
        var player = FindObjectsOfType<PlayerController>(); //circles both player script and disables them on game over
        foreach(PlayerController controller in player)
        {
            controller.enabled = false;
        }
    }
    
    public void StopCount()
    {
        movesLeft++; // return player moves on wall contact
    }
    public void JoinStopCountAtWall()
    {
     
        movesLeft = currentMoves; // returns player moves on wall contact, if joined is true
    }

    public void PlayWallHit()
    {
        wallHitBlue.Play(); // plays wall hit sound for blue player
        wallHitRed.Play(); // plays wall hit sound for red player
    }

   
}
