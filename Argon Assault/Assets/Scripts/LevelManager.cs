using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{

  // Use this for initialization
  void Start () 
  {
    var loadFirstLevel = StartCoroutine(LoadFirstLevel());
  }

  public void LoadLevel(int levelIndex)
  {
    SceneManager.LoadScene(levelIndex);
  }

  private IEnumerator LoadFirstLevel()
  {
    yield return new WaitForSecondsRealtime(3f);
    LoadLevel(1);
  }
}
