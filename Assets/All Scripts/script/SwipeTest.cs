﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;

    private void Update()
    {
        if (swipeControls.SwipeLeft)
            desiredPosition += Vector3.left;

        if (swipeControls.SwipeRight)
            desiredPosition += Vector3.right;

        if (swipeControls.SwipeUp)
            desiredPosition += Vector3.up;

        if (swipeControls.SwipeDown)
            desiredPosition += Vector3.down;

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 8f * Time.deltaTime);

        if(swipeControls.Tap)
            Debug.Log("Tap");
    }

}
