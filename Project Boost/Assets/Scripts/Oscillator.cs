using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour 
{
  [SerializeField] Vector3 MovementVector = new Vector3(10f, 10f, 10f);
  [SerializeField] float Period = 2f; //Time it takes to complete a full cycle

  [Range(0f, 1f)]
  [SerializeField]
  float MovementFactor;   // 0 for not moved, 1 for fully moved

  private Vector3 _startPos;

  // Use this for initialization
  void Start () 
  {
    _startPos = transform.position;
  }

  // Update is called once per frame
  void Update () 
  {
    if (Period <= Mathf.Epsilon) return;

    var cycles = Time.time / Period;  // grows continually from 0
    const float tau = Mathf.PI * 2f;   // about 6.28
    var rawSinWave = Mathf.Sin(cycles * tau);

    MovementFactor = rawSinWave / 2f + 0.5f;
    var offset = MovementVector * MovementFactor;
    transform.position = _startPos + offset;
  }
}
