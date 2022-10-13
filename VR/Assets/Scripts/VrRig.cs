using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;
    public Transform sholder;
    public Transform handBones;

    private float rigDist;
    public float rotateOffset = 1;


    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
        //rigTarget.rotation = vrTarget.rotation * trackingScaleOffset;


        if (sholder != null)
        {

            rigDist = Vector3.Distance(handBones.position, rigTarget.position);

            if (rigDist > 0.05f)
            {
                //Debug.Log(rigDist);
                //sholder.transform.rotation = sholder.transform.rotation * Quaternion.Euler(0, 0, rigDist * rotateOffset); //Can not rotate!!!
            }
        }
    }
}



public class VrRig : MonoBehaviour
{

    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstrain;
    public Vector3 headBodyOffset;
    public float turnSmooth = 5;


    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstrain.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = headConstrain.position + headBodyOffset;
        //transform.forward = Vector3.ProjectOnPlane(headConstrain.forward, Vector3.up).normalized;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstrain.forward, Vector3.up).normalized, Time.deltaTime * turnSmooth);

        head.Map();
        leftHand.Map();
        rightHand.Map();


    }
}
