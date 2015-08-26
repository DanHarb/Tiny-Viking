using UnityEngine;
using System.Collections;

public class struct_plStats : MonoBehaviour {

	public string Name;
	public float Speed;
	public int MaxHealth;
	public int CurHealth;

	void Start () {
		Name = "player";
		Speed = 1.0f;
		MaxHealth = 10;
		CurHealth = 10;
	}

}
