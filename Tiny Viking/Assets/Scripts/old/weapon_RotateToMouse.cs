using UnityEngine;
using System.Collections;

public class weapon_RotateToMouse : MonoBehaviour {

	struct_Weapon weapon;
	GameObject player;
	//player_MouseWatcher mouseWatch;
	
	int rot;
	public int MainHandRotation;
	public int OffHandRotation;


	void Start() {
		weapon = GetComponent<struct_Weapon>();
		player = transform.parent.gameObject;
		//mouseWatch = player.GetComponent<player_MouseWatcher> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if ((weapon.IsMainHand == !mouseWatch.IsLeft)) {rot = MainHandRotation;} else {rot = OffHandRotation;}
		Vector3 mousePos = Input.mousePosition;
		//if (mouseWatch.IsLeft) {mousePos.x = mouseWatch.screenWidth - mousePos.x;}
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - player.transform.position); 
		transform.Rotate(Vector3.forward * rot);
	}
}