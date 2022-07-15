using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class TimeControl : MonoBehaviour
{
    public GameObject RedPlayer, BluePlayer;
    public bool isReversing;
    public Button undoButton;

    public ArrayList playerPosRed;
    public ArrayList playerPosBlue;
    
    

    void Start()
    {
        playerPosRed = new ArrayList();
        playerPosBlue = new ArrayList();
    }
    public void FixedUpdate()
    {
        if (isReversing == false)
        {
            playerPosRed.Add(RedPlayer.transform.position);
           
        }
        else
        {
            RedPlayer.transform.position = (Vector3)playerPosRed[playerPosRed.Count - 1];
         
            playerPosRed.RemoveAt(playerPosRed.Count - 1);
        }

        if (isReversing != true)
        {
            playerPosBlue.Add(BluePlayer.transform.position);
            
        }
        else
        {
            BluePlayer.transform.position = (Vector3)playerPosBlue[playerPosRed.Count - 1];
            playerPosBlue.RemoveAt(playerPosRed.Count - 1);
        }
    }
    public void OnClickUi()
    {
        reverse();
        Debug.Log("Button clicked");
        
    }

    public void Update()
    {
        UndoMove();
        
    }

    public void reverse()
    {
        if (undoButton )
        {
            isReversing = true;
        }

        else 
        {
            isReversing = false; ;
        }

    }


    public void UndoMove()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            isReversing = true;
        }
        else
        {
            isReversing = false;
        }
    }


}
