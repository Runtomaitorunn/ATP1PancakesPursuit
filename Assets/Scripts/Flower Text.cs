using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerText : MonoBehaviour
{
    public Transform flowerText;
    public GameObject flowerTextPrefab;
    public Transform Flower;
    public Transform Player;
    public ParticleSystem flowerParticle;

    void Start()
    {
        HideText();
    }
    void OnDisable()
    {
        flowerTextPrefab.gameObject.SetActive(true);

        float delay = 7f;
        Invoke("HideText", delay);
        flowerText.LookAt(flowerText.position + Player.transform.rotation * Vector3.forward,
                         Player.transform.rotation * Vector3.up);
        SetParticle();
    }

    void HideText()
    {
            flowerText.gameObject.SetActive(false);
    }
    void SetParticle()
    {
        flowerParticle.gameObject.SetActive(true);


    }
}
