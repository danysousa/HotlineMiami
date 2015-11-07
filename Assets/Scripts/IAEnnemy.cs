using UnityEngine;
using System.Collections;

public class IAEnnemy : MonoBehaviour {

	private Ennemy			_body;
	private Rigidbody2D		_rigidBody;

	void Awake()
	{
		this._body = this.GetComponentInChildren<Ennemy>();
		this._rigidBody = this.GetComponentInParent<Rigidbody2D>();
	}

	void Update()
	{
		this._rigidBody.velocity = this._rigidBody.velocity * 0.8f;
	}

	private void		setTarget(Vector3 dir)
	{
		Vector3			tmp;
		Quaternion		rotate;
		float			ajuste = 1;
		
		tmp = dir;
		tmp.Set(tmp.x - this.transform.position.x, tmp.y - this.transform.position.y, 0f);

		if (tmp.x < 0f)
			ajuste = -1;

		if (tmp.magnitude > 3f)
			this._rigidBody.velocity = dir - this.transform.position;

		tmp.Normalize();
		
		this.transform.localRotation = Quaternion.Euler( 0f, 0f, 180 - ajuste * (Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot( tmp, new Vector3(0, 1f, 0f) ) ) ) );
		this._body.shoot(dir);
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
			this.setTarget(col.gameObject.transform.position);
	}
}
