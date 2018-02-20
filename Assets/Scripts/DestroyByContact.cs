using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public GameController controller;

	void Start() {

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null) {
			//this ensures that we only get GameController associated with the thing
			//with GameController tag
			controller = gameControllerObject.GetComponent<GameController>();
		}
		if(controller == null) {
			Debug.Log("Cannot find GameController script");
		}

	}


	void OnTriggerEnter(Collider other) {
		if(other.tag != "Boundary") {

			Instantiate(explosion, transform.position, transform.rotation);
			if(other.tag=="Player") {
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				controller.GameOver();
			}

			controller.AddScore(scoreValue);
            Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}


}
