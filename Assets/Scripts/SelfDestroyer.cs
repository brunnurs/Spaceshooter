using UnityEngine;
using System.Collections;

public class SelfDestroyer : MonoBehaviour 
{
	public float lifetime;
	
	void Start () 
	{
		Destroy(this.gameObject,lifetime);
	}
}
