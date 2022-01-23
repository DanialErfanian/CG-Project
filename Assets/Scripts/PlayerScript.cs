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
    private int count;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
	      count = 0;
        SetCountText();
	      winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SetCountText()
    {
	    score.text = "Score: " + count.ToString();

	    if (count >= BOX_COUNTS)
	    {
		    winTextObject.SetActive(true);
	    }

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
