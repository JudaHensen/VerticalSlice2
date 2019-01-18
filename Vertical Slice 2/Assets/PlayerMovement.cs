using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float minSpeed = 4f * 8;
    private float maxSpeed = 13f * 8;
    private float acceleration = 20f * 6;
    private float speed;

    private float jumpCoolDown;
    private float dashCoolDown;
    private float yPos;
    private float airTime;
    private float dashTime;
    private float maxJumpHeight = 3f;

    private float horizontalMove;
    
    private bool isJumping;
    private bool isDashing;

    private Rigidbody2D rb;

    private void Start()
    {
        isJumping = false;
        speed = 1f;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        //if (jumpCoolDown > 0)
        //{
        //    jumpCoolDown -= Time.deltaTime;
        //}

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
    }
    
    public void MoveLeft()
    {


        if (speed < maxSpeed)
        {
            speed += acceleration;
        }

        rb.position -= new Vector2((speed * Time.deltaTime) / 100, -0.001f);

        //rb.AddForce((Vector2.left * speed) * Time.deltaTime, ForceMode2D.Force);
    }

    public void MoveRight()
    {


        if (speed < maxSpeed)
        {
            speed += acceleration;
        }

        rb.position += new Vector2((speed * Time.deltaTime) / 100, 0.001f);

        //rb.AddForce((Vector2.right * speed) * Time.deltaTime, ForceMode2D.Force);
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
        if (jumpCoolDown <= 0)
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
                //rb.AddForce(new Vector2(0, maxJumpHeight), ForceMode2D.Impulse);
            }
            //else
            //{
            //    jumpCoolDown = 2f;
            //}
            
            //if (yPos - transform.position.y > maxJumpHeight)
            //{
            //    jumpCoolDown = 2f;
            //}
        }
    }

    public void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            speed += 100;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
    }

}