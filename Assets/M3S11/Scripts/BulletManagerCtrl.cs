using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagerCtrl : MonoBehaviour
{
  private GameObject[] bulletsAvailable;
  private GameObject playerRef;
  private int nextBullet = 0;
  // Start is called before the first frame update
  void Start()
  {
    playerRef = GameObject.FindGameObjectWithTag("Player");
    bulletsAvailable = GameObject.FindGameObjectsWithTag("PlayerBullet");
    foreach (GameObject b in bulletsAvailable)
    {
      b.SetActive(false);
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Jump"))
    {
      if (bulletsAvailable.Length == nextBullet)
      {
        nextBullet = 0;
      }
      bulletsAvailable[nextBullet].SetActive(true);
      bulletsAvailable[nextBullet].GetComponent<BulletCtrl>().Shoot(playerRef.transform.position);
      nextBullet++;
    }
  }


}
