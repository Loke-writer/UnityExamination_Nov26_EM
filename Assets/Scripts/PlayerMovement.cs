using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool useSliding;
    [SerializeField, Min(0.1f)] private float acceleration = 12f;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector2 moveDirection;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
        if (Mathf.Abs(moveDirection.x) > 0.01f)
        {
            spriteRenderer.flipX = moveDirection.x < 0f;
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = moveDirection * moveSpeed;

        if (useSliding)
        {
            body.linearVelocity = Vector2.MoveTowards(
                body.linearVelocity,
                targetVelocity,
                acceleration * Time.fixedDeltaTime);
        }
        else
        {
            body.linearVelocity = targetVelocity;
        }
    }
    private void Update()
    {
        if (animator != null)
            animator.SetBool("IsMoving", body.linearVelocity.sqrMagnitude > 0.01f);
    }
}