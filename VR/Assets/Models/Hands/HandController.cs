using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{

    ActionBasedController controller;
    public Hand hand;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controller.activateAction.action.ReadValue<float>());
        //Debug.Log(controller.activateActionValue.action.ReadValue<float>());
        hand.SetGrip(controller.selectAction.action.ReadValue<float>());
        hand.SetTrigger(controller.activateAction.action.ReadValue<float>());
    }
}
