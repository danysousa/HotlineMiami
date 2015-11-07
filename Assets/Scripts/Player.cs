using UnityEngine;
using System.Collections;

public class Player : Characters {
	
	void Start ()
	{
		this.init();
		if (this.weapon != null)
		{
			this.weapon.transform.SetParent(this.transform);
			this.weapon.transform.position = new Vector3(0.2f, -0.05f, -2f);
			this.weapon.transform.Rotate(new Vector3(0f, 0f, -2f));
		}
	}
	
	void Update ()
	{
		this.checkMove();
		this.updateCharacters();
		this.updatePlayer();
	
		if (this.weapon != null)
			this.updateWeapon();
	}

	private void		updatePlayer()
	{
		Vector3			tmp;
		Quaternion		rotate;
		float			ajuste = 1;

		tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		tmp.Set(tmp.x - this.transform.position.x, tmp.y - this.transform.position.y, 0f);

		if (tmp.x < 0f)
			ajuste = -1;
		tmp.Normalize();
		this.transform.localRotation = Quaternion.Euler( 0f, 0f, 180 - ajuste * (Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot( tmp, new Vector3(0, 1f, 0f) ) ) ) );
		Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
	}

	private void		checkMove()
	{
		Vector2		direction = new Vector2(0f, 0f);

		if (Input.GetKey(KeyCode.W))
			direction.y = direction.y + this.speedMove;
		if (Input.GetKey(KeyCode.S))
			direction.y = direction.y - this.speedMove;
		if (Input.GetKey(KeyCode.A))
			direction.x = direction.x - this.speedMove;
		if (Input.GetKey(KeyCode.D))
			direction.x = direction.x + this.speedMove;

		if (direction.magnitude > 0f)
			this.move(direction);
	}

	private void		updateWeapon()
	{
//		this.weapon.transform.position = new Vector3(this.transform.position.x + 0.25f, this.transform.position.y, this.transform.position.z);
//		this.weapon.transform.rotation = this.transform.rotation;
	}
}
