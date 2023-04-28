using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class M3S10PlayerCtrl : MonoBehaviour
{
  public float moveForce;
  public float jumpForce;

  private Rigidbody2D rb;
  private bool isGround = false;
  private Vector3 startPosition;
  private Animator animatorCtrl;
  private bool lockMovement = false;
  // Start is called before the first frame update
  void Start()
  {
    rb = gameObject.GetComponent<Rigidbody2D>();
    animatorCtrl = gameObject.GetComponent<Animator>();
    startPosition = gameObject.transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetAxis("Horizontal") != 0)
    {
      animatorCtrl.SetBool("isMoving", true);
      if (Input.GetAxis("Horizontal") < 0)
      {
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
      }
      else
      {
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
      }
    }
    else
    {
      animatorCtrl.SetBool("isMoving", false);
    }

    if (lockMovement == false)
    {
      rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveForce, rb.velocity.y);

      if (Input.GetButtonDown("Jump") && isGround)
      {
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        isGround = false;
        animatorCtrl.SetBool("isJumping", true);
        Debug.Log("Is Jumping");
      }
    }

    animatorCtrl.SetFloat("isFalling", rb.velocity.y);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      isGround = true;
      animatorCtrl.SetBool("isJumping", false);
      Debug.Log("Grounded");
    }
  }

  public void ResetPlayerPosition()
  {
    gameObject.transform.position = startPosition;
  }

  public void RespawnComplete()
  {
    rb.gravityScale = 1;
    lockMovement = false;
  }

  public void DeadAnim()
  {
    lockMovement = true;
    rb.gravityScale = 0;
    rb.velocity = Vector2.zero;
    animatorCtrl.SetTrigger("TouchLimit");
    animatorCtrl.SetBool("isJumping", false);
  }
}