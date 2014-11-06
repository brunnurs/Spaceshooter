using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {

		public GameObject playerExplosion;
		
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
				if(other.tag == "Player")
				{
					Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
					gameController.GameOver();
				}
				
				Destroy(other.gameObject);	
				Destroy(gameObject);
			}
		}
}
