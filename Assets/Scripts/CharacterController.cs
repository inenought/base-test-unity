using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : UpdateManager
{
    [SerializeField] float currentspeed;
    [SerializeField] float rotationSpeed;
    [SerializeField]Animator animToController;
    [SerializeField]PlayerStatus ps;
    //--------------
    Vector3 movementAxis;
    Vector3 RaycastVisionDirection;

    [SerializeField]string VerticalInput;
    [SerializeField]string HorizontalInpput;

    void Start()
    {
        animToController = GetComponent<Animator>();
        ps.GetComponent<PlayerStatus>();

    }
    public override void TimeUpdate()
    {
        currentspeed = ps.MoveSpeed;
        currentspeed = Input.GetKey(KeyCode.LeftShift) ? Mathf.Lerp(ps.MaxMoveSpeed, currentspeed, 0.1f) : Mathf.Lerp(currentspeed, ps.MaxMoveSpeed, 0.1f);
        movementAxis.Set(0,0, Input.GetAxis(VerticalInput)* currentspeed * Time.deltaTime);

        transform.Translate(movementAxis);
        transform.Rotate(0, Input.GetAxis(HorizontalInpput) * rotationSpeed * Time.deltaTime, 0);

        animToController.SetFloat("speed", Input.GetAxis(VerticalInput) * currentspeed);
        //test failed
        //animToController.SetFloat("rotSpeed", Input.GetAxis(HorizontalInpput) * rotationSpeed);
    }
}
