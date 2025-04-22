using System;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Vector2 _controllerInput;

	public float speed = 5;
	public Rigidbody rb;
	
	private float _shootingInterval = 1.5f;

	public GameObject gun;
	public GameObject bulletSpawn;
	public GameObject bulletPrefab;
	public GameObject swordHandle;
	
	public LevelManager levelManager;
	
	private void Update() {
		_shootingInterval -= Time.deltaTime;
		_controllerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		
		
		var enemies = GameObject.FindGameObjectsWithTag("Enemy");

		if (enemies.Length == 0)
			return;

		var enemy = enemies.OrderBy(x => Vector3.Distance(x.transform.position, transform.position)).First();

		gun.transform.LookAt(enemy.transform);
		
		if (Vector3.Distance(enemy.transform.position, transform.position) < 2f) {
			swordHandle.SetActive(true);
			swordHandle.transform.Rotate(0, 1.5f, 0);
		} else {
			swordHandle.SetActive(false);
		}
		
		if (_shootingInterval < 0) {
			_shootingInterval = 1.5f;
			
			var butter = Instantiate(bulletPrefab, bulletSpawn.transform.position, gun.transform.rotation);
			butter.GetComponent<Rigidbody>().AddForce(butter.transform.forward * 1000f);
		}
	}
	
	private void FixedUpdate() {
		var movementVector = new Vector3(_controllerInput.x, 0, _controllerInput.y);
		var targetPosition = transform.position + speed * Time.fixedDeltaTime * movementVector;
		rb.MovePosition(targetPosition);
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Enemy")) {
			levelManager.Damage(1);
		}
	}
}