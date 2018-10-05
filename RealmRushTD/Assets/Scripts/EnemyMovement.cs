using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
  [SerializeField] List<Waypoint> Path;

  // Use this for initialization
  void Start() 
  {
    //StartCoroutine(FollowPath());
  }
  
  // Update is called once per frame
  void Update() 
  {
    
  }

  private IEnumerator FollowPath()
  {
    foreach (var waypoint in Path)
    {
      transform.position = waypoint.transform.position;
      yield return new WaitForSeconds(1f);
    }
  }
}
