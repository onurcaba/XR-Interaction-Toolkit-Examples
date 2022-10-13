using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(ActionBasedController))] //Addad

public class rotateBox_Script : MonoBehaviour
{
    ActionBasedController controller; //Addad
    public float frameCurrent = 0f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>(); //Addad

        animator = gameObject.GetComponent<Animator>();
        animator.speed = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(controller.activateActionValue.action.ReadValue<float>());
        animator.Play("Box_Rotate", 0, frameCurrent); //controller.activateActionValue.action.ReadValue<float>()

    }
}
