using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour 
{
  private Waypoint _waypoint;

  private void Awake()
  {
    _waypoint = GetComponent<Waypoint>();
  }

  // Update is called once per frame
  void Update()
  {
    SnapToGrid();
    UpdateLabel();
    //SetWaypointColor();
  }

  private void SnapToGrid()
  {
    var snapPos = _waypoint.GetSnapPos();
    transform.position = new Vector3(snapPos.x, 0f, snapPos.y);
  }

  private void UpdateLabel()
  {
    var gridSize = _waypoint.GetGridSize();
    var gridPos = _waypoint.GetGridPos();
    var labelText = GetComponentInChildren<TextMesh>();
    labelText.text = $"{gridPos.x},{gridPos.y}";
    gameObject.name = labelText.text;
  }

  //private void SetWaypointColor()
  //{
  //  if (_waypoint.IsStartPoint())
  //    _waypoint.SetTopColor(Color.green);
  //  else if (_waypoint.IsEndPoint())
  //    _waypoint.SetTopColor(Color.red);
  //  else
  //    _waypoint.SetTopColor(Color.grey);
  //}
}
