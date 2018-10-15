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

  void Update()
  {
    SnapToGrid();
    UpdateLabel();
  }

  private void SnapToGrid()
  {
    var snapPos = _waypoint.GetSnapPos();
    transform.position = new Vector3(snapPos.x, 0f, snapPos.y);
  }

  private void UpdateLabel()
  {
    var gridPos = _waypoint.GetGridPos();
    var labelText = GetComponentInChildren<TextMesh>();
    labelText.text = $"{gridPos.x},{gridPos.y}";
    gameObject.name = labelText.text;
  }
}
