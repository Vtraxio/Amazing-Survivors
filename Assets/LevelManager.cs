using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour {
	[FormerlySerializedAs("text")] public TextMeshProUGUI pointsText;
	public TextMeshProUGUI healthText;
	public GameObject gameoverPanel;

	private int _points;
	private int _health = 100;

	// Update is called once per frame
	private void Update() {
		pointsText.text = $"Punkty: {_points}";
		healthText.text = $"Hp: {_health}";
	}

	public void AddPoints(int points) {
		_points += points;
	}

	public void Damage(int damage) {
		_health -= damage;
		if (_health <= 0) {
			Time.timeScale = 0;
			gameoverPanel.SetActive(true);
			Debug.Log("Fuck you");
		}
	}

	public void Restart() {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}