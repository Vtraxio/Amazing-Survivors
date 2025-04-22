using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	private List<Vector3> _spawnPoints = new();
	private float _timeLeft = 2f;

	public float spawnRate = 2f;
	
	public GameObject enemy;
	
	public LevelManager levelManager;
	
	// Start is called before the first frame update
	private void Start() {
		var sp = transform.Find("Spawn Positions");
		foreach (Transform child in sp) {
			_spawnPoints.Add(child.position);
		}
	}

	private void Update() {
		_timeLeft -= Time.deltaTime;
		if (_timeLeft < 0) {
			_timeLeft = spawnRate;
			_spawnPoints.ForEach((x) => {
				var gameObject = Instantiate(enemy, x, Quaternion.identity);
				var ec = gameObject.GetComponent<EnemyController>();
				ec.levelManager = levelManager;
			});
		}
	}
}