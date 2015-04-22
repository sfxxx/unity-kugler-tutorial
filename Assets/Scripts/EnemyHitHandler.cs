using UnityEngine;
using System.Collections;

public class EnemyHitHandler : MonoBehaviour {
	
	// sent from EnemyHitDetection
	public void OnHit() {
		GameObject.Destroy(this.gameObject);

		GameObject mySystem = GameObject.Find("MySystem");
		if (mySystem != null) {
			GameInfo gi = mySystem.GetComponent<GameInfo>();
			if (gi != null) {
				gi.IncrementScore();
			}
		}
	}
}
