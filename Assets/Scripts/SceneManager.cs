using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public GameObject titleScreen;
	public GameObject optionsScreen;
	public GameObject highScoreScreen;

	public void NavigateToOptions() {
		this.titleScreen.SetActive(false);
		this.optionsScreen.SetActive(true);
		this.highScoreScreen.SetActive(false);
	}

	public void NavigateToHighScores() {
		this.titleScreen.SetActive(false);
		this.optionsScreen.SetActive(false);
		this.highScoreScreen.SetActive(true);
	}

	public void NavigateToTitle() {
		this.titleScreen.SetActive(true);
		this.optionsScreen.SetActive(false);
		this.highScoreScreen.SetActive(false);	
	}

	// Use this for initialization
	//void Start () {	
	//}
	
	// Update is called once per frame
	//void Update () {	
	//}

}
