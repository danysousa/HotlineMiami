using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public GameObject[]	doors;
	static public Vector3		firePos;
	static public float			fireTime = 0f;

	void Start ()
	{
		GameManager.doors = GameObject.FindGameObjectsWithTag("door");
	}
	
	static public void	soundPlayed(Vector3 pos)
	{
		GameManager.firePos = pos;
		GameManager.fireTime = Time.realtimeSinceStartup;
	}
}
