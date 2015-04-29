using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public GameObject titleScreen;
	public GameObject optionsScreen;
	public GameObject highScoreScreen;
	public GameObject gameScreen;
	public GameObject gameOverScreen;

	public void NavigateToTitle() {
		this.titleScreen.SetActive(true);
		this.optionsScreen.SetActive(false);
		this.highScoreScreen.SetActive(false);	
		this.gameScreen.SetActive(false);
		this.gameOverScreen.SetActive(false);
		this.SwitchBGM(false);
	}
	
	public void NavigateToOptions() {
		this.titleScreen.SetActive(false);
		this.optionsScreen.SetActive(true);
		this.highScoreScreen.SetActive(false);
		this.gameScreen.SetActive(false);
		this.gameOverScreen.SetActive(false);
		this.SwitchBGM(true);
	}

	public void NavigateToHighScores() {
		this.titleScreen.SetActive(false);
		this.optionsScreen.SetActive(false);
		this.highScoreScreen.SetActive(true);
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
		this.SwitchBGM(true);
	}
	
	public void NavigateToGameOver() {
		this.titleScreen.SetActive(false);
		this.optionsScreen.SetActive(false);
		this.highScoreScreen.SetActive(false);	
		this.gameScreen.SetActive(false);
		this.gameOverScreen.SetActive(true);

		this.UpdateHighScores();
		this.EnableGameSystemObject(false);
		this.SwitchBGM(false);
	}

	private void SwitchBGM(bool enable) {
		GameObject audioObj = GameObject.Find("AudioBGM");
		if (audioObj != null) {
			AudioSource source = audioObj.GetComponent<AudioSource>();
			if (source != null) {
				if (enable) {
					source.Play();
				} else {
					source.Stop();
				}
			}
		}
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