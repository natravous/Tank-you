using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //public static MenuManager Instance { get; private set; }

    public GameObject pausePanel;

    public bool isPause;

    //private void Awake()
    //{
    //    if (Instance == null) { Instance = this; }
    //    else if (Instance == this) { Destroy(this); }

    //    DontDestroyOnLoad(gameObject);
    //}
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPause = false;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPause = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
