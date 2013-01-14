using UnityEngine;
using System.Collections;

public class BlockMovementController : MonoBehaviour {

	public bool hasTouchedWorld;
	public GameObject particleEffect;
	
	private bool hasPlayedSound;
	
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.name != "active block") {
			name = "in-active block";
			hasTouchedWorld = true;
			if (!hasPlayedSound) {
				GetComponent<AudioSource>().Play();
				hasPlayedSound = true;
			}
		}
	}
	
	public void KillThisBlock () {
		// Create the particle / sound effect
		Instantiate(particleEffect,transform.position,Quaternion.identity);
		// Kill this block
		Destroy(gameObject);
	}
}
