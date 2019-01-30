using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private static Player player = new Player();
    private PlayerAnimations playerAnim;

    private float minSpeed = player.minSpeed;
    private float maxSpeed = player.maxSpeed;
    private float acceleration = player.acceleration;
    private float maxJumpHeight = player.maxJumpHeight;
    private float speed = player.speed;
    
    private float dashCoolDown = player.dashCoolDown;
    private float airTime = player.airTime;
    private float yPos;

    private float horizontalMove;

    private int state = 0;

    private bool isJumping;
    private bool isDashing;
    private bool isAttacking;

    private Rigidbody2D rb;

    private void Start()
    {
        isJumping = false;
        isAttacking = false;
        playerAnim = GetComponent<PlayerAnimations>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.position += new Vector2(0, 0.004f);
        }

        if (speed <= minSpeed && !isJumping)
        {
            state = 0;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            airTime = 0f;
        }

        if (dashCoolDown > 0)
        {
            dashCoolDown -= Time.deltaTime;
        } else if(isDashing)
        {
            isDashing = false;
        }


        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        playerAnim.SetState(state);
    }
    
    public void MoveLeft()
    {
        if (speed < maxSpeed)
        {
            speed += acceleration;
        }

        state = 1;

        rb.position -= new Vector2((speed * Time.deltaTime) / 100, 0f);
    }

    public void MoveRight()
    {
        if (speed < maxSpeed)
        {
            speed += acceleration;
        }

        state = 1;

        rb.position += new Vector2((speed * Time.deltaTime) / 100, 0f);
    }

    public void SlowDown()
    {
        if (speed > minSpeed && !isDashing)
        {
            speed -= acceleration * 20 * Time.deltaTime;
        }
    }

    public void Jump()
    {
            if (!isJumping)
            {
                airTime = 0.4f;
                yPos = GetHeight();
                isJumping = true;
            }

            airTime -= Time.deltaTime;
   
            if (airTime > 0)
            {
                rb.position += new Vector2(0f, maxJumpHeight * Time.deltaTime);
                state = 3;
            }
        }

    public void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            speed += 100;
            state = 2;
            Invoke("Stop", 0.1f);
        }
    }

    private void Stop()
    {
        speed -= 100;
        dashCoolDown = 1f;
    }

    private float GetHeight()
    {
        return transform.position.y;
    }

    public void Attack()
    {
        gameObject.tag = "Attacking";
        Invoke("ResetTag", 1f);
    }

    void ResetTag()
    {
        
        gameObject.tag = "Player";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDashing && collision.transform.tag == "Enemy")
        {
            CancelInvoke("Stop");
            Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
    }
}