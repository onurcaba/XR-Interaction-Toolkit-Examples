using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ScrewDriver : MonoBehaviour
{
    public InputActionReference unScrewRef = null;

    public GameObject vrHandscrewDriver;

    public GameObject screwDriver;
    public GameObject screwDriverSet;
    public GameObject screwDriverTip;
    public GameObject screw;
    public GameObject RightHand;
    //public GameObject RightBaseControllerScrewDriver;

    public bool canScrewUnScrew = false;
    //public bool screwedStatus = true;

    private bool showHideLock = false;


    public Vector3 rotateValue = new Vector3(0, 0, 360);

    public float endValue = 0.05f;
    public float duration = 1f;

    public AudioSource screwAudio;
    public AudioSource unScrewAudio;


    void Awake()
    {
        unScrewRef.action.started += ScrewUnscrew;
        //aSource = gameObject.GetComponent<AudioSource>();
    }


    void ScrewUnscrew(InputAction.CallbackContext context)
    {

        //Unscrew
        if (canScrewUnScrew && screwDriverSet.GetComponent<QuestStepScrew>().screwedStatus)
        {
            unScrewAudio.Play();
            showHideLock = true;

            gameObject.GetComponent<XRDirectInteractor>().enabled = false;

            screwDriverSet.GetComponent<XRSimpleInteractable>().enabled = false;
            screwDriverSet.GetComponent<QuestStepScrew>().screwedStatus = false;

            screwDriverSet.transform.DOMove(screwDriverSet.transform.position + screwDriverSet.transform.forward * endValue, duration, false).OnComplete(() => SubstepDone());
            screw.transform.DORotate(-rotateValue, duration, RotateMode.LocalAxisAdd);
            screwDriverTip.transform.DORotate(-rotateValue, duration, RotateMode.LocalAxisAdd);

            canScrewUnScrew = false;


        }

        //Screw
        else if (canScrewUnScrew && !screwDriverSet.GetComponent<QuestStepScrew>().screwedStatus)
        {
            screwAudio.Play();
            showHideLock = true;

            gameObject.GetComponent<XRDirectInteractor>().enabled = false;

            screwDriverSet.GetComponent<XRSimpleInteractable>().enabled = false;
            screwDriverSet.GetComponent<QuestStepScrew>().screwedStatus = true;

            screwDriverSet.transform.DOMove(screwDriverSet.transform.position + screwDriverSet.transform.forward * -endValue, duration, false).OnComplete(() => SubstepDone());
            screw.transform.DORotate(rotateValue, duration, RotateMode.LocalAxisAdd);
            screwDriverTip.transform.DORotate(rotateValue, duration, RotateMode.LocalAxisAdd);

            canScrewUnScrew = false;

        }
    }
    private void OnEnable()
    {
        gameObject.GetComponent<XRDirectInteractor>().hoverEntered.AddListener(OnHoverEntered);
        gameObject.GetComponent<XRDirectInteractor>().hoverExited.AddListener(OnHoverExited);

        vrHandscrewDriver.SetActive(true);
        RightHand.SetActive(false);
    }

    private void OnDisable()
    {
        gameObject.GetComponent<XRDirectInteractor>().hoverEntered.RemoveListener(OnHoverEntered);
        gameObject.GetComponent<XRDirectInteractor>().hoverExited.RemoveListener(OnHoverExited);

        vrHandscrewDriver.SetActive(false);
        RightHand.SetActive(true);

    }

    protected virtual void OnHoverEntered(HoverEnterEventArgs args)
    {
        screwDriverSet = args.interactableObject.transform.gameObject;
        screw = screwDriverSet.transform.Find("Screw").gameObject;

        //screwDriver.SetActive(true);
        screwDriver.transform.parent = screwDriverSet.transform;
        screwDriver.transform.localPosition = Vector3.zero + new Vector3(0, 0, 0.03444549f);
        screwDriver.transform.localEulerAngles = Vector3.zero + new Vector3(0, 180, 0);

        canScrewUnScrew = true;


        //screwDriver = screwDriverSet.transform.Find("ScrewDriver").gameObject;
        screwDriverTip = screwDriver.transform.Find("ScrewDriverTip").gameObject;

        UnscrewStatusShowHide();
    }
    protected virtual void OnHoverExited(HoverExitEventArgs args)
    {
        if (!showHideLock) BeforeEndStatusShowHide();
        canScrewUnScrew = false;
    }

    void UnscrewStatusShowHide()
    {
        vrHandscrewDriver.SetActive(false);
        screwDriver.SetActive(true);
    }

    void SubstepDone()
    {
        showHideLock = false;

        QuestStepElement qse = screwDriverSet.GetComponent<QuestStepElement>();
        qse.Done();

        gameObject.GetComponent<XRDirectInteractor>().enabled = true;

        if (!screwDriverSet.GetComponent<QuestStepScrew>().screwedStatus)
        {
            screwDriverSet.SetActive(false);
        }

        BeforeEndStatusShowHide();

    }

    void BeforeEndStatusShowHide()
    {
        vrHandscrewDriver.SetActive(true);

        if (screwDriver != null)
        {
            screwDriver.SetActive(false);
        }

        screwDriverTip = null;
        screw = null;
        screwDriverSet = null;
    }


}
