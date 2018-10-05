using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
  [SerializeField] GameObject DeathFX;
  [SerializeField] Transform Parent;
  [SerializeField] int ScoreValue = 75;
  [SerializeField] int MaxHits = 10;

  // Use this for initialization
  void Start () 
  {
    
  }

  // Update is called once per frame
  void Update () 
  {
    
  }

  private void OnParticleCollision(GameObject other)
  {
    HandleDeath();
  }

  private void HandleDeath()
  {
    MaxHits--;

    if (MaxHits >= 1) return;

    var deathFx = Instantiate(DeathFX, transform.position, Quaternion.identity);
    deathFx.gameObject.transform.parent = Parent;
    Destroy(gameObject);

    // update score
    var scoreBoard = FindObjectOfType<ScoreBoard>();
    scoreBoard?.AddScore(ScoreValue);
  }
}
