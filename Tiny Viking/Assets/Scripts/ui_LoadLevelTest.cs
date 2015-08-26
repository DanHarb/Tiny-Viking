using UnityEngine;
using System.Collections;

public class ui_LoadLevelTest : MonoBehaviour {

	public void LoadScene(int level)
	{
		Application.LoadLevel (level);

	}
}
