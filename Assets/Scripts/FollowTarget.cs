using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float followSpeed;
    
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.TransformPoint(offset), Time.deltaTime * followSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation * Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0), rotationSpeed * Time.deltaTime);
    }
}
