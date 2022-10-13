using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//[RequireComponent(typeof(ActionBasedController))]
public class ToggleMenu : MonoBehaviour
{
    public bool equipped = false;

    public InputActionReference toogleRef = null;
    public GameObject canvasInfoMenu;
    public List<GameObject> touchControllers = new List<GameObject>();

    public InputActionReference toolSelectRef = null;
    public GameObject HandwithTool;
    public GameObject Hand;
    ActionBasedControllerManager abcm;

    // Start is called before the first frame update
    void Awake()
    {
        abcm = gameObject.GetComponent<ActionBasedControllerManager>();
        toogleRef.action.started += Toogle;
        toolSelectRef.action.started += ToolScelect;
    }

    private void OnDestroy()
    {
        toogleRef.action.started -= Toogle;
        toolSelectRef.action.started -= ToolScelect;

    }

    void Toogle(InputAction.CallbackContext context)
    {
        if (canvasInfoMenu != null)
        {
            bool isActive = !canvasInfoMenu.activeSelf;
            canvasInfoMenu.SetActive(isActive);
        }

        if (touchControllers != null)
        {
            foreach (var controller in touchControllers)
            {
                controller.SetActive(canvasInfoMenu.activeSelf);
            }
        }
    }

    void ToolScelect(InputAction.CallbackContext context)
    {
        ToolSelectMethod();
    }

    private void ToolSelectMethod()
    {
        if (equipped == false) return;
        if (abcm.baseControllerGameObject == Hand)
        {
            HandwithTool.SetActive(true);
            abcm.baseControllerGameObject = HandwithTool;
            Hand.SetActive(false);
        }
        else if (abcm.baseControllerGameObject == HandwithTool)
        {
            Hand.SetActive(true);
            abcm.baseControllerGameObject = Hand;
            HandwithTool.SetActive(false);
        }
        else Debug.Log("No base controller object");
    }

    public void Equip()
    {
        equipped = true;
        ToolSelectMethod();

    }
}
