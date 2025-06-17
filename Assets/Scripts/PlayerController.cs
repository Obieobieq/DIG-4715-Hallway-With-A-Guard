using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    public float speed = 2.0f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        frontNBack();
        leftNRight();        
    }

    void frontNBack()
    {
        var forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }

    void leftNRight()
    {
        var right = transform.TransformDirection(Vector3.right);
        float turnSpeed = speed * Input.GetAxis("Horizontal");
        controller.SimpleMove(right * turnSpeed);
    }
}
