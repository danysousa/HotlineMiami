using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	public string		sender;

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
		else if (coll.gameObject.tag == "enemy" && coll.gameObject.tag != this.sender)
		{
			SoundBox.playDeath();
			GameObject.Destroy (coll.collider.gameObject.transform.parent.gameObject);
			GameObject.Destroy (coll.collider.gameObject);
			GameObject.Destroy (gameObject);
			GameManager.nbEnemies -= 1;
		}
		else if (coll.gameObject.tag == "Player" && coll.gameObject.tag != this.sender)
			coll.collider.GetComponent<Player>().die();
	}
}
