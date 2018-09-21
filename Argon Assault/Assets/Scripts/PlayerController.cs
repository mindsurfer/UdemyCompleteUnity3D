using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour 
{
  [SerializeField] float MoveSpeed = 20f;
  [SerializeField] float MoveRangeX = 5f;
  [SerializeField] float MoveRangeY = 2.5f;
  [SerializeField] float PositionPitchFactor = -5f;
  [SerializeField] float ControlPitchFactor = -30f;
  [SerializeField] float PositionYawFactor = 5f;
  [SerializeField] float ControlYawFactor = 10f;
  [SerializeField] float ControlRollFactor = -30f;

  private float xThrow, yThrow;
  private bool _controlDisabled = false;

  // Use this for initialization
  void Start () 
  {
    
  }

  // Update is called once per frame
  void Update ()
  {
    if (_controlDisabled) return;

    ProcessTranslation();
    ProcessRotation();
  }

  private void OnTriggerEnter(Collider other)
  {
    print("Triggered with something");
  }

  private void ProcessTranslation()
  {
    xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
    yThrow = CrossPlatformInputManager.GetAxis("Vertical");
    var xOffset = xThrow * MoveSpeed * Time.deltaTime;
    var yOffset = yThrow * MoveSpeed * Time.deltaTime;

    var newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -MoveRangeX, MoveRangeX);
    var newYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -MoveRangeY, MoveRangeY);

    transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
  }

  private void ProcessRotation()
  {
    var pitchDueToPosition = transform.localPosition.y * PositionPitchFactor;
    var pitchDueToControlThrow = yThrow * ControlPitchFactor;
    var pitch = pitchDueToPosition + pitchDueToControlThrow;

    var yawDueToPosition = transform.localPosition.x * PositionYawFactor;
    var yawDueToControlThrow = xThrow * ControlYawFactor;
    var yaw = yawDueToPosition + yawDueToControlThrow;

    var roll = xThrow * ControlRollFactor;

    transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
  }

  private void OnPlayerDeath()
  {
    _controlDisabled = true;
  }
}
