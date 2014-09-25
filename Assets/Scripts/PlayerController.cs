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

	void FixedUpdate()
	{
		float movementHorizontal = Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(movementHorizontal,0.0f,movementVertical);

		rigidbody.velocity = movement * speed;

		ClampPosition ();
	}

	void ClampPosition ()
	{
		float clampedX = Mathf.Clamp (transform.position.x, boundaries.xMin, boundaries.xMax);
		float clampedZ = Mathf.Clamp (transform.position.z, boundaries.zMin, boundaries.zMax);

		transform.position = new Vector3 (clampedX, 0.0f, clampedZ);
	}
}
