using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] GameObject teleportParticle;
    [SerializeField] float destroyParticle = 1.5f;

    public static Teleport _instance;
    public GameObject PortalA, PortalB;
    
    public bool CanTeleport = true;
    public int count;
    public string obj1;
    
    AudioSource myAudioSource;
    private void Awake()
    {
        _instance = this;
        myAudioSource = GetComponent<AudioSource>();
       
       
    }
 

    // Update is called once per frame
    void Update()
    {
        if (count <= 0 && TeleportB._instance.count<=0)
        {
          
            CanTeleport = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        StartCoroutine(wait());

        if (collision.name != obj1 && TeleportB._instance.count<=0)
        {
            CanTeleport = true;
            if (CanTeleport)
                InstantiateParticle();
                myAudioSource.Play();

          

        }
        if (CanTeleport)
        {
            collision.gameObject.transform.position = PortalB.transform.position;
            CanTeleport = false;
            myAudioSource.Play();
            TeleportB._instance.CanTeleport = false;
            InstantiateParticle();


        }

    }
    void InstantiateParticle()
    {
      GameObject particle =  Instantiate(teleportParticle, transform.position, Quaternion.identity);
        Destroy(particle, destroyParticle); ;
    }


    IEnumerator wait()
    {
        Invoke("Update", .5f);
        yield return new WaitForSeconds(1);
        Debug.Log("wait");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    CanTeleport = false;
    //    TeleportB._instance.CanTeleport = false;
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        TeleportB._instance.obj1 = collision.name;
        obj1 = collision.name;
        count--;
       
        if (CanTeleport == true)
            InstantiateParticle();
        else if(CanTeleport == true)
        {
            myAudioSource.Play();
        }  

    }

}
