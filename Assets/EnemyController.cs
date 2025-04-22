using UnityEngine;

public class EnemyController : MonoBehaviour {
	private GameObject _player;
	[Range(0, 1)]
	public float speedProc;

	public LevelManager levelManager;
	
	private void Start() {
		_player = GameObject.FindGameObjectWithTag("Player");
	}

	private void FixedUpdate() {
		transform.LookAt(_player.transform);
		transform.Translate(5f * speedProc * Time.deltaTime * Vector3.forward);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("PlayerWeapon")) {
			Destroy(gameObject);
			// Destroy(other.gameObject);
			levelManager.AddPoints(1);
		}
	}
}