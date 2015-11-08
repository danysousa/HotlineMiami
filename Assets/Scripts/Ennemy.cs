using UnityEngine;
using System.Collections;

public class Ennemy : Characters {

	public Sprite[]		heads;
	public Sprite[]		body;
	public weapon[]		weponsChoice;
	private weapon		_weapon;

	void	Start()
	{
		SpriteRenderer[] renders = GetComponentsInChildren<SpriteRenderer>();
		renders[0].sprite = heads[Random.Range(0, heads.GetLength(0))];
		renders[1].sprite = body[Random.Range(0, body.GetLength(0))];
		_weapon = GameObject.Instantiate(this.weponsChoice[Random.Range(0, this.weponsChoice.GetLength(0))]);
		this._weapon.transform.position = this.transform.position;
		this._weapon.transform.SetParent(this.transform);
		this._weapon.transform.localPosition = new Vector3(0.3f, -0.2f, this.transform.position.z);
		this._weapon.transform.localRotation = new Quaternion(0f,0f,0f,0f);
		this._weapon.EquipWeapon();
		this._weapon.amo = -0x2A;
	}

	public void	shoot(Vector3 target)
	{
		this._weapon.Shoot(target, "enemy");
	}

}
