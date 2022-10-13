using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Smooth : MonoBehaviour
{

    public Animator animator;
    float frameCurrent = 0f;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.speed = 0f;

    }

    void Update()
    {
        AnimateHand();
        //frameCurrent = controller.activateActionValue.action.ReadValue<float>();
        //Debug.Log(frameCurrent);

    }

    private void AnimateHand()
    {
        
        animator.Play("CloseHand", 0, frameCurrent);
    }

    internal void SetGrip(float v)
    {
        frameCurrent = v;
    }
}
