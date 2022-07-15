using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackround : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 5f;

    Material myMaterial;
    Vector2 offset;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, scrollSpeed);
    }

    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
