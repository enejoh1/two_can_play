using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationBubble : MonoBehaviour
{
    [SerializeField] Animator myAnimator;
    [SerializeField] AnimationCurve myCurve;

    private void Start()
    {
        myAnimator = this.gameObject.GetComponent<Animator>();
       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAnimator.SetTrigger("deactivate");
        }
    }

    public void DeactivateBubble()
    {
        myAnimator.SetTrigger("deactivate");
           
    }
    
}
