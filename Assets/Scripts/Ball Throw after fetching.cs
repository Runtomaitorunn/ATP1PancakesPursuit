using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowafterfetching : MonoBehaviour
{
    public Transform receivePoint;  
    public GameObject ballPrefab;
    private GameObject existedBall;

    void Update()
    {

        GameObject ballRig = GameObject.Find("BallRig");


        if (ballRig == null)
        {
            if (existedBall == null) 
            {
                ballRig = Instantiate(ballPrefab, receivePoint.position, Quaternion.identity);
                existedBall = ballRig;
                ThrowBall(existedBall);
            }
            else
            {
                existedBall = null;
            }

        }

       
    }
    void ThrowBall(GameObject ball)
    {
        Rigidbody rigidbody = ball.GetComponent<Rigidbody>();
        float force1 = Random.Range(0f, 10f);
        float force2 = Random.Range(0f, 10f);
        Vector3 throwForce = new Vector3(force1, 3, force2);
        rigidbody.AddForce(throwForce, ForceMode.Impulse);
    }
}
