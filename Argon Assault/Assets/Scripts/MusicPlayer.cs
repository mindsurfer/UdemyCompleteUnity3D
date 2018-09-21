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
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }
}
