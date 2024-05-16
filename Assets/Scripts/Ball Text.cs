using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallText : MonoBehaviour
{
    public Transform ballText;
    public GameObject ballTextPrefab;
    public Transform ball;
    public Transform Player;
    void Start()
    {
        HideText();
    }
    void OnDisable()
    {
        ballTextPrefab.gameObject.SetActive(true);

        float delay = 7f;
        Invoke("HideText", delay);
        ballText.LookAt(ballText.position + Player.transform.rotation * Vector3.forward,
                         Player.transform.rotation * Vector3.up);
    }
    void HideText()
    {
        ballText.gameObject.SetActive(false);
    }
}
