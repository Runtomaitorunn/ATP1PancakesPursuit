using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthdayHatText : MonoBehaviour
{
    public Transform birthdayHatText;
    public GameObject birthdayHatTextPrefab;
    public Transform birthdayHat;
    public Transform Player;
    public ParticleSystem hatParticle;

    void Start()
    {
        HideText();
    }
    void OnDisable()
    {
        birthdayHatTextPrefab.gameObject.SetActive(true);
        SetParticle();
        float delay = 10f;
        Invoke("HideText", delay);
        birthdayHatText.LookAt(birthdayHatText.position + Player.transform.rotation * Vector3.forward,
                         Player.transform.rotation * Vector3.up);
    }
    void HideText()
    {
        birthdayHatText.gameObject.SetActive(false);
    }
    void SetParticle()
    {
        hatParticle.gameObject.SetActive(true);


    }
    
}
