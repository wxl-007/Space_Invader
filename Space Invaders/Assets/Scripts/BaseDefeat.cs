using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefeat : MonoBehaviour {


	Transform playerBase;
	// Use this for initialization
	void Start () {
		playerBase = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if (playerBase.childCount == 0)
			GameController.isDead = true;
	}
}
