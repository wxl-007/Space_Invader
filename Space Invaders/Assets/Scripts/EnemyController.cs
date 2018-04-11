using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	Transform enemyHolder;
	public float speed;
	public GameObject shot;
	public Text winText;
	float fireRate =0.980f;
	Transform[] enemyList = new Transform[5];
	bool isRun = false;

	void Start () {
		winText.gameObject.SetActive(false);
		enemyHolder = GetComponent<Transform> ();
		for (int i = 0; i < 5; i++) {
			enemyList [i] = enemyHolder.Find ("Line_"+(i+1));
			Debug.Log (enemyList[i].name);
		}
		StartCoroutine (MoveEnemy ());
		isRun = true;
	}
	IEnumerator MoveEnemy(){
		while (true) {
			foreach (Transform enemyRow in enemyList) {
				yield return new WaitForSeconds (0.2f);
				enemyRow.position += Vector3.right * speed;
				if (enemyRow.position.x < -1.5 || enemyRow.position.x > 1.5f) {
					speed += 0.05f;
					speed = -speed;
					enemyHolder.position += Vector3.down * 0.5f;

				}
				if (enemyHolder.position.y <= -3) {
					GameController.isDead = true;
					Time.timeScale = 0;
				}
				foreach (Transform enemy in enemyRow) {
					if (Random.value > fireRate) {
						Instantiate (shot, enemy.position, enemy.rotation);
					}
				}

			}
			if (isRun == false)
				break;
			yield return new WaitForSeconds (0.2f);
		}
		if (enemyHolder.childCount == 1) {
		}
		if (enemyList.Length == 0) {
			isRun = false;
			winText.gameObject.SetActive(true);
		}
			
	}


	// Update is called once per frame
	void Update () {
		
	}
}
