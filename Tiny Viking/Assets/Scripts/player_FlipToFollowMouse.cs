using UnityEngine;
using System.Collections;

public class player_FlipToFollowMouse : MonoBehaviour {

	private player_MouseWatcher mouseWatch;
	private bool lastValue;
	private GameObject onhand;
	private GameObject offhand;
	private SpriteRenderer onhandRenderer;
	private SpriteRenderer offhandRenderer;

	// Use this for initialization
	void Start () {
		mouseWatch = GetComponent<player_MouseWatcher> ();
		lastValue = !mouseWatch.IsLeft;
		onhand = transform.Find ("Onhand").gameObject;
		onhandRenderer = onhand.GetComponent<SpriteRenderer> ();
		offhand = transform.Find ("Offhand").gameObject;
		offhandRenderer = offhand.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseWatch.IsLeft != lastValue) {
			if (mouseWatch.IsLeft) {
				transform.localScale = new Vector3(-1, 1, 1);
				onhand.transform.localPosition = new Vector3(0.03f, 0.012f, 0f);
				onhandRenderer.sortingLayerName = "Off Hand";
				offhand.transform.localPosition = new Vector3(0.03f, -0.085f, 0f);
				offhandRenderer.sortingLayerName = "Main Hand";
			} else {
				transform.localScale = new Vector3(1, 1, 1);
				onhand.transform.localPosition = new Vector3(0.03f, -0.085f, 0f);
				onhandRenderer.sortingLayerName = "Main Hand";
				offhand.transform.localPosition = new Vector3(0.03f, 0.012f, 0f);
				offhandRenderer.sortingLayerName = "Off Hand";
			}
			lastValue = mouseWatch.IsLeft;
		}
	}
}
