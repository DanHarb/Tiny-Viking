using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public static List<GameObject> ValidTiles = new List<GameObject> ();
	public int SpawnInterval;
	public GameObject prefab;
	private float timeCount = 0;
	private Transform transform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int rand;
		timeCount += Time.deltaTime;
		if (timeCount > (float) SpawnInterval) {
			if (ValidTiles.Count > 0) {
				rand = Random.Range (0, ValidTiles.Count);
				transform = ValidTiles[rand].transform;
				Instantiate(prefab, transform.position, transform.rotation); 
				ValidTiles.RemoveAt(rand);

			}
			timeCount %= SpawnInterval;
		}
	}
}
