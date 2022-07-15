using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportB : MonoBehaviour
{
    [SerializeField] GameObject teleportParticle;
    [SerializeField] float destroyParticle = 1.5f;


    public static TeleportB _instance;
    public GameObject PortalA, PortalB;
    public bool CanTeleport = true;
    public int count;
    public string obj1;

    AudioSource myAudioSource;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 0 && Teleport._instance.count<=0)
        {
            CanTeleport = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        StartCoroutine(wait());
        if (collision.name != obj1 && Teleport._instance.count <= 0)
        {
            CanTeleport = true;
            if (CanTeleport)
            myAudioSource.Play();
            InstantiateParticle();
          
        }
        
        if (CanTeleport)
        {
            collision.gameObject.transform.position = PortalA.transform.position;
            CanTeleport = false;
            myAudioSource.Play();
            Teleport._instance.CanTeleport = false;
            InstantiateParticle();
          
        }
    }
    void InstantiateParticle()
    {
        var particle = Instantiate(teleportParticle, transform.position, Quaternion.identity);
        Destroy(particle, destroyParticle);
    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {
        //obj1 = collision.name;   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Teleport._instance.obj1 = collision.name;
        obj1 = collision.name;
        count--;
        if (CanTeleport)
            InstantiateParticle();
        else if(CanTeleport == true)
            myAudioSource.Play();
    }
    IEnumerator wait()
    {

        yield return new WaitForSeconds(1);
        Debug.Log("wait");
    }

  
}
