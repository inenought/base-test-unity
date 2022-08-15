using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    [SerializeField]GameObject braco;
    [SerializeField] float mouseX, mouseY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX, 0);
        braco.transform.Rotate(mouseY *20* Time.deltaTime,0,0);
    }
}
        