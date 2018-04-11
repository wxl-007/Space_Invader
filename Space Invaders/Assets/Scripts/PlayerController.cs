using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Transform player;
	public float speed;
	public float maxBound,minBound;
	// Use this for initialization

	public GameObject shot;
	public Transform shotSpawn;
	public float rate;
	float nextFire;
	void Start () {
		player = gameObject.transform.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");
		if (player.position.x < minBound && h < 0)
			h = 0;
		else if (player.position.x > maxBound && h > 0)
			h = 0;
		player.position += Vector3.right*h*speed;
	}
	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + rate;
			GameObject.Instantiate (shot,shotSpawn.position,shotSpawn.rotation);
		}

	}
}
