using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class M3S10PlayerCtrl : MonoBehaviour
{
    public float moveForce;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool isGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveForce, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isGround = false;
            Debug.Log("Is Jumping");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("Grounded");
        }
    }
}