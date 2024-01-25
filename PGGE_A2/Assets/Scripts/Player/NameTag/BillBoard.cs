using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    //makes the canvas always face the camera

    Transform mainTransform;

    void Start()
    {
        mainTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + mainTransform.rotation * Vector3.forward,
            mainTransform.rotation * Vector3.up);
    }
}
