using UnityEngine;
using System.Collections;

public class EnemyHitHandler : MonoBehaviour {
	
	// sent from EnemyHitDetection
	public void OnHit() {
		GameObject.Destroy(this.gameObject);
	}
}
