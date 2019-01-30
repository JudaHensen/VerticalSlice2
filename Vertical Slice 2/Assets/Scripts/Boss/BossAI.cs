using UnityEngine;

public class BossAI : MonoBehaviour
{

    private static Boss boss = new Boss();

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float yPos;

    private float health = boss.health;
    private float speed = boss.moveSpeed;

    private bool isAtMax = false;

    private Vector2 dest;

    private float followRange = 0.9f;
    private float attackRange = 0.6f;
    private float distanceToTarget;
    private bool isAttacking = false;
    private bool isDead = false;
    private bool isHit = false;
    private float hitCoolDown;
    private GameObject player;
    private GameObject target;
    private int state = 0;

    private BossAI bossAi;
    private BossAnimations anim;

    private void Start()
    {
        anim = GetComponent<BossAnimations>();
        transform.position = new Vector2(minX, yPos);
        bossAi = GetComponent<BossAI>();
        dest = new Vector2(maxX, yPos);
        transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            anim.SetState(state);

            player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Attacking");
            }

            distanceToTarget = Vector2.Distance(transform.position, player.transform.position);

            if (player != null && distanceToTarget <= followRange && !isAttacking)
            {
                target = player;
            }
            else
            {
                target = null;
            }

            if (target != null)
            {

                state = 0;

                if (distanceToTarget <= attackRange)
                {
                    Debug.Log("Player Within Range");
                    isAttacking = true;
                    state = 1;
                    Invoke("Attack", 1f);
                    return;
                }

                if (target.transform.position.x < transform.position.x)
                {
                    isAtMax = true;
                    transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
                }
                else
                {
                    isAtMax = false;
                    transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
                }


            }
            else if (!isAttacking)
            {
                state = 0;

                if (transform.position.x > maxX)
                {
                    isAtMax = true;
                    SetDest();
                }
                else if (transform.position.x < minX)
                {
                    SetDest();
                    isAtMax = false;
                }

                if (isAtMax)
                {
                    transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
                }
            }

            if (!isAtMax)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            }

            if (hitCoolDown > 0)
            {
                hitCoolDown -= Time.deltaTime;
            } else
            {
                isHit = false;
                Debug.Log(isHit);
            }


            if (health <= 0)
            {
                //attacking set true to stop update
                Debug.Log("Die");
                isDead = true;
                state = 4;
                anim.SetState(state);
                Invoke("Die", 1f);
            }
        }
    }

    void Attack()
    {
        isAttacking = false;
    }

    void SetDest()
    {
        if (isAtMax)
        {
            dest = new Vector2(minX, yPos);
        }
        else
        {
            dest = new Vector2(maxX, yPos);
        }
    }

    public void Hit(float amount)
    {
        if (health > 0)
        {
            state = 2;

            if (!isHit)
            {
                isHit = true;
                hitCoolDown = (1f / 3f) * 2;
                health -= amount;
                Debug.Log(health);
            }
        } else
        {
            Debug.Log("Die");
            isDead = true;
            state = 4;
            anim.SetState(state);
            Invoke("Die", 1f);
        }
    }

    void Die()
    {
        Debug.Log("DED");
        bossAi.enabled = false;
    }
}
