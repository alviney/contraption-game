using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

	public float force;
	// Use this for initialization
	void Start () {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		rb.AddForce(new Vector2(0, force * 100));
	}
	
	
}
