using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public int score;

	public Text healthText;
	public Text scoreText;

	public AudioSource enemyKilledAudio;
	public AudioSource playerHitAudio;

	public void DamagePlayer() {
		this.currentHealth -= 1;
		this.healthText.text = this.currentHealth.ToString();

		if (this.playerHitAudio != null) {
			this.playerHitAudio.Play();
		}

		if (currentHealth == 0) {
			// game over - navigate to retry screen
			SceneManager sm = this.GetComponent<SceneManager>();
			if (sm != null) {
				sm.NavigateToGameOver();
			}
			//Debug.Log("Game Over");
		}
	}

	public void ResetGame() {
		this.currentHealth = this.maxHealth;
		this.score = 0;
		this.healthText.text = this.currentHealth.ToString();
		this.scoreText.text = this.score.ToString();
	}

	public void IncrementScore() {
		this.score += 1;
		this.scoreText.text = this.score.ToString();

		if (this.enemyKilledAudio != null) {
			this.enemyKilledAudio.Play();
		}
	}
}
