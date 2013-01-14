using UnityEngine;
using System.Collections;

public class GameOverMP : MonoBehaviour {
	
	public GameObject prefab;
	private long score;
	private bool readyForSpaceBar;
	
	// Use this for initialization
	void Start () {
	
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
		Vector3 loc = new Vector3(-10f, 11.5f, 2f);
		Instantiate(prefab, loc, Quaternion.identity);
		Time.timeScale = 0;
		readyForSpaceBar = true;
	}
}
