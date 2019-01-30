using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    Animator animator;

    private float state;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("State", GetState());


        //if (Input.GetKeyDown(KeyCode.Keypad0))
        //{
        //    state = 0;
        //    Debug.Log("0");
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    state = 1;
        //    Debug.Log("1");
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad2))
        //{
        //    state = 2;
        //    Debug.Log("2");
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad3))
        //{
        //    state = 3;
        //    Debug.Log("3");
        //}
    }

    float GetState()
    {
        return state;
    }

    public void SetState(float State)
    {
        state = State;
    }

}
