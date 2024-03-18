using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10;
    private Vector3 _desiredDirection;
    public float rotationSpeed = 15;

    public void Move(Vector3 direction)
    {
        _desiredDirection = direction;
    }


    private void Update()
    {
        transform.position += _desiredDirection * (speed * Time.deltaTime);

        float angle = Vector3.SignedAngle(transform.forward, _desiredDirection, transform.up);

        transform.Rotate(transform.up, angle * Time.deltaTime * rotationSpeed);
    }
}
