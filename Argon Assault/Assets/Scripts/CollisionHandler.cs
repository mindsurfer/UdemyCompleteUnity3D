using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour 
{
  [SerializeField] float LevelLoadDelay = 1f;
  [SerializeField] GameObject DeathFX;

  // Use this for initialization
  void Start () 
  {
    
  }

  // Update is called once per frame
  void Update () 
  {
    
  }

  private void OnTriggerEnter(Collider other)
  {
    StartDeathSequence();
  }

  private void StartDeathSequence()
  {
    SendMessage("OnPlayerDeath");
    DeathFX.SetActive(true);
    StartCoroutine(ReloadScene());
  }

  private IEnumerator  ReloadScene()
  {
    yield return new WaitForSecondsRealtime(LevelLoadDelay);
    SceneManager.LoadScene(1);
  }
}
