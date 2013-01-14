using UnityEngine;
using System.Collections;

public class WorldKillOffBlocks : MonoBehaviour {
	
	private int currentTriggerCount = 0;
	public int countToKill = 20;
	
	private GameObject[] allBlocks;
	
	void Start () {
		currentTriggerCount = 0;
	}
	
	void Update () {
		if (currentTriggerCount >= countToKill) {
			// Kill all the fuckers
			GameObject[] particles;
			particles = GameObject.FindGameObjectsWithTag("Particle");
			for (int i = 0; i < particles.Length; i++) {
				Destroy(particles[i]);
			}
			allBlocks = GameObject.FindGameObjectsWithTag("Block");
			for (int i = 0; i < allBlocks.Length; i++) {
				if (allBlocks[i].GetComponent<BlockMovementController>().transform.position.y <= (transform.position.y + 1)) {
					if (allBlocks[i].GetComponent<BlockMovementController>().transform.position.y >= (transform.position.y - 1)) {
						allBlocks[i].GetComponent<BlockMovementController>().KillThisBlock();
						GameObject.Find("World Manager").GetComponent<WorldManager>().score += 10;
					}
				}
			}
			currentTriggerCount = 0;
		}
	}
	
	void OnTriggerEnter () {
		currentTriggerCount++;
	}
	
	void OnTriggerExit () {
		currentTriggerCount--;
	}
}
