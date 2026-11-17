using UnityEngine;
using System;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool interactable = true;
    [SerializeField] private float jumpForce = 2f;
    public event Action OnGameOver;
    public event Action OnPipePassed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {           
        if(interactable && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rb.linearVelocity.y * jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("Loser");
            OnGameOver?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) OnPipePassed?.Invoke();
    }

}
