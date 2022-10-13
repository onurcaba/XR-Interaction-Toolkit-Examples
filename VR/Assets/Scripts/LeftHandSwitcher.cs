using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandSwitcher : MonoBehaviour
{
    public List<GameObject> vrHandList;
    public GameObject interactableHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractableWithHand")
        {
            interactableHand = other.transform.Find("LeftHandMesh").gameObject;

            if (interactableHand != null)
            {
                foreach (var item in vrHandList)
                {
                    item.SetActive(false);
                }

                interactableHand.SetActive(true);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (interactableHand != null)
        {
            foreach (var item in vrHandList)
            {
                item.SetActive(true);
            }

            interactableHand.SetActive(false);

        }
    }
}
