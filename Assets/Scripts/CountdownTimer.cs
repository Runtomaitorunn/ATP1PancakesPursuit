using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{  
    public TextMeshProUGUI countdownText;  
    [HideInInspector]  
    public float remainingTime;  
    private bool isTimerRunning = false;
    public bool isGameOver = false;

    [Header("GameOverWindow")]
    public Image gameoverPanel;
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI joyValue;
    public Slider slider;
    public float panelFade = 2.0f;
    public float textDisplay = 3.0f;
    public Button reloadButton;
       
    void Start()
    {
        // Set countdown time           
        remainingTime = 180f;            
        isTimerRunning = true;    
    }
       
    void Update()        
    {           
        if (isTimerRunning)            
        {                         
            remainingTime -= Time.deltaTime;              
            if (remainingTime<= 30)              
            {              
                countdownText.color = Color.red;
            }               
            // Stop at 0:00             
            if (remainingTime <= 0&&isGameOver == false )        
            {                   
                isTimerRunning = false;                  
                remainingTime = 0;
                countdownText.text = "00:00";
                GameOver();              
            }               
            else               
            {                             
                string minutes = ((int)remainingTime / 60).ToString("00");                
                string seconds = (remainingTime % 60).ToString("00");               
                countdownText.text = minutes + ":" + seconds;               
            }           
        }      
    }

     
    public void StopTimer()     
    {       
        isTimerRunning = false;     
    }

    public void GameOver()
    {
        isGameOver = true;
        joyValue.enabled = false;
        slider.enabled = false;
        StartCoroutine(FadeInCoroutine());
        IEnumerator FadeInCoroutine()
        {
            float Timer = 0;
            //Color change every frame for 2 sec
            while (Timer <= panelFade)
            {
                gameoverPanel.color = new Color(0, 0, 0, Timer / panelFade);
                Timer += Time.deltaTime;
                yield return null;
            }
            gameoverText.gameObject.SetActive(true);
            Timer = 0;
            while (Timer <= textDisplay)
            {
                gameoverText.enabled = true;
                Timer += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(7);

            gameoverText.enabled = false;
            SceneManager.LoadScene("Game Start");
        }
    }   
}
