using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : UpdateManager
{
    [SerializeField] Transform directionTarget;//player head
    [SerializeField] Quaternion initialRot;
    [SerializeField] Transform[] followpositions;

    [SerializeField] float smoothFollowTime;
    [SerializeField]Vector3 vel = Vector3.zero;
    //-------------
    RaycastHit hit;
    //-------------
    [SerializeField]float RotVelocity;
    [SerializeField]float rotationX;
    [SerializeField]float rotationY;
    //-------------
    bool rotLocked;

    private void Start()
    {
        rotLocked = true;
    }

    public override void FrameUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            rotLocked = !rotLocked;
        }
    }
    public override void ByLateUpdate()
    {
        GameplayCamMode1(0,directionTarget.position);
        RotateCamera(directionTarget);

    }

    void GameplayCamMode1(int BackwardViewer, Vector3 target)
    {
        //Look on playerHead
        transform.LookAt(target);
        if (!Physics.Linecast(target, followpositions[BackwardViewer].position, out hit))
        {
            //LERP IS MORE OPTIMIZED, BUT, I HAVE NO MORE TIME, Desculpa ai Rise
            transform.position = Vector3.SmoothDamp(transform.position, followpositions[BackwardViewer].position, ref vel, smoothFollowTime);
            Debug.DrawLine(target, followpositions[BackwardViewer].position);
        }
        else
        { transform.position = Vector3.SmoothDamp(transform.position, hit.point, ref vel, smoothFollowTime); }

    }

    void RotateCamera(Transform point)
    {
        if (rotLocked)
        {
            point.rotation = directionTarget.parent.rotation;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            rotationX = Input.GetAxis("Mouse X") * RotVelocity * Time.deltaTime;
            rotationY = -Input.GetAxis("Mouse Y") * RotVelocity/4 * Time.deltaTime;

            point.Rotate(rotationY, rotationX,0);
        }


    }
}
