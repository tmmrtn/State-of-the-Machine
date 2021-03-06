﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateIdle : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Idle anim started");
        animator.SetBool("Idling", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Got Space While Idle");
            animator.SetBool("Jumping", true);
            //animator.SetBool("Idling", false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Meleeing", true);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("Shooting", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Running", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Running", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
