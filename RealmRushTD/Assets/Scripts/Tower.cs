using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour 
{
  public Waypoint BaseWaypoint;

  [SerializeField] Transform ObjectToPan;
  [SerializeField] float AttackRange = 40f;

  private Transform _targetToFocus;
  private ParticleSystem _bullets;

  void Start()
  {
    _bullets = GetComponentInChildren<ParticleSystem>(true);
  }

  // Update is called once per frame
  void Update() 
  {
    SetTarget();
    LookAtTarget();
    FireAtTarget();
  }

  private void SetTarget()
  {
    var sceneEnemies = FindObjectsOfType<Enemy>();
    if (sceneEnemies.Length == 0) { return; }

    var currentClosestEnemy = sceneEnemies[0].transform;
    foreach (var enemy in sceneEnemies)
    {
      var currentDistance = Vector3.Distance(currentClosestEnemy.transform.position, transform.position);
      var enemyDistance = Vector3.Distance(enemy.transform.position, transform.position);
      currentClosestEnemy = currentDistance < enemyDistance ? currentClosestEnemy : enemy.transform;
    }

    _targetToFocus = currentClosestEnemy;
  }

  private void LookAtTarget()
  {
    ObjectToPan.LookAt(_targetToFocus);
  }

  private void FireAtTarget()
  {
    var emissionComponent = _bullets.emission;
    emissionComponent.enabled = IsTargetInRange();
  }

  private bool IsTargetInRange()
  {
    if (!IsTargetAlive())
      return false;

    var distanceToTarget = Vector3.Distance(_targetToFocus.position, transform.position);
    return distanceToTarget <= AttackRange;
  }

  private bool IsTargetAlive()
  {
    return _targetToFocus != null;
  }
}
