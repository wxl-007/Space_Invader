using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCtrl : MonoBehaviour {
	Transform bulletObj;
	public float speed=0.3f;

	// Use this for initialization
	void Start () {
		bulletObj = GetComponent<Transform> ();	
	}

	void FixedUpdate(){

		bulletObj.position += Vector3.up * -speed;
		if (bulletObj.position.y >= 10 || bulletObj.position.y<-6) {
			Destroy (gameObject);
		}

	}
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Player") {
			Destroy (gameObject);
			Destroy (other.gameObject);
			GameController.playerScore += 10;
		}
		else if (other.tag == "Base") {
			Destroy (gameObject);
			Base tBaseHealth =	other.gameObject.GetComponent<Base> ();
			tBaseHealth.baseHealth -= 1;
		}

	}

}
