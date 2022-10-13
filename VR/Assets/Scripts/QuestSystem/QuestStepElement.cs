using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class QuestStepElement : MonoBehaviour
{
    private QuestStep ActiveQuestStep;
    public bool isElementActive;

    public bool isDone = false;

    public void Done()
    {
        isDone = true;
        ActiveQuestStep = QuestStepManager.inst.mainSteps[QuestStepManager.inst.currentStepIndex];
        ActiveQuestStep.checkSubStep();
    }

    public void activateElement()
    {
        isElementActive = true;
        isDone = false;

        //Find gameobject to HighLight and highlight it
        EmmisionOnOff(1);

        //Turn on Grabbable
        var xrGrabIntComp = gameObject.GetComponent<XRGrabInteractable>();

        if (xrGrabIntComp != null)
        {
            xrGrabIntComp.enabled = true;
        }
    }

    public void inActivateElement()
    {
        if (gameObject.activeSelf) StartCoroutine(Inactivate());
    }
    IEnumerator Inactivate()
    {
        yield return new WaitForSeconds(0.1f);
        isElementActive = false;

        //Find gameobject HighLighted and turn of
        EmmisionOnOff(0);

        //Turn off grabbable
        var xrGrabIntComp = gameObject.GetComponent<XRGrabInteractable>();

        if (xrGrabIntComp != null)
        {
            xrGrabIntComp.enabled = false;
        }

        var rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void EmmisionOnOff(int value)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            try
            {
                MeshRenderer mR = child.GetComponent<MeshRenderer>();
                if (mR.material.name.Contains("_HL"))
                {
                    mR.material.SetInt("_Emission", value);
                }
            }

            catch
            {

            }

            try
            {
                MeshRenderer mR = gameObject.GetComponent<MeshRenderer>();
                if (mR.material.name.Contains("_HL"))
                {
                    mR.material.SetInt("_Emission", value);
                }
            }

            catch
            {

            }

            //if (child.GetComponents<MeshRenderer>() != null)
            //{
            //    if (child.GetComponent<MeshRenderer>().material.name.Contains("_HL"))
            //    {
            //        child.GetComponent<MeshRenderer>().material.SetInt("_Emission", value);
            //    }
            //}
        }
    }
}
