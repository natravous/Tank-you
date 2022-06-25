using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instance
  public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else if (Instance == this) { Destroy(this); }

        DontDestroyOnLoad(gameObject);
    }

    public int score = 0; // Increase when player destroy enemy
    public float shoot_speed = .8f; // Shoots per second

    public TextMesh scoreboard;

    // Add Score
    public void AddScores(int score_to_add)
    {
        // increase score
        score += score_to_add;
        // change score text
        scoreboard.text = AddZeros();
    }

    public string AddZeros()
    {
        // pattern 0000
        if (score < 10) { return "000" + score; }
        if (score < 100) { return "00" + score; }
        if (score < 1000) { return "0" + score; }
        if (score < 10000) { return score.ToString(); }

        return "0000";
    }

    public void GameOver()
    {
        // Game over
    }

}
