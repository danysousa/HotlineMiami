using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {
	
	public GameObject		shootPrefabs;
	public GameObject		playerPrefabs;
	public int				amo;
	public float			speed;
	public int				delay;

	private	Vector3			_positionMouseInWorld;
	private	Vector3			_positionPlayerPrefabs;
	private Vector3			_directionShoot;
	private int    			_delay;
	void Start ()
	{
		this._delay = 0;
	}
	

	void Update ()
	{
		if (Input.GetMouseButton (0) && this.amo > 0 && this._delay == 0)
			Shoot ();
		if (this._delay > 0)
		    this._delay--;
		
	}

	void Shoot()
	{
		this._delay = delay;
		this._positionPlayerPrefabs = this.gameObject.transform.position; //TODO: positionPlayerPrefabs = this.playerPrefabs.transform.position;
		this._positionMouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this._positionMouseInWorld.z = 0.0f;
		this._directionShoot = new Vector3(this._positionMouseInWorld.x - this._positionPlayerPrefabs.x, this._positionMouseInWorld.y - this._positionPlayerPrefabs.y, 0.0f);
		GameObject shootObject = GameObject.Instantiate(this.shootPrefabs, this._positionPlayerPrefabs, Quaternion.identity) as GameObject;
		this.amo--;
		shootObject.GetComponent<Rigidbody2D> ().velocity = transform.TransformDirection(this._directionShoot * speed);
	}
	
}
