using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody rb;
    public Vector3 movementDirection;

    public bool isPlayerOne;
    public bool canMove;


    void Start()
    {
        if (rb == null)
            rb = gameObject.GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        float horizontalInput;
        float verticalInput;

        if (isPlayerOne)
        {
            horizontalInput = Input.GetAxis("Horizontal") ;
            verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            horizontalInput = Input.GetAxis("HorizontalSecond");
            verticalInput = Input.GetAxis("VerticalSecond");
        }

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        
    }

    private void FixedUpdate()
    {
        if(canMove)
            rb.AddForce(movementDirection * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainBall"))
        {
            SoundManager.instance.PlaySound(SoundManager.instance.effect);
        }
    }
}
