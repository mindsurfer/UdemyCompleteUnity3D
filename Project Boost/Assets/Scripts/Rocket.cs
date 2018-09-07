﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour 
{
  private Rigidbody _rigidBody;

  // Use this for initialization
  void Start () 
  {
    _rigidBody = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update () 
  {
    ProcessInput();
  }

  private void ProcessInput()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      _rigidBody.AddRelativeForce(Vector3.up);
    }

    if (Input.GetKey(KeyCode.A))
      print("Rotating Left");
    else if (Input.GetKey(KeyCode.D))
      print("Rotating Right");
  }
}
