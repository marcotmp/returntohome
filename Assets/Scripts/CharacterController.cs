using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public Vector2 velocity;
    public float speed = 5;
    public float jumpVelocity = 10;
    public float reducedJumpVelocity = 3f;
    public float downOffset = 0.7f;
    public bool isGrounded = false;

    [SerializeField] private SpriteRenderer sprite;
    
    private Vector2 start;
    private Vector2 end;

    private Rigidbody2D rigidbody;

    private bool jumpButton;
    private bool isJumping = false;
    private float shootCoolDown = 0;

    private bool isActive;
    public float xSize = 0.5f;
    public LayerMask whatIsGround;

    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        jumpButton = Input.GetButton("Jump");
        var h = Input.GetAxis("Horizontal");
        
        if (h > 0)
            Flip(true);
        else if (h < 0)
            Flip(false);

        velocity.x = h * speed;

        velocity.y = rigidbody.velocity.y;

        if (velocity.y < 0 && rigidbody.gravityScale == 1)
            rigidbody.gravityScale = 3;

        if (Mathf.Abs(velocity.y) > 16)
            velocity.y = velocity.y>0?1:-1 * 16;

        if (!isJumping) // idle state?
        {
            if (jumpButton)
            {
                rigidbody.gravityScale = 3;
                velocity.y = jumpVelocity;
                isJumping = true;
            }
        }
        else // jump state
        {
            if (!jumpButton)
            {
                velocity.y = Mathf.Min(velocity.y, reducedJumpVelocity);
            }
        }
        
        rigidbody.velocity = velocity;

        CheckCollisions();

        if (isGrounded)
        {
            isJumping = false;
        }
    }

    private void Flip(bool right)
    {
        sprite.flipX = !right;
    }

    private void CheckCollisions()
    {
        start = new Vector2(
            transform.position.x - xSize,
            transform.position.y - downOffset
            );

        end = new Vector2(
            transform.position.x + xSize,
            transform.position.y - downOffset
        );

        RaycastHit2D[] hits = Physics2D.LinecastAll(start, end, whatIsGround);

        if (hits.Length > 0)
        {
            if (rigidbody.velocity.y <= 0)
                isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(start, end);
        //Gizmos.DrawLine(new Vector2(rect.xMax, rect.yMin), new Vector2(rect.xMax, rect.yMax));
        //Gizmos.DrawLine(new Vector2(rect.xMin, rect.yMax), new Vector2(rect.xMin, rect.yMin));
        //Gizmos.DrawLine(new Vector2(rect.xMax, rect.yMax), new Vector2(rect.xMin, rect.yMax));
        //Gizmos.DrawSphere(transform.position, 0.1f);
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void Activate(bool value)
    {
        gameObject.SetActive(value);
        isActive = value;
    }
}
