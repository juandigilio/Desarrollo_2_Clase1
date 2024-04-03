using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float speed = 2;
    [SerializeField] public float acceleration = 2;
    [SerializeField] public float rotationSpeed = 15;
    [SerializeField] private Rigidbody rigiBody;
    [SerializeField] private Vector3 _desiredDirection;

    private bool isIdle;
    private bool isWalking;
    private bool isRuning;

    public float CurrentSpeed
    {
        get
        {
            return _desiredDirection.magnitude * speed;
        }
    }

    public void Move(Vector3 direction)
    {
        _desiredDirection = direction;

       
    }

    private void Reset()
    {
        rigiBody = GetComponent<Rigidbody>();
    }

    private void GetDirection()
    {
        Transform localTransform = transform;

        var camera = Camera.main;
        if (camera != null)
        {
            localTransform = camera.transform;
        }

        _desiredDirection = localTransform.TransformDirection(_desiredDirection);
        _desiredDirection.y = 0;
    }

    private void GetAnimationState()
    {
        if (_desiredDirection == Vector3.zero)
        {
            isIdle = true;
            isWalking = false;
            isRuning = false;
        }
    }

    private void Update()
    {
        GetDirection();

        float angle = Vector3.SignedAngle(transform.forward, _desiredDirection, Vector3.up);

        transform.Rotate(0, angle * (Time.deltaTime * rotationSpeed), 0);
    }

    private void FixedUpdate()
    {
        var currentSpeed = rigiBody.velocity.magnitude;
      
        if (currentSpeed < speed)
        {
            rigiBody.AddForce(_desiredDirection * acceleration, ForceMode.Force);
        }
    }
}
