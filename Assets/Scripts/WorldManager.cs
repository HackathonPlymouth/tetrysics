using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {
	
	public GameObject[] activeBlocks = new GameObject[4];
	public GameObject prefab;
	public float velocityMagnification;
	
	public Vector3 spawnOffset = new Vector3(-1, 25, 0);
	private bool createNewShapeNow = true;
	
	public long score = 0;
	
	void Start () {
		
	}
	
	void CreateShape () {
		createNewShapeNow = false;
		// Clear the object array
		for (int i = 0; i < 4; i++) {
			activeBlocks[i] = null;
		}
		
		/* RANDOM BLOCKS:
		 * 0 - I Block
		 * 1 - L Block
		 * 2 - T Block
		 * 3 - O Block
		 * 4 - S Block
		 */
		
		int rand = Random.Range(0,5);
		
		if (rand == 0) {
			// I Block
			activeBlocks[0] = CreateBlock(1,3, Color.cyan);
			activeBlocks[1] = CreateBlock(1,2, Color.cyan);
			activeBlocks[2] = CreateBlock(1,1, Color.cyan);
			activeBlocks[3] = CreateBlock(1,0, Color.cyan);
		} else if (rand == 1) {
			// L Block
			activeBlocks[0] = CreateBlock(1,3, Color.blue);
			activeBlocks[1] = CreateBlock(1,2, Color.blue);
			activeBlocks[2] = CreateBlock(1,1, Color.blue);
			activeBlocks[3] = CreateBlock(2,1, Color.blue);
		} else if (rand == 2) {
			// T Block
			activeBlocks[0] = CreateBlock(1,1, Color.magenta);
			activeBlocks[1] = CreateBlock(1,2, Color.magenta);
			activeBlocks[2] = CreateBlock(2,2, Color.magenta);
			activeBlocks[3] = CreateBlock(0,2, Color.magenta);
		} else if (rand == 3) {
			// O Block
			activeBlocks[0] = CreateBlock(1,1, Color.yellow);
			activeBlocks[1] = CreateBlock(1,2, Color.yellow);
			activeBlocks[2] = CreateBlock(2,2, Color.yellow);
			activeBlocks[3] = CreateBlock(2,1, Color.yellow);
		} else if (rand == 4) {
			// S Block
			activeBlocks[0] = CreateBlock(2,2, Color.green);
			activeBlocks[1] = CreateBlock(1,2, Color.green);
			activeBlocks[2] = CreateBlock(1,1, Color.green);
			activeBlocks[3] = CreateBlock(0,1, Color.green);
		}
	}
	
	GameObject CreateBlock (int i, int j, Color colour) {
		GameObject newBlock;
		newBlock = Instantiate(prefab, new Vector3(i, j, 0) + spawnOffset, Quaternion.identity) as GameObject;
		newBlock.renderer.material.color = colour;
		newBlock.name = "active block";
		return newBlock;
	}
	
	void ApplyPlayerControls () {
		for (int i = 0; i < 4; i++) {
			if (activeBlocks[i] != null) {
				activeBlocks[i].rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * velocityMagnification, 0, 0);
				if (Input.GetAxis("Vertical") > 0) {
					activeBlocks[i].rigidbody.AddTorque(0, 0, 10);
				}
			}
		}
	}
	
	void HaveActiveBlocksHitWorld () {
		for (int i = 0; i < 4; i++) {
			if (activeBlocks[i] != null) {
				if (activeBlocks[i].GetComponent<BlockMovementController>().hasTouchedWorld) {
					createNewShapeNow = true;
				}
			}
		}
	}
	
	void Update () {
		ApplyPlayerControls();
		HaveActiveBlocksHitWorld();
		if (createNewShapeNow) {
			CreateShape();
		}
		GameObject.Find("Text (Score)").GetComponent<TextMesh>().text = "Score: " + score.ToString("000000");
	}
}
