using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimations : MonoBehaviour {

    public Animator animator;

    private float state;
    

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
