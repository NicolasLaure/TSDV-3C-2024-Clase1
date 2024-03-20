using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        if (dir != Vector3.zero)
            transform.forward = Vector3.Lerp(transform.forward, dir, rotationSpeed * Time.deltaTime);
    }

    public void Move(Vector2 newDir)
    {
        dir = new Vector3(newDir.x, 0, newDir.y);
    }
}
