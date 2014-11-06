using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject playerExplosion;
	public GameObject myExplosion;

	public int score;

	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		Debug.Log("Trigger enter " + other.tag);

		if (other.tag != "Boundary")
		{
			Instantiate(myExplosion,this.transform.position,this.transform.rotation);

			if(other.tag == "Player")
			{
				Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
				gameController.GameOver();
			}

			Destroy(other.gameObject);	
			Destroy(gameObject);

			gameController.AddScore(score);
		}
	}
}
