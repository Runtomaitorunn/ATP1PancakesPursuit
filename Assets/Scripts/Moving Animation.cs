using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAnimation : MonoBehaviour
{
    private Animator animator;
    private Vector3 movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.GetComponent<Animator>().speed = 18f;
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        
        if (movement.magnitude > 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
}
