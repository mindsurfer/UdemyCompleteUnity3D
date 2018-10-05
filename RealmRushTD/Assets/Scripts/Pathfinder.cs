using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour 
{
  [SerializeField] Waypoint StartPoint, EndPoint;

  private bool _isRunning;

  private Dictionary<Vector2Int, Waypoint> _grid = new Dictionary<Vector2Int, Waypoint>();
  private Queue<Waypoint> _pathfindQueue = new Queue<Waypoint>();
  private readonly Vector2Int[] directions =
  {
    Vector2Int.up,
    Vector2Int.right,
    Vector2Int.down,
    Vector2Int.left
  };

  // Use this for initialization
  void Start() 
  {
    LoadGridBlocks();
    ColorStartAndEnd();
    Pathfind();
    //ExploreThyNeighbors();
  }


  // Update is called once per frame
  void Update() 
  {
    
  }

  private void Pathfind()
  {
    _pathfindQueue.Enqueue(StartPoint);
    _isRunning = true;

    while (_pathfindQueue.Count > 0 && _isRunning)
    {
      var point = _pathfindQueue.Dequeue();
      if (point.GetGridPos() == EndPoint.GetGridPos())
      {
        StopIfEnd();
      }
      else
        print("you'll do fookin nootun");
    }
  }

  private void StopIfEnd()
  {
    print("Found end point");
    _isRunning = false;
  }

  private void ExploreThyNeighbors()
  {
    foreach (var direction in directions)
    {
      var waypointLocation = StartPoint.GetGridPos() + direction;
      if (_grid.ContainsKey(waypointLocation))
        _grid[waypointLocation].SetTopColor(Color.blue);
    }
  }

  private void LoadGridBlocks()
  {
    var waypoints = FindObjectsOfType<Waypoint>();
    foreach (var waypoint in waypoints)
    {
      var gridPos = waypoint.GetGridPos();
      if (!_grid.ContainsKey(gridPos))
        _grid[gridPos] = waypoint;
    }
  }

  private void ColorStartAndEnd()
  {
    StartPoint.SetTopColor(Color.green);
    EndPoint.SetTopColor(Color.red);
  }
}
