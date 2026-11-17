using UnityEngine;
using System;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Collider2D pipeCollider;



    private void Awake()
    {
        pipeCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }

    
    
}
