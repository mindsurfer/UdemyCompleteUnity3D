using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour 
{
  private void Awake()
  {
    var musicPlayerCount = FindObjectsOfType<MusicPlayer>().Length;
    if (musicPlayerCount == 1)
    {
      print("created");
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      print("destroyed");
      Destroy(gameObject);
    }
  }

  // Use this for initialization
  void Start () 
  {
    
  }

  // Update is called once per frame
  void Update () 
  {
    
  }
}
