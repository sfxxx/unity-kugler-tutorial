using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public GameObject titleScreen;
	public GameObject optionsScreen;
	public GameObject highScoreScreen;
	public GameObject gameScreen;
	public GameObject gameOverScreen;

	public void NavigateToOptions() {
		this.titleScreen.SetActive(false);
		this.optionsScreen.SetActive(true);
		this.highScoreScreen.SetActive(false);
		this.gameScreen.SetActive(false);
		this.gameOverScreen.SetActive(false);
	}

	public void NavigateToHighScores() {
		this.titleScreen.SetActive(false);
		this.optionsScreen.SetActive(false);
		this.highScoreScreen.SetActive(true);
		this.gameScreen.SetActive(false);
		this.gameOverScreen.SetActive(false);
	}

	public void NavigateToTitle() {
		this.titleScreen.SetActive(true);
		this.optionsScreen.SetActive(false);
		this.highScoreScreen.SetActive(false);	
		this.gameScreen.SetActive(false);
		this.gameOverScreen.SetActive(false);
	}

	public void NavigateToGame() {
		this.titleScreen.SetActive(false);
		this.optionsScreen.SetActive(false);
		this.highScoreScreen.SetActive(false);	
		this.gameScreen.SetActive(true);
		this.gameOverScreen.SetActive(false);

		ClearEnemies();
		this.EnableGameSystemObject(true);
	}
	
	public void NavigateToGameOver() {
		this.titleScreen.SetActive(false);
		this.optionsScreen.SetActive(false);
		this.highScoreScreen.SetActive(false);	
		this.gameScreen.SetActive(false);
		this.gameOverScreen.SetActive(true);

		this.UpdateHighScores();
		this.EnableGameSystemObject(false);
	}

	private void UpdateHighScores() {
		GameObject mySystem = GameObject.Find("MySystem");

		if (mySystem != null) {
			ScoreManager sm = mySystem.GetComponent<ScoreManager>();
			GameInfo gi = mySystem.GetComponent<GameInfo>();

			if (sm != null && gi != null) {
				sm.UpdateScores(gi.score);
			}
		}
	}

	private void EnableGameSystemObject(bool enabled) {
		GameObject mySystem = GameObject.Find("MySystem");
		if (mySystem != null) {
			EnemySpawner spawner = mySystem.GetComponent<EnemySpawner>();
			if (spawner != null) {
				spawner.enabled = enabled;
			}

			EnemyHitDetection det = mySystem.GetComponent<EnemyHitDetection>();
			if (det != null) {
				det.enabled = enabled;
			}

			if (enabled) {
				GameInfo gi = mySystem.GetComponent<GameInfo>();
				if (gi != null) {
					gi.ResetGame();
				}
			}
		}
	}

	private void ClearEnemies() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies != null && enemies.Length > 0) {
			foreach (GameObject en in enemies) {
				GameObject.Destroy(en);
			}
		}
	}
}