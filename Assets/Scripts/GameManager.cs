using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  // Instance
  public static GameManager Instance { get; private set; }
    // Init
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else if (Instance == this) { Destroy(this); }

        DontDestroyOnLoad(gameObject);
    }

    /** 
     * =================
     * Global Variables
     * =================
     */

    // Game Stats
    public int initial_enemies = 2;  // Enemies per one spawn
    public GameObject scoreboard; // Scoreboard

    // Player (Tank) Stats
    public int score = 0; // Increase when player destroy enemy
    public float shoot_speed = .8f; // Shoots per second
    public float shoot_velocity = .1f; // Speeds of a shoot
    public float sensitivity = 1.0f; // Move sensitivity
    public float maximum_shoot_angle = 0.35f; // Rotation limitation (in z rotation)
    public Transform tank_position;
    public bool activate_helper = false;

    // Enemy Stats
    public float enemy_spd = .05f; // Enemy speed [scaled once more in instantiate]
    public float spawner_cd = 2.0f; // Cooldown for enemy spawner
    
    /**
     * ================
     * Global Functions
     * ================
     */

    // Add Score to user stats and refresh scoreboard
    public void AddScores(int score_to_add)
    {
        score += score_to_add; // Add (n) to user score
        TMP_Text txt = scoreboard.GetComponent<TMP_Text>();
        txt.text = AddZeros(); // Convert based on template before change scoreboard
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
        Debug.Log("GAME OVER");
        Application.Quit();
    }

}
