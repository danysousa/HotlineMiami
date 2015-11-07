using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D element)
	{
		Debug.Log (element.gameObject.name);
	}
}
