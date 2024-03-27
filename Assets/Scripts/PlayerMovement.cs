using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Quaternion targetRotation;
    private Rigidbody rb;

    public event EventHandler CharacterMove;
    public event EventHandler CharacterStop;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //if (transform.rotation != targetRotation)
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        rb.AddForce(dir * speed, ForceMode.Acceleration);
    }
    public void Move(Vector2 newDir)
    {
        dir = Camera.main.transform.TransformDirection(new Vector3(newDir.x, 0, newDir.y));
        if (newDir == Vector2.zero)
            CharacterStop?.Invoke(this, EventArgs.Empty);
        else
            CharacterMove?.Invoke(this, EventArgs.Empty);
    }
    public void Rotate()
    {

    }
}
