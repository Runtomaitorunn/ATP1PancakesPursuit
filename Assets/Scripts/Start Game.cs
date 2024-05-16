using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartingGame();
        }
        
    }
    public void StartingGame()
    {
        SceneManager.LoadScene("Main Game"); // 加载主游戏场景
    }

}
