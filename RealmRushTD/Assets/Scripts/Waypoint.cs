using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour 
{
  //[SerializeField] bool StartPoint = false;
  //[SerializeField] bool EndPoint = false;

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

  //public bool IsStartPoint()
  //{
  //  return StartPoint;
  //}

  //public bool IsEndPoint()
  //{
  //  return EndPoint;
  //}

  // Use this for initialization
  void Start() 
  {
    
  }
  
  // Update is called once per frame
  void Update() 
  {
    
  }

  public void SetTopColor(Color color)
  {
    var cubeTop = transform.Find("Top");
    cubeTop.GetComponent<MeshRenderer>().material.color = color;
  }
}
