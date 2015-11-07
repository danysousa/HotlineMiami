using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {
	
	public GameObject		shootPrefabs;
	public GameObject		playerPrefabs;
	public Sprite			weaponEquip;
	public int				amo;
	public float			speed;
	public int				delay;

	private	Vector3			_positionMouseInWorld;
	private	Vector3			_positionPlayerPrefabs;
	private Vector3			_directionShoot;
	private int    			_delay;
	private bool			_equiped;
	private bool			_animate;
	private int				_scaleUp;
	void Start ()
	{
		this._delay = 0;
		this._equiped = false;
		this._animate = true;
	}
	

	void Update ()
	{
		if (this._animate == true)
			AnimationEvent ();
		if (Input.GetMouseButton (0) && this.amo > 0 && this._delay == 0)
			Shoot ();
		if (this._delay > 0)
		    this._delay--;
		EquipWeapon ();
	}

	void AnimationEvent()
	{
		if (this._scaleUp <= 20)
		{
			
//			transform.localScale += new Vector3 (flux * Time.deltaTime,flux * Time.deltaTime,flux * Time.deltaTime);
//			flexout ++;
			
		}
	}
	
	void EquipWeapon()
	{
		this.GetComponent<SpriteRenderer> ().sprite = weaponEquip;
		this._equiped = true;
//		if (Input.GetKeyDown (KeyCode.E)) {
//			RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.zero);
//			if (hit)
//			{
//				if (hit.collider.name == "Player")
//				{
//					this.GetComponent<SpriteRenderer> ().sprite = weaponEquip;
//					this._equiped = true;
//				}
//			}
//
//		}
//		if (this._equiped)
//			this.transform.position = this.playerPrefabs.transform.position;
	}

	void DesequipWeapon()
	{
	}

	void Shoot()
	{
		if (Input.GetMouseButton (0) && this.amo > 0 && this._delay == 0)
		{
			this._delay = delay;
			this._positionPlayerPrefabs = this.playerPrefabs.transform.position;
			this._positionMouseInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			this._positionMouseInWorld.z = 0.0f;
			this._directionShoot = new Vector3 (this._positionMouseInWorld.x - this._positionPlayerPrefabs.x, this._positionMouseInWorld.y - this._positionPlayerPrefabs.y, 0.0f);
			GameObject shootObject = GameObject.Instantiate (this.shootPrefabs, this._positionPlayerPrefabs, Quaternion.identity) as GameObject;
			this.amo--;
			shootObject.GetComponent<Rigidbody2D> ().velocity = transform.TransformDirection (this._directionShoot * speed);
		}
	}
	
}
