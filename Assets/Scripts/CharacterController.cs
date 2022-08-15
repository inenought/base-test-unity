using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : UpdateManager
{
    [SerializeField]float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField]Animator animToController;
    [SerializeField]PlayerStatus ps;
    //--------------
    Vector3 movementAxis;
    Vector3 RaycastVisionDirection;

    [SerializeField]string VerticalInput;
    [SerializeField]string HorizontalInpput;

    //--------------IF I NEED THAT
    [SerializeField] NavMeshAgent playerAgent;
    //--------------
    //AnimatorLayers
    int moveBaseLayer;
    int turnBaseLayer;
    
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        animToController = GetComponent<Animator>();
        ps.GetComponent<PlayerStatus>();
        //planning
        turnBaseLayer = animToController.GetLayerIndex("turnBase");
        moveBaseLayer = animToController.GetLayerIndex("moveBase");
        //
    }
    public override void TimeUpdate()
    {
        speed = Input.GetKey(KeyCode.LeftShift) ? Mathf.Lerp(speed,3,0.1f) : Mathf.Lerp(speed, 2, 0.1f);
        movementAxis.Set(0,0, Input.GetAxis(VerticalInput)* speed * Time.deltaTime);

        transform.Translate(movementAxis);
        transform.Rotate(0, Input.GetAxis(HorizontalInpput) * rotationSpeed * Time.deltaTime, 0);

        animToController.SetFloat("speed", Input.GetAxis(VerticalInput) * speed);
        //test failed
        //animToController.SetFloat("rotSpeed", Input.GetAxis(HorizontalInpput) * rotationSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        //not for while
    }
}
