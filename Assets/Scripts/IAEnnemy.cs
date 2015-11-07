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

	private IEnumerator		setTarget(Vector3 dir)
	{
		Vector3			tmp;
		Quaternion		rotate;
		float			ajuste = 1;
		
		tmp = dir;
		tmp.Set(tmp.x - this.transform.position.x, tmp.y - this.transform.position.y, 0f);

		if (tmp.x < 0f)
			ajuste = -1;

		yield return new WaitForSeconds(0.8f);
		if (tmp.magnitude > 3f)
			this._rigidBody.velocity = dir - this.transform.position;

		tmp.Normalize();
		
		this.transform.localRotation = Quaternion.Euler( 0f, 0f, 180 - ajuste * (Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot( tmp, new Vector3(0, 1f, 0f) ) ) ) );
		this._body.shoot(dir);
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, col.gameObject.transform.position - this.transform.position);
			foreach (RaycastHit2D hit in hits)
			{
				if (hit.collider.gameObject.tag == "wall")
					return ;
				else if (hit.collider.gameObject.tag == "Player")
					StartCoroutine(this.setTarget(col.gameObject.transform.position));
			}
		}
	}
}
