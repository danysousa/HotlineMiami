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
		if (this._equiped)
		{
			this.transform.localPosition = new Vector3(0.3f, -0.2f, this.transform.parent.position.z);
			this.transform.localRotation = new Quaternion(0f,0f,0f,0f);
		}
	}

	void AnimationEvent()
	{
		if (this._scaleUp <= 20)
		{
			
//			transform.localScale += new Vector3 (flux * Time.deltaTime,flux * Time.deltaTime,flux * Time.deltaTime);
//			flexout ++;
			
		}
	}
	
	public void EquipWeapon()
	{
		this.GetComponent<SpriteRenderer> ().sprite = weaponEquip;
		this._equiped = true;
		gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "player";

	}

	void DesequipWeapon()
	{
	}

	void Shoot()
	{
		if (Input.GetMouseButton (0) && this.amo > 0 && this._delay == 0)
		{
			this._delay = delay;
			this._positionMouseInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			this._positionMouseInWorld.z = 0.0f;
			Vector3 pos = this.transform.position;
			this._directionShoot = new Vector3 (this._positionMouseInWorld.x - pos.x, this._positionMouseInWorld.y - pos.y, 0.0f);
			GameObject shootObject = GameObject.Instantiate (this.shootPrefabs) as GameObject;
			this._directionShoot.Normalize();
			shootObject.transform.position = new Vector3(pos.x + this._directionShoot.y * 0.3f, pos.y + this._directionShoot.y * 0.3f, pos.z );
			shootObject.GetComponent<Rigidbody2D> ().velocity = this._directionShoot * speed;
		}
	}
	
}
