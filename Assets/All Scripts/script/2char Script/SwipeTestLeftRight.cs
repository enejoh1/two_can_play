using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTestLeftRight : MonoBehaviour
{
    public SwipeLeftRight swipeControls;
    public Transform player;
    private Vector3 desiredPosition;

    private void Start()
    {
        desiredPosition = player.position;
    }

    private void Update()
    {
        if (swipeControls.SwipeLeft)
            desiredPosition += Vector3.left;

        if (swipeControls.SwipeRight)
            desiredPosition += Vector3.right;

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 15f * Time.deltaTime);

        if (swipeControls.Tap)
            Debug.Log("Tap");
    }

}
