using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIscaler : MonoBehaviour
{

    public float resX;
    public float resY;
    private CanvasScaler can;

    // Start is called before the first frame update
    void Start()
    {
        can = GetComponent<CanvasScaler>();
        SetInfo();
        
    }

    void SetInfo()
    {
        resX = Screen.currentResolution.width;
        resY = Screen.currentResolution.height;

        can.referenceResolution = new Vector2(resX, resY);
    }

  
}
