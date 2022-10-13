using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class QuestStepManager : MonoBehaviour
{
    public static QuestStepManager inst = null;
    public int currentStepIndex = 0;
    public List<QuestStep> mainSteps = new List<QuestStep>();
    public TextMeshProUGUI PreviousStepDescriptionUI;
    public TextMeshProUGUI CurrentstepDescriptionUI;

    public TextMeshProUGUI CanvasInfoDescriptionUI;

    public TextMeshProUGUI NextStepDescriptionUI;
    public GameObject InstallStepsPDF;
    public GameObject RemoveStepsPDF;

    private void Awake()
    {
        inst = this;

        //Collect Quest Steps on list
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            mainSteps.Add(gameObject.transform.GetChild(i).GetComponent<QuestStep>());
        }
    }

    //public event Action<int> onNewStep;


    private void Start()
    {
        NewStep(currentStepIndex);
    }

    // List for subSteps
    //public List<QuestStepElement> subSteps = new List<QuestStepElement>();

    // List For MainSteps

    internal void OnAStepDone(int stepID)
    {
        // Inactivate current step elements
        var currentSubSteps = mainSteps[currentStepIndex].stepElements;

        foreach (var item in currentSubSteps)
        {
            item.inActivateElement();
        }


        mainSteps[currentStepIndex].isActive = false;

        //Icreasing Step Id
        currentStepIndex++;
        if (currentStepIndex == 7)
        {
            RemoveStepsPDF.SetActive(false);
            InstallStepsPDF.SetActive(true);
        }

        if (currentStepIndex <= mainSteps.Count)
        {
            //Debug.Log(currentStepIndex);
            NewStep(currentStepIndex);
        }
    }


    public void NewStep(int stepId)
    {
        //set UI description in hand
        if (stepId > 0) PreviousStepDescriptionUI.text = mainSteps[stepId - 1].stepTitle;

        CurrentstepDescriptionUI.text = mainSteps[stepId].stepTitle;
        CanvasInfoDescriptionUI.text = mainSteps[stepId].stepDescription;

        if (stepId < mainSteps.Count-1) NextStepDescriptionUI.text = mainSteps[stepId + 1].stepTitle;
        else NextStepDescriptionUI.text = "Done";


        mainSteps[currentStepIndex].isActive = true;
        mainSteps[currentStepIndex].ActivateInactivateElements();
        var currentSubSteps = mainSteps[stepId].stepElements;

        foreach (var item in currentSubSteps)
        {
            item.activateElement();
        }
        //exeption for XRGrab
        mainSteps[currentStepIndex].ActivateXR();
    }

}
