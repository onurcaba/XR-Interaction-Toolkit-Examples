using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPoser : MonoBehaviour
{
    public GameObject canvasGO;
    public float speed =2f;


    // Start is called before the first frame update
    void Start()
    {
        canvasGO.transform.position = transform.position;
        canvasGO.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Position vector
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 slerperP = Vector3.Slerp(canvasGO.transform.position, targetPos, Time.deltaTime * speed);

        //Rotation Vector
        //Quaternion targetRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Quaternion targetRot = transform.rotation;
        Quaternion slerperQ = Quaternion.Slerp(canvasGO.transform.rotation, targetRot, Time.deltaTime * speed);
        canvasGO.transform.position = slerperP;
        canvasGO.transform.rotation = slerperQ;
    }
}
