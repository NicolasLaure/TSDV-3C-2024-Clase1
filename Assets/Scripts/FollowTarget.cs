using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float followSpeed;
    [SerializeField] private Quaternion targetRotation;

    private void Start()
    {
        FixCameraRotation();
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.TransformPoint(offset), Time.deltaTime * followSpeed);

        targetRotation = target.rotation * Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        if (transform.rotation != targetRotation)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void FixCameraRotation()
    {
        targetRotation = target.rotation * Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
    }
}
