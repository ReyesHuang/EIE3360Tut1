using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text changingText;
    private Rigidbody rb;
    public float speed;
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()

    //Update() runs once per frame. FixedUpdate() can run once, zero, or several times per frame, depending on how many physics frames per second are set in the time settings and how fast/slow the framerate is.
    {
        float moveHorizontal = 0;
        float moveVertical = 0;

        if (Input.GetKey(KeyCode.A))
            moveHorizontal = -1;
        if (Input.GetKey(KeyCode.D))
            moveHorizontal = 1;
        if (Input.GetKey(KeyCode.W))
            moveVertical = 1;
        if (Input.GetKey(KeyCode.S))
            moveVertical = -1;


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            ChangeText();
            other.gameObject.SetActive(false);
        }
    }
    void ChangeText()
    {
        score++;
        changingText.text = "Collected: " + score;
    }

}
