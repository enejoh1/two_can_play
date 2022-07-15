using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class YellowJoiner : MonoBehaviour
{
    public static bool YellowJoinerIsOn; 
    List<GameObject> ObjectsToJoin;
    RayCastDataProvider CurrentRayCastData;
    
    AudioSource joinSound;

    // Start is called before the first frame update
    void Start()
    {
        joinSound = GetComponent<AudioSource>();
        YellowJoinerIsOn = false;
        CurrentRayCastData = GetComponent<RayCastDataProvider>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            joinSound.Play();
            YellowJoinerIsOn = !YellowJoinerIsOn;
   
        }
        SetJoinedValue(ref ObjectsToJoin,false);

        if(YellowJoinerIsOn)
        {
            List<RayCastDataProvider> Checked = new List<RayCastDataProvider>();
            ObjectsToJoin = CheckIfJoined(CurrentRayCastData,ref Checked);
        }
        else
        {
            if (ObjectsToJoin != null)
                ObjectsToJoin.Clear();
        }
        SetJoinedValue(ref ObjectsToJoin,true);
    }

    void SetJoinedValue(ref List<GameObject> ObjectsToJoin,bool Value)
    {
        if(ObjectsToJoin != null)
        for (int i = 0; i < ObjectsToJoin.Count; i++)
        {
            SpriteChangerOnJoin current = ObjectsToJoin[i].GetComponent<SpriteChangerOnJoin>();
            if(current)
                current.Joined = Value;
        }

    }

    private void OnMouseDown()
    {
        joinSound.Play();
        YellowJoinerIsOn = !YellowJoinerIsOn;

    }

    List<GameObject> CheckIfJoined(RayCastDataProvider StartPoint,ref List<RayCastDataProvider> Checked)
    {
        if(Checked.Contains(StartPoint))
        {
            return null;
        }
        Checked.Add(StartPoint);

        List<GameObject> ObjectsToMove = new List<GameObject>();
        ObjectsToMove.Add(StartPoint.gameObject);

        for(int i = 0;i < 4;i++)
        {
            if(StartPoint[i] && StartPoint[i].GetComponent<RayCastDataProvider>())
            {
                List<GameObject> ReturnValue = CheckIfJoined(StartPoint[i].GetComponent<RayCastDataProvider>(),ref Checked);
                if(ReturnValue != null)
                    ObjectsToMove = ObjectsToMove.Union(ReturnValue).ToList();
            }
        }
        return ObjectsToMove;
    }
    



}
