using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchesText : MonoBehaviour
{
    public Transform branchesText;
    public GameObject branchesTextPrefab;
    public Transform Branches;
    public Transform Player;

    void Start()
    {
        HideText();
    }
    void OnDisable()
    {
        
        branchesTextPrefab.gameObject.SetActive(true);

        float delay = 7f;
        Invoke("HideText", delay);
        branchesText.LookAt(branchesText.position + Player.transform.rotation * Vector3.forward,
                         Player.transform.rotation * Vector3.up);
    }
    void HideText()
    {
        branchesText.gameObject.SetActive(false);
    }
}
