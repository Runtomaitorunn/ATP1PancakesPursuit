using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuppyMovement : MonoBehaviour
{
    //Script from Youtube THIRD PERSON MOVEMENT in Unity
    public CharacterController controller;
    public Transform cam;

    [Range(0,8)]
    public float speed;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movDir.normalized * speed * Time.deltaTime);
        }
        
    }
}
