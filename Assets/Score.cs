using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score = 0;
	static int highScore = 0;

	static Score instance;

	public static void AddPoint() {
		if (instance.bird.dead)
			return;

		score++;

		if (score > highScore) {
			highScore = score;
		}
	}

	BirdMovement bird;

	void Start() {
		instance = this;

		GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player");

		if (playerGameObject == null) {
			Debug.LogError("Could not find an object with tag 'Player'");
		}

		bird = playerGameObject.GetComponent<BirdMovement> ();
		score = 0;
		highScore = PlayerPrefs.GetInt ("highScore", 0);
	}

	void OnDestroy() {
		instance = null;

		PlayerPrefs.SetInt ("highScore", highScore);
	}

	// Update is called once per frame
	void Update () {
		guiText.text = "Score: " + score + "\nHigh Score: " + highScore;
	}
}
