using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class QuestStep : MonoBehaviour
{
    public bool isActive;
    public int stepID;
    public string stepTitle;
    public string stepDescription;
    public List<QuestStepElement> stepElements = new List<QuestStepElement>();
    public List<GameObject> inactivateElements = new List<GameObject>();
    public List<GameObject> ActivateElements = new List<GameObject>();
    public List<GameObject> ActivateXRComponent = new List<GameObject>();
    bool allSubStepsDone = false;


    // sub steps
    // tüm steple ilgili adým kontrolleri buradan 
    //

    public void checkSubStep()
    {
        foreach (QuestStepElement element in stepElements)
        {
            if (!element.isDone)
            {
                allSubStepsDone = false;
                break;
            }

            else
            {
                allSubStepsDone = true;
            }
        }

        onStepCompleted(allSubStepsDone);

    }



    private void onStepCompleted(bool _allstepsDone)
    {
        if (_allstepsDone)
        {
            QuestStepManager.inst.OnAStepDone(stepID);
        }
    }

    public void ActivateInactivateElements()
    {
        //Inactivate with delay
        foreach (var item in inactivateElements)
        {
            StartCoroutine(InactivateCoroutine());
        }

        //Activate
        foreach (var item in ActivateElements)
        {
            item.SetActive(true);
        }
    }

    IEnumerator InactivateCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (var item in inactivateElements)
        {
            item.SetActive(false);
        }
    }


    //Exeption for grab interactable
    public void ActivateXR()
    {
        StartCoroutine(ActivateXRCoroutine());
    }

    IEnumerator ActivateXRCoroutine()
    {
        yield return new WaitForSeconds(0.6f);

        foreach (var item in ActivateXRComponent)
        {
            if (item.GetComponent<XRGrabInteractable>() != null)
            {
                item.GetComponent<XRGrabInteractable>().enabled = true;
            }
        }
    }
}

