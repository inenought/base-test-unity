using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : UpdateManager
{
    [SerializeField] Transform directionTarget;//player head
    Quaternion initialRot;
    [SerializeField] Transform followposition;
    //
    [Tooltip("Player transform to rotate with camera")]
    [SerializeField] Transform playerTransform;

    [SerializeField] float smoothFollowTime;
    [SerializeField]Vector3 vel = Vector3.zero;
    //-------------
    RaycastHit hit;
    //-------------
    [Tooltip("Velocity of Camera Rotation")]
    [SerializeField]float RotVelocity;
    float rotationX;
    float rotationY;
    //-------------
    bool rotLocked;

    private void Start()
    {
        rotLocked = true;
    }

    public override void FrameUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            rotLocked = false;
        }
        else
        {
            rotLocked = true;
            RotatePlayer();
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
        if (!Physics.Linecast(target, followposition.position, out hit))
        {
            //LERP IS MORE OPTIMIZED, BUT, I HAVE NO MORE TIME, Desculpa ai Rise
            transform.position = Vector3.SmoothDamp(transform.position, followposition.position, ref vel, smoothFollowTime);
            Debug.DrawLine(target, followposition.position);
        }
        else
        { transform.position = Vector3.SmoothDamp(transform.position, hit.point, ref vel, smoothFollowTime); }

    }

    void RotateCamera(Transform point)
    {
        if (rotLocked)
        {
            point.rotation = directionTarget.parent.rotation;
        }
        else
        {
            rotationX = Input.GetAxis("Mouse X") * RotVelocity * Time.deltaTime;
            rotationY = -Input.GetAxis("Mouse Y") * RotVelocity/4 * Time.deltaTime;

            point.Rotate(rotationY, rotationX,0);
        }

    }

    void RotatePlayer()
    {
        rotationX = Input.GetAxis("Mouse X") * RotVelocity * Time.deltaTime;
        playerTransform.Rotate(0, rotationX , 0);
    }
}
