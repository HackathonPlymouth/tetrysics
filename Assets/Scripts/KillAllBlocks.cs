using UnityEngine;
using System.Collections;

public class KillAllBlocks : MonoBehaviour {

void OnTriggerEnter (Collider col) {
		Debug.Log ("Killed the lost: " + col.gameObject.name + " @ Time: " +Time.time.ToString());
		Destroy(col);
	}
}
