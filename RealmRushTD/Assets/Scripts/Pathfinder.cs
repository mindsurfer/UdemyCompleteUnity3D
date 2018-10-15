using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour 
{
  [SerializeField] Waypoint StartPoint, EndPoint;

  private bool _isRunning;
  private Waypoint _searchCenter;
  private List<Waypoint> _path;

  private Dictionary<Vector2Int, Waypoint> _grid = new Dictionary<Vector2Int, Waypoint>();
  private Queue<Waypoint> _pathfindQueue = new Queue<Waypoint>();
  private readonly Vector2Int[] directions =
  {
    Vector2Int.up,
    Vector2Int.right,
    Vector2Int.down,
    Vector2Int.left
  };

  public List<Waypoint> GetPath()
  {
    if (_path != null && _path.Count > 0)
      return _path;

    LoadGridBlocks();
    ColorStartAndEnd();
    BreadthFirstSearch();
    CreatePath();

    return _path;
  }

  // Use this for initialization
  void Start() 
  {

  }

  // Update is called once per frame
  void Update() 
  {
    
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

  private void BreadthFirstSearch()
  {
    _pathfindQueue.Enqueue(StartPoint);
    _isRunning = true;

    while (_pathfindQueue.Count > 0 && _isRunning)
    {
      _searchCenter = _pathfindQueue.Dequeue();
      StopIfEnd();
      ExploreThyNeighbors();
    }
  }

  private void StopIfEnd()
  {
    if (_searchCenter.GetGridPos() == EndPoint.GetGridPos())
    {
      _isRunning = false;
    }
  }

  private void ExploreThyNeighbors()
  {
    foreach (var direction in directions)
    {
      var waypointLocation = _searchCenter.GetGridPos() + direction;
      if (_grid.ContainsKey(waypointLocation))
      {
        QueueNextNeighbour(waypointLocation);
      }
    }
    _searchCenter.IsExplored = true;
  }

  private void QueueNextNeighbour(Vector2Int waypointLocation)
  {
    var neighbour = _grid[waypointLocation];

    if (!neighbour.IsExplored && !_pathfindQueue.Contains(neighbour))
    {
      _pathfindQueue.Enqueue(neighbour);
      neighbour.ExploredFrom = _searchCenter;
    }
  }

  private void CreatePath()
  {
    _path = new List<Waypoint>();
    AddPathPoint(EndPoint);

    var previous = EndPoint.ExploredFrom;
    while (previous != StartPoint)
    {
      AddPathPoint(previous);
      previous = previous.ExploredFrom;
    }

    AddPathPoint(StartPoint);
    _path.Reverse();
  }

  private void AddPathPoint(Waypoint waypoint)
  {
    _path.Add(waypoint);
    waypoint.IsPlaceable = false;
  }
}
