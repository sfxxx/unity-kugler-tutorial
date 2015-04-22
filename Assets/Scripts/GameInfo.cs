using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

	public int health;

	public void DamagePlayer() {
		this.health -= 1;
		if (health <= 0) {
			// game over - navigate to retry screen
			Debug.Log("Game Over");
		}
	}
}
