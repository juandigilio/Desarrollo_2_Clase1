using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 4;
    private Vector3 _desiredDirection;

    public void Move(Vector3 direction)
    {
        _desiredDirection = direction;
    }

    private void Update()
    {
        transform.Translate(_desiredDirection * (speed * Time.deltaTime));
    }
}
