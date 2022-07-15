using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SidesIndexs
{
    Up,Right,Down,Left
}
public class RayCastDataProvider : MonoBehaviour
{
    public List<GameObject> SurroundingObjects;
    public float MaxLookValue;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
       
        SurroundingObjects.Add(null);
        SurroundingObjects.Add(null);
        SurroundingObjects.Add(null);
        SurroundingObjects.Add(null);
        Physics2D.queriesHitTriggers = true;
        
    }

    // Update is called once per frame
    void Update()
    {   
            CheckForRayCast((int)SidesIndexs.Up,Vector3.up);        
            CheckForRayCast((int)SidesIndexs.Right,Vector3.right);        
            CheckForRayCast((int)SidesIndexs.Down,Vector3.down);        
            CheckForRayCast((int)SidesIndexs.Left,Vector3.left);        
    }
    void CheckForRayCast(int index, Vector3 Direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Direction, MaxLookValue);
        if(hit)
        {
            SurroundingObjects[index] = hit.collider.gameObject;
        }
        else
        {
            SurroundingObjects[index] = null;
        }
    }        

    public GameObject this[int i] => this.SurroundingObjects[i];

}
