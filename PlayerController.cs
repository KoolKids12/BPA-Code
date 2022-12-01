using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float health, maxhealth = 3f;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Weapon magic;

    Vector2 moveDirection;
    Vector2 mousePosition;


    private void Start()
    {
     health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        
        if(Input.GetMouseButtonDown(1))
        {
            magic.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
    }

     private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }

     public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; // 3 -> 2 -> 1 -> dead
        if(health <=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            TakeDamage(1);
            Debug.Log("hit");
        }
        else if (collision.gameObject.tag == "Orc")
        {
            TakeDamage(3);
            Debug.Log("hit");
        }
    }  
    
}
