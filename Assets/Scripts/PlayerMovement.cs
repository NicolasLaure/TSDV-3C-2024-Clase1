using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 dir;
    [SerializeField] private float speed;
    private Transform modelTransform;

    private void Start()
    {
        modelTransform = transform.Find("model");
    }
    void Update()
    {
        modelTransform.transform.forward = dir;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void Move(Vector2 newDir)
    {
        dir = new Vector3(newDir.x, 0, newDir.y);
    }
}
