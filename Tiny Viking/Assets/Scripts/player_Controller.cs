using UnityEngine;
using System.Collections;
 

public class player_Controller : MonoBehaviour {
	struct_plStats stats;

	// Use this for initialization
	void Start () {
		stats = GetComponent<struct_plStats>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Input.GetAxis("Horizontal") * Vector3.right * stats.Speed * Time.deltaTime);
		transform.Translate (Input.GetAxis("Vertical") * Vector3.up * stats.Speed * Time.deltaTime);
	}
}
