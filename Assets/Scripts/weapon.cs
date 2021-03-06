﻿using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {
	
	public shoot			shootPrefabs;
	public Sprite			weaponEquip;
	public int				amo;
	public float			speed;
	public int				delay;
	public AudioClip		fireClip;
	public AudioClip		ejectClip;
	public AudioClip		reloadClip;
	public bool				distance;

	private	Vector3 		_directionEject;
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
		if (this._animate == true && this._equiped == false)
			AnimationEvent ();
		if (this._delay > 0)
		    this._delay--;
		if (this._equiped)
		{
			this.transform.localPosition = new Vector3(0.3f, -0.2f, this.transform.parent.position.z);
			this.transform.localRotation = new Quaternion(0f,0f,0f,0f);
		}
		if (!_equiped)
			this.GetComponent<Rigidbody2D> ().velocity *= 0.9f;
		if (this.GetComponent<Rigidbody2D> ().velocity.magnitude >= 0.1f)
			this.transform.Rotate(0.0f, 0.0f, 15.0f);
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
	
	public void EquipWeapon()
	{
		this.GetComponent<AudioSource> ().PlayOneShot (reloadClip);
		this.GetComponent<SpriteRenderer> ().sprite = weaponEquip;
		this._equiped = true;
		gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "player";
		this.GetComponent<SpriteRenderer>().color = this._colorSprite;
		this._animate = false;
	}

	public void DesequipWeapon()
	{	
		Vector3 	cameraPosition;

		cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this._directionEject = new Vector3 (cameraPosition.x - this.transform.position.x, cameraPosition.y - this.transform.position.y, 0.0f);
		this._directionEject.Normalize();
		this.GetComponent<Rigidbody2D> ().velocity = this._directionEject * 4.0f;
		this.GetComponent<AudioSource> ().PlayOneShot (ejectClip);
		this.GetComponent<SpriteRenderer> ().sprite = this._weaponDesequip;
		this._equiped = false;
		this._animate = true;
	}

	public void Shoot(Vector3 direction, string sender)
	{
		if ((this.amo > 0 || this.amo == -0x2A) && this._delay == 0) {

			this._delay = delay;
			this.GetComponent<AudioSource> ().PlayOneShot (fireClip);
			Vector3 pos = this.transform.position;
			this._directionShoot = new Vector3 (direction.x - pos.x, direction.y - pos.y, 0.0f);

			shoot shootObject = GameObject.Instantiate (this.shootPrefabs);
			shootObject.sender = sender;
			this._directionShoot.Normalize();
			shootObject.transform.position = new Vector3(pos.x + this._directionShoot.x * 0.3f, pos.y + this._directionShoot.y * 0.3f, pos.z );
			shootObject.GetComponent<Rigidbody2D> ().velocity = this._directionShoot * speed * 2;
			shootObject.transform.Rotate(this.transform.parent.localEulerAngles + new Vector3(0.0f, 0.0f, -90.0f));
			if (!distance)
				StartCoroutine(DestructShoot(shootObject.gameObject));
			if (this.amo != -0x2A && distance)
				amo--;
		}
	}

	private IEnumerator DestructShoot(GameObject shoot)
	{
		yield return new WaitForSeconds (0.05f);
		GameObject.Destroy (shoot);
	}

	public bool getEquiped()
	{
		return this._equiped;
	}

}
