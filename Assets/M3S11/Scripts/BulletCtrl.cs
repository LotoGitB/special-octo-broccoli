using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletCtrl : MonoBehaviour
{
  private Rigidbody2D rigidbodyRef;
  public float shootForce;

  void Awake()
  {
    rigidbodyRef = gameObject.GetComponent<Rigidbody2D>();
  }

  public void Shoot(Vector3 position)
  {
    gameObject.transform.position = position;
    gameObject.transform.rotation = Quaternion.identity;
    rigidbodyRef.AddForce(Vector2.up * shootForce);
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("touch");
    gameObject.SetActive(false);
    if (other.gameObject.tag == "Enemy")
    {
      Destroy(other.gameObject);
      // other.gameObject.SetActive(false);
    }
  }
}
