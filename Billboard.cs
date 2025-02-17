using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform camera;

    Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        //transform.rotation = camera.rotation * originalRotation;
        //BillboardRotation = Quaternion.Euler(Vector3.up) * camera.rotation;
        //transform.rotation = Quaternion.Euler(Vector3.up) * originalRotation * camera.rotation;

        originalRotation = Quaternion.Euler(Vector3.up);
        transform.rotation = camera.rotation * originalRotation;
    }
}
