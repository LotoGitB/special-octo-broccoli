using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
  public Sprite[] enemySprites;
  public float maxSpawnX;
  public float minSpawnX;
  public GameObject prefabEnemyRef;

  private void Start()
  {
    InvokeRepeating("Spawn", 3, 3);
  }

  public void Spawn()
  {
    GameObject enemy = Instantiate(prefabEnemyRef, new Vector3(Random.Range(minSpawnX, maxSpawnX), 5.5f, 0f), Quaternion.identity);
    enemy.GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Length)];
  }
}
