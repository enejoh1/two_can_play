using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangerOnJoin : MonoBehaviour
{
    public Sprite JoindedSprite;
    public Sprite NonJoinedSprite;

    public bool Joined;
    
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Joined = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        spriteRenderer.sprite = (Joined)? JoindedSprite:NonJoinedSprite;
    }
}
