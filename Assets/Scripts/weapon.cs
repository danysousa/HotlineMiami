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
		this.GetComponent<SpriteRenderer> ().sprite = weaponEquip;
		this._equiped = true;
		gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "player";
		this.GetComponent<SpriteRenderer>().color = this._colorSprite;
		this._animate = false;
	}

	public void DesequipWeapon()
	{
		this.GetComponent<SpriteRenderer> ().sprite = this._weaponDesequip;
		this._equiped = false;
		this._animate = true;
	}

	public void Shoot(Vector3 direction)
	{
		if ((this.amo > 0 || this.amo == -0x2A) && this._delay == 0)
		{
			this._delay = delay;

			Vector3 pos = this.transform.position;
			this._directionShoot = new Vector3 (direction.x - pos.x, direction.y - pos.y, 0.0f);
			GameObject shootObject = GameObject.Instantiate (this.shootPrefabs) as GameObject;
			this._directionShoot.Normalize();
			shootObject.transform.position = new Vector3(pos.x + this._directionShoot.x * 0.3f, pos.y + this._directionShoot.y * 0.3f, pos.z );
<<<<<<< HEAD
			shootObject.GetComponent<Rigidbody2D> ().velocity = this._directionShoot * speed * 2;
			if (this.amo != 0x2A)
				amo--;
=======
			shootObject.GetComponent<Rigidbody2D> ().velocity = this._directionShoot * speed;
			shootObject.transform.Rotate(this.transform.parent.localEulerAngles + new Vector3(0.0f, 0.0f, -90.0f));
			amo--;
>>>>>>> 566f3392ae39bb46f181d72de1063dac6ef954ae
		}
	}
	
}
