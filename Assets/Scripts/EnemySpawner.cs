using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	// Use this for initialization
	//void Start() {
	//}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonUp(1)) {
			Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			v.z = 2;
			GameObject.Instantiate(this.enemyPrefab, v, Quaternion.identity);
		}
	}
}
