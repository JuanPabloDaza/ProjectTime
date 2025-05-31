using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float horizontalMovement;
    [SerializeField] private float movementSpeed = 8.0f;
    [SerializeField]  private float jumpingPower = 12f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        //Debug.Log(rigidBody.linearVelocity.x);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpingPower);
        }

        //if (Input.GetButtonUp("Jump") && rigidBody.linearVelocity.x > 0f )
        //{
        //        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpingPower * 0.5f);  
        //}

        Flip();
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = new Vector2(horizontalMovement * movementSpeed, rigidBody.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void Flip()
    {
        if(isFacingRight && horizontalMovement < 0f || !isFacingRight && horizontalMovement > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
