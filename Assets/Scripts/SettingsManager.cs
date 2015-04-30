using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine.UI;

[System.Serializable]
public class GameSettings {
	public float musicVolume { get; set; }
	public float sfxVolume { get; set; }
}

public class SettingsManager : MonoBehaviour {
	
	private string filePath;
	private GameSettings settings;

	public Slider bgmSlider;
	public Slider sfxSlider;

	// Use this for initialization
	void Start () {
		this.filePath = Path.Combine(Application.persistentDataPath, "settings.txt");
		if (File.Exists(this.filePath)) {
			this.LoadSettings();
		}

		if (this.settings == null) {
			this.settings = new GameSettings {
				musicVolume = 0.5f,
				sfxVolume = 0.5f
			};
		}
		this.UpdateSliders();
	}

	public void UpdateSliders() {
		if (this.bgmSlider != null) {
			this.bgmSlider.value = this.settings.musicVolume;
		}
		if (this.sfxSlider != null) {
			this.sfxSlider.value = this.settings.sfxVolume;
		}
	}

	private void LoadSettings() {
		using (FileStream fs = new FileStream(this.filePath, FileMode.Open, FileAccess.Read)) {
			BinaryFormatter bf = new BinaryFormatter();
			this.settings = (GameSettings)bf.Deserialize(fs);
		}
	}

	public void SaveSettigs() {
		this.settings.musicVolume = this.bgmSlider.value;
		this.settings.sfxVolume = this.sfxSlider.value;

		using (FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.Write)) {
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, this.settings);
		}
	}
}
