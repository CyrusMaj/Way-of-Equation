using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Ctrl : MonoBehaviour {

    [SerializeField] float rotationSpeedX = 10f;
    [SerializeField] float rotationSpeedY = 10f;

    [SerializeField] float AimYspeed = 1f;

    public GameObject cameraPivot;
    public Transform characterParentTransform;
    public Transform AimY;

    public Animator anim;
    public Rigidbody rb;

    // Camera Rotation, Y Axis.
    void Update()
    {
        float rotationX = Input.GetAxis("Mouse X") * rotationSpeedX;
        rotationX *= Time.deltaTime;
        cameraPivot.transform.Rotate(0, rotationX, 0);

        //float rotationY = Input.GetAxis("Mouse Y") * rotationSpeedY;
        //rotationY *= Time.deltaTime;
        //if (rotationY > 90)
        //{
        //    AimY.transform.Rotate(rotationY, 0, 0);
        //}

    }
}
