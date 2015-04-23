using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	private int yOffset = 0;
	// offset to put distance between enemy and edge of the screen
	private int xOffset = 32;

	public GameObject enemyPrefab;

	// Use this for initialization
	//void Start() {
	//}
	
	// Update is called once per frame
	void Update() {
		// debug only
		/*if (Input.GetMouseButtonUp(1)) {
			Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			v.z = 2;
			GameObject.Instantiate(this.enemyPrefab, v, Quaternion.identity);
		}*/
	}

	private void OnEnable() {
		Debug.Log("Enable");
		this.InvokeRepeating("Spawn", 1, 1);
	}

	private void OnDisable() {
		Debug.Log("Disable");
		this.CancelInvoke("Spawn");
	}

	private void Spawn() {
		Debug.Log("Spawn");
		float x = UnityEngine.Random.Range(xOffset, Screen.width-xOffset);

		Vector3 startPos = new Vector3(x, Screen.height + yOffset, 2);
		Debug.Log("untransformed: " + startPos);
		Vector3 pos = Camera.main.ScreenToWorldPoint(startPos);
		Debug.Log("transformed: " + pos);

		GameObject.Instantiate(this.enemyPrefab, pos, Quaternion.identity);
	}
}
