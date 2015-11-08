using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "wall" || coll.gameObject.tag == "door" || coll.gameObject.tag == "shoot")
			GameObject.Destroy (gameObject);
		
	}
}
