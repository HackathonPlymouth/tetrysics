using UnityEngine;
using System.Collections;

public class WorldKillOffBlocksMP : MonoBehaviour {
	
	private int currentTriggerCount = 0;
	public int countToKill = 20;
	public bool isPlayer1;
	
	private GameObject[] allBlocks;
	
	void Update () {
		if (currentTriggerCount >= countToKill) {
			// Kill all the fuckers
			if (isPlayer1) {
				allBlocks = GameObject.FindGameObjectsWithTag("1P");
			} else {
				allBlocks = GameObject.FindGameObjectsWithTag("2P");
			}
			for (int i = 0; i < allBlocks.Length; i++) {
				if (allBlocks[i].GetComponent<BlockMovementController>().transform.position.y <= (transform.position.y + 1)) {
					if (allBlocks[i].GetComponent<BlockMovementController>().transform.position.y >= (transform.position.y - 1)) {
						allBlocks[i].GetComponent<BlockMovementController>().KillThisBlock();
						if (isPlayer1) {
							GameObject.Find("P1 World Manager").GetComponent<WorldManagerMP>().score += 10;
						} else {
							GameObject.Find("P2 World Manager").GetComponent<WorldManagerMP>().score += 10;
						}
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
