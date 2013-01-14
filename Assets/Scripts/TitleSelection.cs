using UnityEngine;
using System.Collections;

public class TitleSelection : MonoBehaviour {
	
	void Update () {
		Time.timeScale = 1;
		if (Input.GetKey(KeyCode.UpArrow)) {
			// 1 Player
			Application.LoadLevel("1P");
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			// 2 Player
			Application.LoadLevel("2P");
		}
	}
}
