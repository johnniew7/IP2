using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 30f;

    [SerializeField] Text timerText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString ("0");

        if (currentTime <= 10)
        {
            timerText.color = Color.red;
        }
        
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
