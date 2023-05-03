using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SpacePlayerMovement : MonoBehaviour
{
  private Rigidbody2D rigidbodyRef;
  public float moveForce;
  // Start is called before the first frame update
  void Start()
  {
    rigidbodyRef = gameObject.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    float xForce = Input.GetAxis("Horizontal");
    float yForce = Input.GetAxis("Vertical");

    rigidbodyRef.AddForce(new Vector2(xForce, yForce) * moveForce);
  }
}
