﻿using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerAttack playerAttack;

    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    //Movement
    private KeyCode movLeft = KeyCode.A;
    private KeyCode movRight = KeyCode.D;
    private KeyCode jump1 = KeyCode.W;
    private KeyCode jump2 = KeyCode.Space;

    //Dash
    private KeyCode dash = KeyCode.LeftShift;

    //Actions
    private KeyCode attack = KeyCode.Mouse0;


    //TO-DO
    //private KeyCode menu = KeyCode.Escape;
    //private KeyCode testFunction = KeyCode.T;

    void Update()
    {
        if (Player.health > 0)
        {
            UpdatePlayer();
        }

        //if (Input.GetKeyDown(attack))
        //{
        //    Boss.health = 0;
        //}
    }

    void UpdatePlayer()
    {
        //Movement
        if (Input.GetKey(movLeft))
        {
            movement.MoveLeft();
        }
        else if (Input.GetKey(movRight))
        {
            movement.MoveRight();
        }

        if (Input.GetKey(movRight) && Input.GetKey(dash) || Input.GetKey(movLeft) && Input.GetKey(dash))
        {
            movement.Dash();
        }

        if (!Input.GetKey(movLeft) && !Input.GetKey(movRight))
        {
            movement.SlowDown();
        }

        if (Input.GetKey(jump1) || Input.GetKey(jump2))
        {
            movement.Jump();
        }

        if (Input.GetKeyDown(attack))
        {
            playerAttack.AddCombo();
        }

    }
}