using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    [SerializeField] GameObject arrowImages;
    [SerializeField] Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        arrowImages.SetActive(true);

    }

   public void DeactivateArrowImage() // desroys the arrow images on goal called in goal scripts
    {
        StartCoroutine(DelayArrows());
    }
    
    IEnumerator DelayArrows() //
    {
        yield return new WaitForSeconds(1f);
        myAnimator.SetTrigger("WinStop");
       
    }
}
