using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class JoyValue : MonoBehaviour
{
    public Slider scoreSlider; 
    private int score = 0; 
    private int maxScore = 100; 

    private CountdownTimer countdownTimer;
    private PuppyFetchUniversal puppyFetchUniversal;
    private float remainingTime;
    private bool isGameOver;
    public GameObject owner;
    public GameObject canvas;


    void Start()
    {
        scoreSlider.minValue = 0;
        scoreSlider.maxValue = maxScore;
        scoreSlider.value = 0;
        countdownTimer = canvas.GetComponent<CountdownTimer>();
        puppyFetchUniversal = owner.GetComponent<PuppyFetchUniversal>();      
        puppyFetchUniversal.objectReceived.AddListener(AddScore);
    }

    void Update()
    {
        if (countdownTimer != null&& puppyFetchUniversal!= null )
        {
            remainingTime = countdownTimer.remainingTime;
            isGameOver = countdownTimer.isGameOver;

        }

    }

    public void AddScore()
    {
            score += 12 ;
            score = Mathf.Clamp(score, 0, maxScore);
            scoreSlider.value = score;
        if (remainingTime > 0 && scoreSlider.value>= maxScore&& isGameOver==false )
        {
            countdownTimer.GameOver();
        }
    }
    private void OnDestroy()
    {

        if (puppyFetchUniversal != null)
        {
            puppyFetchUniversal.objectReceived.RemoveListener(AddScore);
        }
    }
}
