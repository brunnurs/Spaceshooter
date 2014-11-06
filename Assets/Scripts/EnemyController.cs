using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	public Transform spawnPosition;
	
	public GameObject bolt;
	
	public float fireRate;

	public float firstShootAfter;

	private float nextShot;

	void Start()
	{
		nextShot = Time.time + firstShootAfter;
	}

	void Update()
	{
		if(Time.time > nextShot)
		{
			nextShot = Time.time + fireRate;
			GameObject copy = (GameObject)Object.Instantiate(bolt,spawnPosition.position,spawnPosition.rotation);
			audio.Play();
		}
	}
}
