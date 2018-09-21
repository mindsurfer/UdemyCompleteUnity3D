using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
  private void Awake()
  {
    DontDestroyOnLoad(gameObject);
  }

  // Use this for initialization
  void Start () 
  {
    var loadFirstLevel = StartCoroutine(LoadFirstLevel(3f));
  }

  public void LoadLevel(int levelIndex)
  {
    SceneManager.LoadScene(levelIndex);
  }

  public IEnumerator LoadFirstLevel(float waitDelay)
  {
    yield return new WaitForSecondsRealtime(waitDelay);
    LoadLevel(1);
  }
}
