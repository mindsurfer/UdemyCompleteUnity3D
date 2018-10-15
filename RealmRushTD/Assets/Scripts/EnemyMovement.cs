using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
  [SerializeField] float MoveInterval = 0.5f;

  private Pathfinder _pathFinder;
  private enum MoveDirection { Up, Right, Left, Down };

  // Use this for initialization
  void Start() 
  {
    _pathFinder = FindObjectOfType<Pathfinder>();
    var path = _pathFinder.GetPath();
    StartCoroutine(FollowPath(path));
  }

  private IEnumerator FollowPath(List<Waypoint> path)
  {
    foreach (var waypoint in path)
    {
      SetBodyRotation(waypoint);
      transform.position = waypoint.transform.position;
      yield return new WaitForSeconds(MoveInterval);
    }

    GetComponent<Enemy>().ProcessGoalFX();
  }

  private void SetBodyRotation(Waypoint waypoint)
  {
    var bodyTransform = transform.Find("Body");
    var moveDirection = GetMoveDirectionToPoint(waypoint);
    switch (moveDirection)
    {
      case MoveDirection.Up: bodyTransform.localEulerAngles = new Vector3(0f, 0f, 0f); break;
      case MoveDirection.Right: bodyTransform.localEulerAngles = new Vector3(0f, 90f, 0f); break;
      case MoveDirection.Left: bodyTransform.localEulerAngles = new Vector3(0f, -90f, 0f); break;
      case MoveDirection.Down: bodyTransform.localEulerAngles = new Vector3(0f, 180f, 0f); break;
    }
  }

  private MoveDirection GetMoveDirectionToPoint(Waypoint point)
  {
    var posDiff = point.transform.position - transform.position;
    if (posDiff.x > 0)
      return MoveDirection.Right;
    else if (posDiff.x < 0)
      return MoveDirection.Left;
    else if (posDiff.z > 0)
      return MoveDirection.Up;
    else return MoveDirection.Down;
  }
}
