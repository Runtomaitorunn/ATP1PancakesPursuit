using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowAway : MonoBehaviour
{
    public Rigidbody rigidbody;
    private float force1;
    private float force2;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody  = GetComponent<Rigidbody>();
        float force1 = Random.Range(0f, 10f);
        float force2 = Random.Range(0f, 10f);
        Vector3 throwForce = new Vector3(force1, 3, force2);
        

        rigidbody.AddForce(throwForce, ForceMode.Impulse);
        
    }

}
