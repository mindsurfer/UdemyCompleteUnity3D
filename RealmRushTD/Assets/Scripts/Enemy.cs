using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
  [SerializeField] Collider CollisionMesh;
  [SerializeField] int HitPoints = 10;
  [SerializeField] ParticleSystem HitFX;
  [SerializeField] ParticleSystem DeathFX;
  [SerializeField] ParticleSystem GoalFX;

  private void OnParticleCollision(GameObject other)
  {
    ProcessHit();
  }

  public void ProcessGoalFX()
  {
    var goalFx = Instantiate(GoalFX, transform.position, Quaternion.identity);
    goalFx.Play();
    Destroy(goalFx.gameObject, goalFx.main.duration);
    Destroy(gameObject);
  }

  private void ProcessHit()
  {
    HitPoints--;
    HitFX.Play();
    if (HitPoints <= 0)
    {
      print("you got me mother fucker!");
      var deathFx = Instantiate(DeathFX, transform.position, Quaternion.identity);
      var destroyDelay = deathFx.main.duration;
      deathFx.Play();
      Destroy(gameObject);
      Destroy(deathFx.gameObject, destroyDelay);
    }
  }
}
