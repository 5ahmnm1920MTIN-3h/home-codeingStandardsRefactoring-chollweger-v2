﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;
    const string mainScene = "MainScene";
    const string menuScene = "MenuScene";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("in Start");   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("in Update");
    }

    public void GameOver()
    {
        ObstacleSpawner.instance.isGameOver = true;
        StopScrolling();
        gameOverPanel.SetActive(true);
    }

    void StopScrolling()
    {
        TextureScroll[] scrollingObjects = FindObjectsOfType<TextureScroll>();

        foreach(TextureScroll item in scrollingObjects)
        {
            item.scrollBackground = false;
            Debug.Log(item.name);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("menuScene");
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
