using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public float JumpForce;
    public Vector3 jump;
    private bool IsGrounded; // cheacking if the object conected to it is on the "ground"

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        bool jumpMovement = Input.GetKeyDown("space");  // initilazing space as jump

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown ("space") && IsGrounded == true) // here down can be removed if you dont want a jump function added in
        {
            rb.AddForce(jump * JumpForce, ForceMode.Impulse);
            IsGrounded = false;
        }
    }
    void OnCollisionEnter()
    {
        IsGrounded = true;
    }
}
