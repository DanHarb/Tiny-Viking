using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	private pStats stats;

	[HideInInspector] public bool MouseIsLeft;
	private int screenWidth;

	private bool MouseIsLeft_LastValue;
	private GameObject onhand;
	private GameObject offhand;
	private SpriteRenderer onhandRenderer;
	private SpriteRenderer offhandRenderer;
	private Vector3 frontPosition = new Vector3 (0.03f, -0.085f, 0f);
	private Vector3 backPosition = new Vector3 (0.03f, 0.012f, 0f);
	private Vector3 vNormal = new Vector3(1, 1, 1);
	private Vector3 vFlipped = new Vector3(-1, 1, 1);

	// Use this for initialization
	void Start () {
		GetMyObjects (); //Assign Objects
		GetMyComponents (); //Assign Components
		screenWidth = Screen.width;
		MouseIsLeft_LastValue = !MouseIsLeft; //Force flip at first Update to face mouse initially
	}

	void GetMyComponents() {
		stats = GetComponent<pStats> ();
		onhandRenderer = onhand.GetComponent<SpriteRenderer> ();
		offhandRenderer = offhand.GetComponent<SpriteRenderer> ();
	}

	void GetMyObjects() {
		onhand = transform.Find ("Onhand").gameObject;
		offhand = transform.Find ("Offhand").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		MoveXY ();
		CheckMouse ();
		if (IsFlipRequired ()) {
			Flip ();
		}
	}

	void MoveXY() {
		transform.Translate (Input.GetAxis("Horizontal") * Vector3.right * stats.Speed * Time.deltaTime);
		transform.Translate (Input.GetAxis("Vertical") * Vector3.up * stats.Speed * Time.deltaTime);
	}

	void CheckMouse() {
		if (Input.mousePosition.x > (int)(screenWidth / 2)) {MouseIsLeft = false;} else {MouseIsLeft = true;}
	}

	bool IsFlipRequired() {
		return MouseIsLeft != MouseIsLeft_LastValue;
	}

	void Flip() {
		if (MouseIsLeft) {
			//FLIPPED
			transform.localScale = vFlipped;
			onhand.transform.localPosition = backPosition;
			onhandRenderer.sortingLayerName = "Back Weapon";
			offhand.transform.localPosition = frontPosition;
			offhandRenderer.sortingLayerName = "Front Weapon";
		} else {
			//NORMAL (NOT FLIPPED)
			transform.localScale = vNormal;
			onhand.transform.localPosition = frontPosition;
			onhandRenderer.sortingLayerName = "Front Weapon";
			offhand.transform.localPosition = backPosition;
			offhandRenderer.sortingLayerName = "Back Weapon";
		}
		MouseIsLeft_LastValue = MouseIsLeft;
	}
}
