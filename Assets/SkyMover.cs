using UnityEngine;
using System.Collections;

public class SkyMover : MonoBehaviour {

	Rigidbody2D player;

	void Start () {
		GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		
		if (playerGameObject == null) {
			Debug.LogError("Couldn't find an object with tag 'Player'!");
			return;
		}
		
		player = playerGameObject.rigidbody2D;		
	}

	void FixedUpdate () {
		float vel = player.velocity.x * 0.75f;
		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
	}
}
