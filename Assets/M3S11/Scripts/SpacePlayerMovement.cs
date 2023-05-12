using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SpacePlayerMovement : MonoBehaviour
{
  private Rigidbody2D rigidbodyRef;
  public float moveForce;
  public int lifePoints = 3;
  public TextMeshProUGUI lifePointsTextRef;
  // Start is called before the first frame update
  void Start()
  {
    rigidbodyRef = gameObject.GetComponent<Rigidbody2D>();
    lifePointsTextRef.text = "Vidas: " + lifePoints;
  }

  // Update is called once per frame
  void Update()
  {
    float xForce = Input.GetAxis("Horizontal");
    float yForce = Input.GetAxis("Vertical");

    rigidbodyRef.AddForce(new Vector2(xForce, yForce) * moveForce);
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      lifePoints--;
      lifePointsTextRef.text = "Vidas: " + lifePoints;
      Destroy(other.gameObject);
      if (lifePoints <= 0)
      {
        Debug.Log("Esta Muerto el player");
      }
    }
  }
}
