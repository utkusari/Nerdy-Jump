using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    
	public int numberOfPlatforms = 200;
	public float levelWidth = 3f;
	public float minY = .2f;
	public float maxY = 1.5f;

	int minGoal = 10;
	int maxGoal = 20;

	int index = 0;

	public Text goalNumbertext;
	public Text currentNumberText;
	public Text levelCounterText;
	public Text timer;
	public Text finalScore;
	public Text pauseScore;

	public GameObject gameOverPanel;
	public GameObject pauseMenu;

	int goalNumber;
	int level = 1;
	public int currentNumber = 0;

	public GameObject[] platforms;


	public AudioClip gameOver;
  	public AudioClip levelUp;
  	AudioSource audioSource;

	// Use this for initialization
	void Start () {

		Time.timeScale = 1.0f;

		audioSource = GetComponent<AudioSource>();

		goalNumber = Random.Range(minGoal, maxGoal);
		goalNumbertext.text = goalNumber.ToString();
		currentNumberText.text = currentNumber.ToString();
		levelCounterText.text = level.ToString();

		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++)
		{
			index = Random.Range(0, 21);
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			Instantiate(platforms[index], spawnPosition, Quaternion.identity);
		}     
	}

	void Update() {

		currentNumberText.text = currentNumber.ToString();

		if (Input.GetKeyDown("escape")){
			Time.timeScale = 0.0f;
			pauseMenu.SetActive(true);
			pauseScore.text = level.ToString();
		}

		if (currentNumber == goalNumber){
			maxGoal = maxGoal + 10;
			minGoal = minGoal + 10;
			goalNumber = Random.Range(minGoal, maxGoal);
			goalNumbertext.text = goalNumber.ToString();
			level++;
			if (level > PlayerPrefs.GetInt("HighestScore", 0)){
				PlayerPrefs.SetInt("HighestScore", level);
			}
			audioSource.PlayOneShot(levelUp, 0.5f);
			levelCounterText.text = level.ToString();
			timer.GetComponent<Countdown>().currentTime = timer.GetComponent<Countdown>().currentTime + 10f;
		}
		if (timer.GetComponent<Countdown>().currentTime == 0f){
			GameOver();
		}

	}

	void GameOver(){
		Time.timeScale = 0.0f;
		audioSource.PlayOneShot(gameOver, 0.5f);
		gameOverPanel.SetActive(true);
		finalScore.text = level.ToString();
	}

}
