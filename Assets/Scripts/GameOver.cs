using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public GameObject prefab;
	private long score;
	private bool readyForSpaceBar;
	
	// Use this for initialization
	void Start () {
		readyForSpaceBar = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (readyForSpaceBar && Input.GetKey(KeyCode.Space)) {
			Application.LoadLevel(0);
		}
		
		if (Input.GetKey(KeyCode.T)) {
			GameOverNow();
		}
	}
	
	void OnTriggerEnter (Collider col) {
		if (col.GetComponent<BlockMovementController>().hasTouchedWorld) {
			GameOverNow ();
		}
	}
	
	void GameOverNow () {
		score = GameObject.Find ("World Manager").GetComponent<WorldManager>().score;
		Debug.Log ("GAME OVER! Score: " + score.ToString() + ", Time: " + Time.time.ToString());
		Instantiate(prefab);
		Time.timeScale = 0;
		readyForSpaceBar = true;
	}
}
