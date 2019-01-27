using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAI : MonoBehaviour {

    private static Boss boss = new Boss();

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float yPos;

    private float speed = boss.moveSpeed;

    private bool isAtMax = false;

    //private Text nameTxt;

    private Vector2 dest;

    private float followRange = 0.6f;
    private float attackRange = 0.3f;
    private float distanceToTarget;
    private bool isAttacking = false;
    private GameObject player;
    private GameObject target;



    private void Start()
    {
        transform.position = new Vector2(minX, yPos);
        dest = new Vector2(maxX, yPos);
        transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        //nameTxt = GetComponent<Text>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void FixedUpdate () {

        player = GameObject.FindGameObjectWithTag("Player");

        distanceToTarget = Vector2.Distance(transform.position, player.transform.position);

        if(player != null && distanceToTarget <= followRange && !isAttacking)
        {
            target = player;
        } else
        {
            target = null;
        }

        if (target != null) {

            if(distanceToTarget <= attackRange)
            {
                Debug.Log("Player Within Range");
                isAttacking = true;
                Invoke("Attack", 1f);
                return;
            }

            if(target.transform.position.x < transform.position.x)
            {
                isAtMax = true;
                transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            } else
            {
                isAtMax = false;
                transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            }


        }
        else if (!isAttacking) {
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
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
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
        } else
        {
            dest = new Vector2(maxX, yPos);
        }
    }
}
