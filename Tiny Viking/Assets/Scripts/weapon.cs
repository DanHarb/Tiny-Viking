using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {
	
	public int MainHandRotation;
	public int OffHandRotation;

	private wStats stats;
	private GameObject playerObject;
	private player playerScript;
	private int tempRotation;

	private int screenWidth;

	private float cooldown;
	private float cooldownQueue;
	public GameObject proj;

	// Use this for initialization
	void Start () {
		GetMyObjects ();
		GetMyComponents ();
		screenWidth = Screen.width;
		cooldown = stats.Cooldown;
		cooldownQueue = 0f;
	}

	void GetMyComponents () {
		stats = GetComponent<wStats> ();
		playerScript = playerObject.GetComponent<player> ();
	}
	void GetMyObjects () {
		playerObject = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		tempRotation = GetRotation ();
		Vector3 mousePos = Input.mousePosition; //Get mouse position
		if (playerScript.MouseIsLeft) {mousePos.x = screenWidth - mousePos.x;} //Account for sprite flip if mouse is left
		mousePos = Camera.main.ScreenToWorldPoint(mousePos); //Assign current mouse position to variable
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - playerObject.transform.position);  //Assign desired rotation
		transform.Rotate(Vector3.forward * tempRotation); //Rotate to offset
		ReduceCooldown ();
		if (FireButton () && cooldownQueue == 0) {
			GameObject clone;
			mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			Quaternion cloneRotation = Quaternion.LookRotation (Vector3.forward, mousePos - playerObject.transform.position);
			clone = (GameObject) Instantiate(proj, playerObject.transform.position, cloneRotation);
			cooldownQueue = cooldown;
		}
		
	}

	int GetRotation() {
		if ((stats.IsOnHand == !playerScript.MouseIsLeft)) { //Assign correct rotation offset based on weapon hand and mouse pos
			return MainHandRotation;
		} else {
			return OffHandRotation;
		}
	}

	void ReduceCooldown() {
		if (cooldownQueue > 0 + Time.deltaTime) {
			cooldownQueue -= Time.deltaTime;
		} else {
			cooldownQueue = 0;
		}
	}

	bool FireButton() {
		switch (stats.IsOnHand) {
		case true:
			return Input.GetButtonDown ("Fire1");
		case false:
			return Input.GetButtonDown ("Fire2");
		}
		return Input.GetButtonDown ("Fire1");
	}
}
