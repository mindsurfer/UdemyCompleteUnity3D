using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour 
{
  private int _score;
  private Text _scoreText;

  // Use this for initialization
  void Start () 
  {
    _scoreText = GetComponent<Text>();
    if (_scoreText)
      _scoreText.text = _score.ToString();
  }

  public void AddScore(int score)
  {
    _score += score;
    _scoreText.text = _score.ToString();
  }
}
