using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyController : MonoBehaviour {
	private GameObject _player;
	private float _hp;
	[Range(0, 1)] public float speedProc;

	public float defaultHp = 100;

	public LevelManager levelManager;
	public TextMeshProUGUI hpText;
	public Canvas canvasBillboard;

	private void Start() {
		_player = GameObject.FindGameObjectWithTag("Player");
		_hp = defaultHp;
	}

	private void Update() {
		canvasBillboard.transform.forward = Camera.main.transform.forward;
	}

	private void FixedUpdate() {
		transform.LookAt(_player.transform);
		transform.Translate(5f * speedProc * Time.deltaTime * Vector3.forward);
	}

	private void OnTriggerEnter(Collider other) {
		if (!other.gameObject.CompareTag("PlayerWeapon")) return;

		var data = other.gameObject.GetComponent<WeaponData>();
		Assert.IsNotNull(data);
		_hp -= data.damage;

		//                         V chuj wie co to robi ale wywala błąd bez tego
		hpText.text = _hp.ToString(CultureInfo.CurrentCulture);

		if (_hp <= 0) {
			Destroy(gameObject);
			// Destroy(other.gameObject);
			levelManager.AddPoints(1);
		}
	}
}