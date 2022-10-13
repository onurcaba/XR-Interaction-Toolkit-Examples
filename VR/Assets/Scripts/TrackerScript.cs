using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerScript : MonoBehaviour
{
    public GameObject targetObject;

    void Update()
    {
        transform.position = targetObject.transform.position;
        transform.rotation = targetObject.transform.rotation;

        //gameObject.transform.GetChild(0).gameObject.SetActive(targetObject.activeSelf);
        
    }
}
