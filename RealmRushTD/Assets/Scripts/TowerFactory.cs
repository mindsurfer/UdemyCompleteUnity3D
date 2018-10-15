using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour 
{
  [SerializeField] int TowerLimit = 5;
  [SerializeField] Tower TowerPrefab;

  private Queue<Tower> _towers = new Queue<Tower>();

  public void AddTower(Waypoint waypoint)
  {
    if (_towers.Count >= 5)
      MoveExistingTower(waypoint);
    else
      CreateTower(waypoint);
  }

  private void MoveExistingTower(Waypoint waypoint)
  {
    var existingTower = _towers.Dequeue();

    existingTower.BaseWaypoint.IsPlaceable = true;

    existingTower.transform.position = waypoint.transform.position;
    waypoint.IsPlaceable = false;
    existingTower.BaseWaypoint = waypoint;
    _towers.Enqueue(existingTower);
  }

  private void CreateTower(Waypoint waypoint)
  {
    var parentTransform = GameObject.Find("Defenders");
    var tower = Instantiate(TowerPrefab, waypoint.transform.position, Quaternion.identity, parentTransform.transform);
    waypoint.IsPlaceable = false;
    tower.BaseWaypoint = waypoint;
    _towers.Enqueue(tower);
  }
}
