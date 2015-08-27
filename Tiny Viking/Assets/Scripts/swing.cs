using UnityEngine;
using System.Collections;

public class swing : MonoBehaviour {

	public Camera camera;               // camera object
	private float speed = 5f;           // bullet speed
	private float ttl = 2f;
	private Vector3 clickPos;           // bullet direction
	private Vector3 shotDirection;
	
	void Start()
	{
		camera = (Camera) GameObject.FindObjectOfType(typeof(Camera)); // get the camera
		
		// get world location of click
		clickPos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
		shotDirection = (clickPos - transform.position).normalized;
		
		Destroy(gameObject, ttl); // give bullet 20 seconds lifetime
	}
	
	void Update()
	{
		// move the bullet in the right direction
		transform.position = transform.position + shotDirection * speed * Time.deltaTime;
	}
}
