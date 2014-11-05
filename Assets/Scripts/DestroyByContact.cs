﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject astroidExplosion;
	public GameObject playerExplosion;

	public int scoreOfAstroid;

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
		if (other.tag != "Boundary")
		{
			Instantiate(astroidExplosion,this.transform.position,this.transform.rotation);

			if(other.tag == "Player")
			{
				Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
				gameController.GameOver();
			}

			Destroy(other.gameObject);	
			Destroy(gameObject);

			gameController.AddScore(scoreOfAstroid);
		}
	}
}