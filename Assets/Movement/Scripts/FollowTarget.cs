using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3 (0.0f, 1.5f, -5.0f);
    public float rotationSpeed = 2.0f;
    public float followSppeed = 2.0f;


    private void LateUpdate()
    {
        var rotatedOffset = target.rotation * offset;
        var offsetEmulatingTransformPoint = target.position + rotatedOffset;

        var offsetBasedOnTarget = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, offsetEmulatingTransformPoint, Time.deltaTime * followSppeed);

        var desiredRotation = target.rotation * Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}
