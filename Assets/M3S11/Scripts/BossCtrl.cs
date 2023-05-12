using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCtrl : MonoBehaviour
{
  public Slider bossLifePointsSlider;
  public int lifePoints = 100;
  public int bulletDamage = 2;
  public GameObject enemyBulletPrefab;
  public Transform canyon;
  public float shootForce;
  private Animator animCtrl;
  private GameObject playerRef;


  // Start is called before the first frame update
  void Start()
  {
    animCtrl = gameObject.GetComponent<Animator>();
    playerRef = GameObject.FindGameObjectWithTag("Player");
    bossLifePointsSlider.value = lifePoints;
    animCtrl.SetInteger("life", lifePoints);
    InvokeRepeating("SpawnDirectedBullet",0,0.5f);
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "PlayerBullet" && lifePoints > 0)
    {
      lifePoints -= bulletDamage;
      bossLifePointsSlider.value = lifePoints;
      animCtrl.SetInteger("life", lifePoints);
    }
  }

  public void SpawnSimpleBullet()
  {
    GameObject enemy = Instantiate(enemyBulletPrefab, canyon.position, Quaternion.identity);
  }

  public void SpawnDirectedBullet()
  {
    GameObject enemy = Instantiate(enemyBulletPrefab, canyon.position, Quaternion.identity);
    enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
    enemy.GetComponent<Rigidbody2D>().AddForce((playerRef.transform.position - enemy.transform.position).normalized * shootForce);
  }
}
