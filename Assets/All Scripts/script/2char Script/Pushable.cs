using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Pushable : MonoBehaviour
{
    private Rigidbody2D body;
    //private Vector2 playerMovement;


    public float moveSpeed = 3;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.constraints = RigidbodyConstraints2D.FreezeRotation;

        tag = "Player";

    }

    /* void Update()
     {

         playerMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

     }

     void FixedUpdate()
     {
         body.MovePosition(body.position + playerMovement * moveSpeed * Time.deltaTime);

     }*/
}