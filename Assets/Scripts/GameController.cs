using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText gameOverText;

	private int scoreValue;

	private bool isGameRunning;

	void Start () 
	{
		gameOverText.text = "";
		InitializeScore ();

		isGameRunning = true;
		StartCoroutine(SpawnWaves());
	}

	void Update ()
	{
		if (!isGameRunning)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (isGameRunning)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);
		}
	}

	void InitializeScore ()
	{
		scoreValue = 0;
		ShowScore ();
	}

	void ShowScore()
	{
		scoreText.text = "Current Score: " + scoreValue;
	}

	public void AddScore(int score)
	{
		this.scoreValue += score;
		ShowScore();
	}

	public void GameOver()
	{
		isGameRunning = false;
		gameOverText.text = "Game Over! Press 'R' to restart";
	}
}
