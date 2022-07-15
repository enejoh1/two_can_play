using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTextController : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] int LevelText;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level: " + LevelText.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        levelText.text = "Level: " + LevelText.ToString();
    }
}
