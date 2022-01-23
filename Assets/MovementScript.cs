using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController controller; 
    public Transform cameraTransform ;
    public float speed = 6f;


    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical"); 
        Vector3 directon  = new Vector3(horizontal, 0f, vertical).normalized;
        directon = cameraTransform.TransformDirection(directon);
        directon[1] = 0f;
        if (directon.magnitude >= 0.1f){
            controller.Move(directon * speed * Time.deltaTime);
        }
    }
}
