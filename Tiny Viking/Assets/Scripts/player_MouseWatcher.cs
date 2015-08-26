using UnityEngine;
using System.Collections;

public class player_MouseWatcher : MonoBehaviour {

	public bool IsLeft;
	public int screenWidth;

	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.mousePosition.x > (int)(screenWidth / 2)) {IsLeft = false;} else {IsLeft = true;}
	}
}
