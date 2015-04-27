using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreView : MonoBehaviour {

	public Text score1;
	public Text score2;
	public Text score3;
	public Text score4;
	public Text score5;

	private void OnEnable() {
		GameObject mySystem = GameObject.Find("MySystem");

		if (mySystem != null) {
			ScoreManager sm = mySystem.GetComponent<ScoreManager>();

			if (sm != null && sm.scores != null && sm.scores.Count == 5) {
				score1.text = sm.scores[0].ToString();
				score2.text = sm.scores[1].ToString();
				score3.text = sm.scores[2].ToString();
				score4.text = sm.scores[3].ToString();
				score5.text = sm.scores[4].ToString();
			}
		}
	}
}
