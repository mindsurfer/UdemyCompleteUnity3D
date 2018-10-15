using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] GameObject EnemyPrefab;
  [SerializeField] float SpawnInterval = 3f;

  private int _spawnCount;
  private const int _spawnLimit = 50;

  // Use this for initialization
  void Start()
  {
    StartCoroutine(SpawnEnemy());
  }

  // Update is called once per frame
  void Update()
  {

  }

  private IEnumerator SpawnEnemy()
  {
    while (_spawnCount < _spawnLimit)
    {
      Instantiate(EnemyPrefab, transform);
      _spawnCount++;
      yield return new WaitForSeconds(SpawnInterval);
    }
  }
}
