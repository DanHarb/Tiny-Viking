using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

	private Transform playerTransform;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerpos = playerTransform.position;
		playerpos.z = transform.position.z;
		transform.position = playerpos;
	}
}
