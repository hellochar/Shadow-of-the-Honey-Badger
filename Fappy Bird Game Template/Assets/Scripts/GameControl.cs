using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //added to reset scenes
using UnityEngine.UI;


public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private int score = 0;

	// Use this for initialization
	void Awake ()
    {
		if( instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(gameOver == true&& Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //resets game
        }

	}

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();

    }



    public void BirdDied()
    {
        gameOverText.SetActive(true);       //switches text on screen to game over
        gameOver = true;                    //flags it to restart
    }




}
