using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public float JumpForce;
    public Vector3 jump;
    private bool IsGrounded;

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
        bool jumpMovement = Input.GetKeyDown("space");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown ("space") && IsGrounded == true)
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
