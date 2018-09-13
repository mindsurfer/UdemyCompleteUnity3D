using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct MyParticleSystems
{
  [SerializeField] ParticleSystem MainEngineParticles;
  [SerializeField] ParticleSystem DeathParticles;
  [SerializeField] ParticleSystem SuccessParticles;
}

public class Rocket : MonoBehaviour 
{
  [SerializeField] float ThrustSpeed = 1500f;
  [SerializeField] float RotateSpeed = 100f;
  [SerializeField] float LevelLoadDelay = 2f;
  [SerializeField] AudioClip MainEngine;
  [SerializeField] AudioClip Death;
  [SerializeField] AudioClip Success;
  [SerializeField] ParticleSystem MainEngineParticles;
  [SerializeField] ParticleSystem DeathParticles;
  [SerializeField] ParticleSystem SuccessParticles;

  enum State
  {
    Alive,
    Dying,
    Transcending
  }

  private Rigidbody _rigidBody;
  private AudioSource _audioSource;

  private State _state = State.Alive;
  private bool _isThrusting;
  
  // Use this for initialization
  void Start() 
  {
    _rigidBody = GetComponent<Rigidbody>();
    _audioSource = GetComponent<AudioSource>();

    _state = State.Alive;
  }

  // Update is called once per frame
  void Update () 
  {
    if (_state == State.Alive)
    {
      Thrust();
      Rotate();
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (_state != State.Alive)
      return;

    switch(collision.gameObject.tag)
    {
      case "Friendly": print("OK"); break;
      case "Finish":
        ProcessSuccess();
        break;
      default:
        ProcessDeath();
        break;
    }
  }

  private void ProcessSuccess()
  {
    _state = State.Transcending;
    _audioSource.Stop();
    _audioSource.PlayOneShot(Success);
    SuccessParticles.Play();
    Invoke("LoadNextScene", LevelLoadDelay);
  }

  private void ProcessDeath()
  {
    _state = State.Dying;
    _audioSource.Stop();
    _audioSource.PlayOneShot(Death, 0.2f);
    DeathParticles.Play();
    Invoke("LoadFirstScene", LevelLoadDelay);
  }

  private void LoadFirstScene()
  {
    SceneManager.LoadScene(0);
  }

  private void LoadNextScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  private void Thrust()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      _rigidBody.AddRelativeForce(Vector3.up * ThrustSpeed * Time.deltaTime);
      if (!_audioSource.isPlaying)
        _audioSource.PlayOneShot(MainEngine);
      MainEngineParticles.Play();
    }
    else
    {
      _audioSource.Stop();
      MainEngineParticles.Stop();
    }
  }

  private void Rotate()
  {
    //if (!_isThrusting)
    //  return;

    // Another method of freezing the movement and rotation along axes
    transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z);

    _rigidBody.freezeRotation = true; // Take manual control of rotation

    if (Input.GetKey(KeyCode.A))
    {
      transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);  // positive Z rotates left
    }
    else if (Input.GetKey(KeyCode.D))
    {
      transform.Rotate(-Vector3.forward * RotateSpeed * Time.deltaTime);  // negative Z rotates right
    }

    _rigidBody.freezeRotation = false; // Set rotation control back to physics
  }
}
