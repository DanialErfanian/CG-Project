using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class PlayerScript : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI score; 
    private Rigidbody rb;
    private int count; 
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        rb = GetComponent<Rigidbody>();
	count = 0;
	SetCountText(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        Debug.Log("Test1");
    }

    void SetCountText()
    {
	    score.text = "Score: " + count.ToString(); 
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        Debug.Log("Test2");
        Debug.Log(movementX);
        Debug.Log(movementY);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
	    count = count + 1;
	    SetCountText(); 
        }
    }
}
