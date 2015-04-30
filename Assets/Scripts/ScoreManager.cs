using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ScoreManager : MonoBehaviour {

	private string filePath;
	public List<int> scores { get; private set; }

	// Use this for initialization
	void Start() {
		this.filePath = Path.Combine(Application.persistentDataPath, "scores.txt");
		if (File.Exists(this.filePath)) {
			this.LoadScores();
		}

		if (this.scores == null) {
			this.scores = new List<int>();
			this.scores.AddRange(Enumerable.Repeat(0, 5));
			this.SaveScores();
		}
	}

	private void LoadScores() {
		using (FileStream fs = new FileStream(this.filePath, FileMode.Open, FileAccess.Read)) {
			BinaryFormatter bf = new BinaryFormatter();
			this.scores = (List<int>)bf.Deserialize(fs);
		}
	}

	private void SaveScores() {
		using (FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.Write)) {
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, this.scores);
		}
	}
	
	public void UpdateScores(int score) {
		if (score > this.scores.Min()) {
			this.scores.Add(score);
			this.scores = this.scores.OrderByDescending(x => x).Take(5).ToList();
			this.SaveScores();
		}
	}
}
