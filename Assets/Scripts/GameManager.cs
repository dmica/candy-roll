using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject gameOverPanel;

    public Text scoreText;

    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        ObstacleSpawner.instance.gameOver = true;
        //on game over stop scrolling background and ground
        StopScrolling();
        //show game over panel
        gameOverPanel.SetActive(true);
    }

    void StopScrolling()
    {
        //array of scrolls, storing all objects that have Scroll script attached to them
        Scroll[] scrollingObjects = FindObjectsOfType<Scroll>();

        foreach (Scroll t in scrollingObjects)
        {
            //stop scrolling background and ground
            t.scrollOffset = 0;
        }
    }

    //adding functionality to restart button
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void IncrimentScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
