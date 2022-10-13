using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorPlayer : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAnimator()
    {
        animator.SetBool("unScrew", true);
    } 
    
    public void RewindAnimator()
    {
        animator.SetBool("screw", true);
    }
}
