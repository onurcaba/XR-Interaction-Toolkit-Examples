using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class QuestStepScrew : QuestStepElement
{
    public bool screwedStatus = true;

    private void OnEnable()
    {
        gameObject.GetComponent<XRSimpleInteractable>().enabled = true;
    }
}
