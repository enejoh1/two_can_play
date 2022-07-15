using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTestUpDown : MonoBehaviour
{
    public SwipeUpDown swipeControls;
    public Transform player;
    private Vector3 desiredPosition;

    private void Start()
    {
        desiredPosition = player.position;
    }

    private void Update()
    {
        if (swipeControls.SwipeUp)
            desiredPosition += Vector3.up;

        if (swipeControls.SwipeDown)
            desiredPosition += Vector3.down;

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 15f * Time.deltaTime);

        if (swipeControls.Tap)
            Debug.Log("Tap");
    }

}
