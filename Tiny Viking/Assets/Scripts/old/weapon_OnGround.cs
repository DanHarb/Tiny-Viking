using UnityEngine;
using System.Collections;

public class weapon_OnGround : MonoBehaviour {

	bool growing;
	public float MaxDif = 0.2f;
	Vector3 defScale;
	public float GrowTime = 2f;//in seconds
	public float RotationSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		growing = true;
		//maxDif = 0.05f;
		defScale = transform.localScale;
		//time = 10f;
	}
	
	// Update is called once per frame
	void Update () {

		float value = (MaxDif/GrowTime) * Time.deltaTime;
		if (!growing)
			value = -1 * value;
		transform.localScale = transform.localScale+(Vector3.one * value);
		if (Mathf.Abs ((defScale - transform.localScale).x) >= MaxDif)
			growing = !growing;

		transform.RotateAround (transform.position, Vector3.forward, RotationSpeed*Time.deltaTime);
	}
}
