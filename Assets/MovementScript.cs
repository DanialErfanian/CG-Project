using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController controller; 

    public float speed = 6f;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical"); 
        Vector3 directon  = new Vector3(horizontal, 0f, vertical).normalized;

        if (directon.magnitude >= 0.1f){
            controller.Move(directon * speed * Time.deltaTime);
        }
    }
}
