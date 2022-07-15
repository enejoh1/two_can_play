using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationTextControl : MonoBehaviour
{
    [SerializeField] Animator myAnimator;



    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAnimator.SetTrigger("deactivate");
        }
    }

    public void InformationText()
    {
        myAnimator.SetTrigger("deactivate");

    }
}
