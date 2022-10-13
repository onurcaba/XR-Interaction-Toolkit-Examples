using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(ActionBasedController))]
public class HandController_Smooth : MonoBehaviour
{

    ActionBasedController controller;   
    public Hand_Smooth hand;


    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        
    }

    void Update()
    {
       
        hand.SetGrip(controller.selectActionValue.action.ReadValue<float>());
        //hand.SetTrigger(controller.activateActionValue.action.ReadValue<float>());
    }
}
