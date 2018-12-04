using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {

	public float deathForceLimit;
	private void OnCollisionEnter2D(Collision2D other)
	{
		float mag = other.relativeVelocity.magnitude;
		if (mag > deathForceLimit) 
			Dead();       
    }


	private void Dead() {
		print("Dead!");
		Destroy(gameObject);
	}
}
