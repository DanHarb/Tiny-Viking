using UnityEngine;
using System.Collections.Generic;

public class AddSelfToGroundList : MonoBehaviour {

	void Start()
	{
		Spawner.ValidTiles.Add(gameObject);//Adding us to list;
	}
	void OnDestroy()
	{
		if (Spawner.ValidTiles.Contains (gameObject)) {
			Spawner.ValidTiles.Remove (gameObject);//Removing us from list;
		}
	}
}
