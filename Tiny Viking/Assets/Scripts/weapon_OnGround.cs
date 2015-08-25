using UnityEngine;
using System.Collections;

public class weapon_OnGround : MonoBehaviour {

	bool growing;
	public float maxDif;
	Vector3 defScale;
	public float time;//in seconds

	// Use this for initialization
	void Start () {
		growing = true;
		//maxDif = 0.05f;
		defScale = transform.localScale;
		//time = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		float value = (maxDif/time) * Time.deltaTime;
		if (!growing)
			value = -1 * value;
		transform.localScale = transform.localScale+(Vector3.one * value);
		if (Mathf.Abs ((defScale - transform.localScale).x) >= maxDif)
			growing = !growing;
	}
}
