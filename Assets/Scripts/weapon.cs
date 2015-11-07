using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {
	
	public GameObject		shootPrefabs;
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
	private int				_scale;
	private bool			_scaleUp;
	private Sprite			_weaponDesequip;
	private Color			_colorSprite;
	void Start ()
	{
		this._delay = 0;
		this._equiped = false;
		this._animate = true;
		this._scale = 0;
		this._scaleUp = true;
		this._weaponDesequip = this.GetComponent<SpriteRenderer> ().sprite;
		this._colorSprite = this.GetComponent<SpriteRenderer> ().color;
	}
	

	void Update ()
	{
		if (this._animate == true)
			AnimationEvent ();
//		if (this.amo > 0 && this._delay == 0)
//			Shoot ();
		if (this._delay > 0)
		    this._delay--;
	}

	void AnimationEvent()
	{
		if (this._scale <= 6 && this._scaleUp)
		{
			this.transform.localScale += new Vector3 (0.1f, 0.1f, 0.0f) * 0.8f;
			this._scale++;
			if (this._scale > 3)
				this.GetComponent<SpriteRenderer>().color = Color.grey;
			else
				this.GetComponent<SpriteRenderer>().color = this._colorSprite;
			if (this._scale == 6)
				this._scaleUp = false;
		}
		if (this._scale >= 0 && !this._scaleUp)
		{
			this.transform.localScale += new Vector3 (-0.1f, -0.1f, 0.0f) * 0.8f;
			this._scale--;
			if (this._scale < 3)
				this.GetComponent<SpriteRenderer>().color = Color.grey;
			else
				this.GetComponent<SpriteRenderer>().color = this._colorSprite;
			if (this._scale == 0)
				this._scaleUp = true;
		}
	}
	
	void EquipWeapon()
	{
		this.GetComponent<SpriteRenderer> ().sprite = weaponEquip;
		this._equiped = true;
	}

	void DesequipWeapon()
	{
		this.GetComponent<SpriteRenderer> ().sprite = this._weaponDesequip;
		this._equiped = false;
	}

	void Shoot()
	{
		if (this.amo > 0 && this._delay == 0)
		{
			this._delay = delay;
			this._positionMouseInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			this._positionMouseInWorld.z = 0.0f;
			this._directionShoot = new Vector3 (this._positionMouseInWorld.x - this.transform.parent.position.x, this._positionMouseInWorld.y - this.transform.parent.position.y, 0.0f);
			GameObject shootObject = GameObject.Instantiate (this.shootPrefabs, this.transform.parent.position, Quaternion.identity) as GameObject;
			this.amo--;
			shootObject.GetComponent<Rigidbody2D> ().velocity = transform.TransformDirection (this._directionShoot * speed);
		}
	}
	
}
