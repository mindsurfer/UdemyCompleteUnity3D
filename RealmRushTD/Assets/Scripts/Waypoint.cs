using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour 
{
  public bool IsExplored;
  public Waypoint ExploredFrom;
  public bool IsPlaceable = true;

  const int GridSize = 10;

  private Vector2Int _gridPos;

  public int GetGridSize()
  {
    return GridSize;
  }

  public Vector2Int GetGridPos()
  {
    return new Vector2Int(
      Mathf.RoundToInt(transform.position.x / GridSize),
      Mathf.RoundToInt(transform.position.z / GridSize)
    );
  }

  public Vector2Int GetSnapPos()
  {
    var gridPos = GetGridPos();
    return new Vector2Int(
      gridPos.x * GridSize,
      gridPos.y * GridSize
      );
  }

  // Use this for initialization
  void Start() 
  {
    
  }
  
  // Update is called once per frame
  void Update() 
  {
    
  }

  private void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(0) && IsPlaceable)
    {
      FindObjectOfType<TowerFactory>().AddTower(this);
    }
  }

  public void SetTopColor(Color color)
  {
    var cubeTop = transform.Find("Top");
    cubeTop.GetComponent<MeshRenderer>().material.color = color;
  }
}
