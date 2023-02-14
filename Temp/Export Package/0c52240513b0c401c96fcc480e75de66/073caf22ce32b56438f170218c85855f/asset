using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public static LevelController instance;

	public Text scoreText;
	public GameObject gameOverPanel;
	public bool gameOver;

	private int score;
	private void Awake()
	{
		instance = this;
	}
	

	public void SetScore()
	{
		score++;
		if(scoreText != null)
			scoreText.text = score.ToString();
	}

	public void GameOver()
	{
		if(gameOverPanel != null)
			gameOverPanel.SetActive(true);

		gameOver = true;
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
