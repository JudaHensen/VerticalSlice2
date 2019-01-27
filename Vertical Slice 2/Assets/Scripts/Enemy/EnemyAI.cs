using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {

    private static Enemy enemy = new Enemy();

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float yPos;

    private float speed = enemy.moveSpeed;

    [SerializeField]
    [Header("To use default speed set to 0")]
    private float overrideSpeed;

    private Text nameTxt;

    private Vector2 dest;

    private bool isAtMax = false;

    private void Start()
    {
        transform.position = new Vector2(minX, yPos);
        nameTxt = GetComponent<Text>();
        dest = new Vector2(maxX, yPos);
        if (overrideSpeed != 0)
        {
            speed = overrideSpeed;
        }
    }


    void FixedUpdate () {
        
        if (transform.position.x > maxX)
        {
            isAtMax = true;
            SetDest();
        } else if (transform.position.x < minX)
        {
            SetDest();
            isAtMax = false;
        }

        if (isAtMax)
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }else
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
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
