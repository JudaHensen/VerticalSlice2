﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    private PlayerMovement movement;

    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
    }

    //Movement
    private KeyCode movLeft = KeyCode.A;
    private KeyCode movRight = KeyCode.D;
    private KeyCode jump = KeyCode.Space;

    //Dash
    private KeyCode dash = KeyCode.LeftShift;

    //Actions
    //private KeyCode attack = KeyCode.Mouse0;
    //private KeyCode menu = KeyCode.Escape;
    //private KeyCode testFunction = KeyCode.T;

    void Update()
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

        if(Input.GetKey(movRight) && Input.GetKey(dash) || Input.GetKey(movLeft) && Input.GetKey(dash))
        {
            movement.Dash();
        }

        if(!Input.GetKey(movLeft) && !Input.GetKey(movRight))
        {
            movement.SlowDown();
        }

        if (Input.GetKey(jump))
        {
            movement.Jump();
        }

        //if (Input.GetKeyDown(menu))
        //{
        // open pause menu
        //}

            //if (Input.GetKeyDown(testFunction))
            //{
            // Test Function
            //}
    }
}