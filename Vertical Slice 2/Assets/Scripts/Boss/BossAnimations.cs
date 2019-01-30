using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimations : MonoBehaviour {

    Animator animator;

    private float state;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Action", GetState());
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
