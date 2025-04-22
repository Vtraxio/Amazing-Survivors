using UnityEngine;

public class RotatingStarController : MonoBehaviour {
	public float rotationSpeed = 500f;

	// Update is called once per frame
	void Update() {
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
	}
}