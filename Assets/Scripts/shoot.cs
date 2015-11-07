using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Collision ();
	}

	void Collision()
	{
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.zero);
		if (hit)
		{
			GameObject.Destroy(this);
		}
	}
}
