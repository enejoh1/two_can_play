using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownTime : MonoBehaviour
{
    
    public TextMeshProUGUI countDown;
    public float currentTime;
    public float startingTime = 10;
    public float secs = 1;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       
        currentTime -= secs * Time.deltaTime;
        countDown.text = currentTime.ToString("0");
        
        if(currentTime <= 0)
        {
            currentTime = 0;
     //       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        countDown.color = Color.black;
        if (currentTime <= 5)
        {
            countDown.color = Color.blue;
     
            if (timer >= .2)
            {
                GetComponent<TextMeshProUGUI>().enabled = true;
            }
            if (timer >= 1)
            {
                GetComponent<TextMeshProUGUI>().enabled = false;
                timer = 0;
            }
        }

    }

}
