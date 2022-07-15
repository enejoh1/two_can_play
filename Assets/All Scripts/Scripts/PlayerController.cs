using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] RayCastDataProvider CurrentRaycast;
    public Swipe Swipecontrol;
    public PlayerType CurrentPlayerType;
    public float JumpValue;
    
    AudioSource moveBlueSound;
    AudioSource movesRedSound;
   
    public enum PlayerType
    {
        Red_Horizontal, Blue_Vertical
    }
    void Start()
    {
        moveBlueSound = GetComponent<AudioSource>();
        movesRedSound = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {
        Move(TakeInput());
        
        
    }

   
    public int TakeInput()
    {
        switch (CurrentPlayerType)
        {
            case PlayerType.Red_Horizontal:

                
                if (Input.GetKeyDown(KeyCode.RightArrow) || Swipecontrol.SwipeRight)
                {
                    SwipeCounter._instance.Update();
                    PlayRedSound();
                    SwipeCounter._instance.movesLeft -= 1;
                    return 1;
                }
                    
                  
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Swipecontrol.SwipeLeft)
                {
                    SwipeCounter._instance.Update();
                    PlayRedSound();
                    SwipeCounter._instance.movesLeft -= 1;
                    return -1;
                }
                   
                break;
            case PlayerType.Blue_Vertical:
                if (Input.GetKeyDown(KeyCode.UpArrow)  || Swipecontrol.SwipeUp)
                {
                    PlayBlueSound();
                    SwipeCounter._instance.Update();
                    SwipeCounter._instance.movesLeft -= 1;
                    return 1;
                }
                   
                else if (Input.GetKeyDown(KeyCode.DownArrow) || Swipecontrol.SwipeDown)
                {
                    SwipeCounter._instance.Update();
                    PlayBlueSound();
                    SwipeCounter._instance.movesLeft -= 1;
                    return -1;
                }
                    
                break;
        }
        return 0;
    }

    void PlayBlueSound()
    {
        moveBlueSound.Play();
    }

    void PlayRedSound()
    {
        movesRedSound.Play();
    }


    void Move(int Direction)
    {
        if (Direction == 0)
            return;
        lock (this)
        {
            int IndexOfDirection = (Direction == 1) ? 0 : 1;
            List<int> IndexsToCheckForWall = new List<int>();
            List<GameObject> ObjectsToMove = null;
            bool EndAtWall = false;
            bool Joined = false;
            
            switch (CurrentPlayerType)
            {
                case PlayerType.Red_Horizontal: //CurrentRaycast 1 is right, 3 is left
                    IndexsToCheckForWall.Add((int)SidesIndexs.Right); // Index for Right side
                    IndexsToCheckForWall.Add((int)SidesIndexs.Left);// Index for Left side
                    break;
                case PlayerType.Blue_Vertical:
                    IndexsToCheckForWall.Add((int)SidesIndexs.Up); // Index for Up side
                    IndexsToCheckForWall.Add((int)SidesIndexs.Down);// Index for Down side
                    break;
            }

            if (!YellowJoiner.YellowJoinerIsOn)
                ObjectsToMove = CheckIfMovementPossible(CurrentRaycast, ref EndAtWall, IndexsToCheckForWall[IndexOfDirection]);
            else
            {
                List<RayCastDataProvider> Checked = new List<RayCastDataProvider>(); // Used in the recursive funtion only
                ObjectsToMove = CheckIfMovementPossibleIfJoined(CurrentRaycast, ref EndAtWall, ref Checked, ref Joined, IndexsToCheckForWall[IndexOfDirection]);
                if (!Joined)
                    ObjectsToMove = CheckIfMovementPossible(CurrentRaycast, ref EndAtWall, IndexsToCheckForWall[IndexOfDirection]);
            }

            if (!EndAtWall)
            {
                for (int i = 0; i < ObjectsToMove.Count; i++)
                {
                    Vector3 MyPosition = ObjectsToMove[i].transform.position;
                    switch (CurrentPlayerType)
                    {
                        case PlayerType.Red_Horizontal:
                            MyPosition.x += Direction * JumpValue;
                            break;
                        case PlayerType.Blue_Vertical:
                            MyPosition.y += Direction * JumpValue;
                            break;

                    }

                    ObjectsToMove[i].transform.position = MyPosition;
                }
            }
        }
    }

   List<GameObject> CheckIfMovementPossible(RayCastDataProvider StartPoint, ref bool EndAtWall, int IndexToCheck)
    {
        List<GameObject> ObjectsToMove = new List<GameObject>();
        ObjectsToMove.Add(gameObject);
        RayCastDataProvider Next = StartPoint;
        List<RayCastDataProvider> Checked = new List<RayCastDataProvider>();
        EndAtWall = false;
        while (Next)
        {
            if (Checked.Contains(Next))
                break;
            Checked.Add(Next);
            if (Next[IndexToCheck])
            {
                if (Next[IndexToCheck].CompareTag("Wall"))
                {
                    EndAtWall = true;
                    if (EndAtWall)
                    {
                        moveBlueSound.Stop();
                        movesRedSound.Stop();
                        SwipeCounter._instance.StopCount();
                    }
                    if(EndAtWall)
                    {
                        SwipeCounter._instance.PlayWallHit();
                    }
                   


                    break;
                }

                else if (Next[IndexToCheck].CompareTag("Teleport"))
                {
                  
                    Debug.Log("Teleport");
                }
                else
                    ObjectsToMove.Add(Next[IndexToCheck]);
                Next = Next[IndexToCheck].GetComponent<RayCastDataProvider>();
            }
            else
            {
                break;
            }
        }
        return ObjectsToMove;
   }
    

   

   
    List<GameObject> CheckIfMovementPossibleIfJoined(RayCastDataProvider StartPoint, ref bool EndAtWall, ref List<RayCastDataProvider> Checked, ref bool Joined, int IndexsToCheckForWall)
    {
        if (Checked.Contains(StartPoint))
        {
            return null;
        }
        Checked.Add(StartPoint);
        if (StartPoint.gameObject.CompareTag("YellowJoiner"))
            Joined = true;
        

        List<GameObject> ObjectsToMove = new List<GameObject>();
        ObjectsToMove.Add(StartPoint.gameObject);

        for (int i = 0; i < 4; i++)
        {
            if (StartPoint[i] && StartPoint[i].GetComponent<RayCastDataProvider>())
            {
                List<GameObject> ReturnValue = CheckIfMovementPossibleIfJoined(StartPoint[i].GetComponent<RayCastDataProvider>(), ref EndAtWall, ref Checked, ref Joined, IndexsToCheckForWall);
                if (ReturnValue != null)
                    ObjectsToMove = ObjectsToMove.Union(ReturnValue).ToList();
            }
            else if (StartPoint[i] && StartPoint[i].CompareTag("Wall") && IndexsToCheckForWall == i)
                EndAtWall = true;
            if (EndAtWall == true)
            {
                movesRedSound.Stop();
                moveBlueSound.Stop();
                SwipeCounter._instance.JoinStopCountAtWall();
            }
            if (EndAtWall)
            {
                SwipeCounter._instance.PlayWallHit();
                
            }
           
        }
        return ObjectsToMove;
    }
    
    
}
