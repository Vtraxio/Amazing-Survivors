using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 _offset = Vector3.zero;

	// Start is called before the first frame update
	private void Start() {
		_offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	private void FixedUpdate() {
		transform.position = Vector3.Lerp(transform.position, player.transform.position + _offset, Time.deltaTime);
	}
}
