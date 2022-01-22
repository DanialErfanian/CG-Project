using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public static int BOX_COUNTS = 18;
    public float speed = 0;
    public TextMeshProUGUI score;
    public GameObject winTextObject;
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
	      winTextObject.SetActive(false);
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

	    if (count >= BOX_COUNTS)
	    {
		    winTextObject.SetActive(true);
	    }

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
            GetComponents<AudioSource>()[1].Play();
            other.gameObject.SetActive(false);
	          count = count + 1;
	          SetCountText();
        }
    }
}
