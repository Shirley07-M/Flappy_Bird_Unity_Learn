using UnityEngine;
using System;
using System.Collections;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool interactable = true;
    [SerializeField] private float jumpForce = 2f;
    private Animator animator;
    public event Action OnGameOver;
    public event Action OnPipePassed;
    private static readonly int DeadAnimationHash = Animator.StringToHash("onDead");
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool(DeadAnimationHash, false);
    }
    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.Space))
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
            interactable = false;
            StartCoroutine(TriggerDeadAnimation());        
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) OnPipePassed?.Invoke();

    }
    private IEnumerator TriggerDeadAnimation()
    {
        animator.SetBool(DeadAnimationHash, true); 
        yield return new WaitForSeconds(0.5f);
        OnGameOver?.Invoke(); 
    }

}
