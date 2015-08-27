using UnityEngine;
using System.Collections.Generic;

public class ground_AddToList : MonoBehaviour {

	void Start()
	{
		spawner_SpawnTest.ValidTiles.Add(gameObject);//Adding us to list;
	}
	void OnDestroy()
	{
		if (spawner_SpawnTest.ValidTiles.Contains (gameObject)) {
			spawner_SpawnTest.ValidTiles.Remove (gameObject);//Removing us from list;
		}
	}
}
