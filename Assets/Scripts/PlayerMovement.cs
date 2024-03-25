using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody rb;

    public event EventHandler CharacterMove;
    public event EventHandler CharacterStop;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //if (dir != Vector3.zero)
        //    transform.forward = Vector3.Lerp(transform.forward, dir, rotationSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        rb.AddRelativeForce(dir * speed, ForceMode.Acceleration);
    }
    public void Move(Vector2 newDir)
    {
        dir = new Vector3(newDir.x, 0, newDir.y);
        if (newDir == Vector2.zero)
            CharacterStop?.Invoke(this, EventArgs.Empty);
        else
            CharacterMove?.Invoke(this, EventArgs.Empty);
    }
}
