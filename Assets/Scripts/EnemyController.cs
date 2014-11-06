using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public Transform spawnPosition;
	
	public GameObject bolt;
	
	public float fireRate;
	
	private float nextShot;
	
	
	void Update()
	{
		if(Time.time > nextShot)
		{
			nextShot = Time.time + fireRate;
			GameObject copy = (GameObject)Object.Instantiate(bolt,spawnPosition.position,spawnPosition.rotation);
			audio.Play();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
}
