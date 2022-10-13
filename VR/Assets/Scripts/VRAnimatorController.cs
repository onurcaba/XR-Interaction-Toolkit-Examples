using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    private Animator animator;
    private Vector3 previousPos;
    private VrRig vrRig;
    public float speedTreshold = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VrRig>();
        previousPos = vrRig.head.vrTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Compute the speed
        Vector3 headsetSpeed = (vrRig.head.vrTarget.position - previousPos) / Time.deltaTime;
        headsetSpeed.y = 0;

        //Local Speed
        Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
        previousPos = vrRig.head.vrTarget.position;

        //Set Animator Values
        animator.SetBool("isMoving", headsetLocalSpeed.magnitude > speedTreshold);
        //Debug.Log(headsetLocalSpeed.magnitude > speedTreshold);

    }
}
