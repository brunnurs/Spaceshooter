using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;

	public Boundary boundaries;

	public float tilt;

	public GameObject bolt;

	public Transform spawnPosition;

	public float fireRate;

	private float nextShot;


	void Update()
	{
		if(Input.GetButton("Fire1") && Time.time > nextShot)
		{
			nextShot = Time.time + fireRate;
			GameObject copy = (GameObject)Object.Instantiate(bolt,spawnPosition.position,spawnPosition.rotation);
		}
	}

	void FixedUpdate()
	{
		float movementHorizontal = Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(movementHorizontal,0.0f,movementVertical);

		rigidbody.velocity = movement * speed;

		ClampPosition ();

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);

	}

	void ClampPosition ()
	{
		float clampedX = Mathf.Clamp (transform.position.x, boundaries.xMin, boundaries.xMax);
		float clampedZ = Mathf.Clamp (transform.position.z, boundaries.zMin, boundaries.zMax);

		transform.position = new Vector3 (clampedX, 0.0f, clampedZ);
	}
}
