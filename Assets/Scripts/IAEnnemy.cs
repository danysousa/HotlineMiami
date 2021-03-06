﻿using UnityEngine;
using System.Collections;

public class IAEnnemy : MonoBehaviour {

	private Ennemy			_body;
	private Rigidbody2D		_rigidBody;
	private	bool			_playerFound = false;
	private Vector3			_dest;
	private int				_destAssign = 0;
	private Vector3			_soundHere;
	private bool			sound = false;
	

	public Vector3[]		watchPoint;

	void Awake()
	{
		this._body = this.GetComponentInChildren<Ennemy>();
		this._rigidBody = this.GetComponentInParent<Rigidbody2D>();
	}

	void Update()
	{
		if (this._playerFound == true)
			this._rigidBody.velocity = this._rigidBody.velocity * 0.8f;
		else
			this.continueWatch();
		this._rigidBody.velocity = this._rigidBody.velocity * 0.8f;
	}

	private void			continueWatch()
	{
		
		Vector3		tmp;

		while (this._destAssign < watchPoint.GetLength(0))
		{
			tmp = new Vector3(watchPoint[_destAssign].x - this.transform.position.x, watchPoint[_destAssign].y - this.transform.position.y, 0f);

			if ( Mathf.Abs(tmp.magnitude) > 0.1f )
			{
				this.goHere(watchPoint[_destAssign]);
				this._dest = watchPoint[_destAssign];
				return ;
			}
			this._destAssign++;
		}
		this._destAssign = 0;
	}
	
	private void			goHere(Vector3 point)
	{
		Vector3			tmp;
		Quaternion		rotate;
		float			ajuste = 1;
		
		tmp = point;
		tmp.Set(tmp.x - this.transform.position.x, tmp.y - this.transform.position.y, 0f);
		
		if (tmp.x < 0f)
			ajuste = -1;
		tmp.Normalize();
		this.transform.localRotation = Quaternion.Euler( 0f, 0f, 180 - ajuste * (Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot( tmp, new Vector3(0, 1f, 0f) ) ) ) );
//		Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);

		tmp = new Vector3(point.x - this.transform.position.x, point.y - this.transform.position.y, 0f);
		tmp.Normalize();
		tmp *= 3f;

		this._rigidBody.velocity = tmp;
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

		yield return new WaitForSeconds(0.4f);
		if (tmp.magnitude > 3f)
			this._rigidBody.velocity = dir - this.transform.position;

		tmp.Normalize();
		
		this.transform.localRotation = Quaternion.Euler( 0f, 0f, 180 - ajuste * (Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot( tmp, new Vector3(0, 1f, 0f) ) ) ) );
		this._body.shoot(dir);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, col.gameObject.transform.position - this.transform.position);
		foreach (RaycastHit2D hit in hits)
		{
			if (hit.collider.gameObject.tag == "wall")
				return ;
			else if (hit.collider.gameObject.tag == "Player")
			{
				this._playerFound = true;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && col.GetComponent<Player>().dead == false)
		{
			RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, col.gameObject.transform.position - this.transform.position);
			foreach (RaycastHit2D hit in hits)
			{
				if (hit.collider.gameObject.tag == "wall" || hit.collider.gameObject.tag == "door")
					return ;
				else if (hit.collider.gameObject.tag == "Player")
					StartCoroutine(this.setTarget(col.gameObject.transform.position));
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			this._playerFound = false;
		}
	}


	
	//	private	void			goLastFireSound()
	//	{
	//		Vector3 tmp;
	//		if (GameManager.fireTime + 10f < Time.realtimeSinceStartup || GameManager.fireTime == 0f)
	//		{
	//			this.sound = false;
	//			return ;
	//		}
	//		tmp = new Vector3(GameManager.firePos.x - this.transform.position.x, GameManager.firePos.y - this.transform.position.y, 0f);
	//		if (tmp.magnitude > 10f)
	//		{
	//			this.sound = false;
	//			return ;
	//		}
	//		RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, tmp);
	//		foreach (RaycastHit2D hit in hits)
	//		{
	//			if (hit.collider.gameObject.tag == "wall")
	//			{
	//				this.findDoor(tmp);
	//				this.sound = true;
	//			}
	//			else if (hit.collider.gameObject.tag == "Player")
	//			{
	//				this._soundHere = GameManager.firePos;
	//				this.sound = true;
	//			}
	//		}
	//		this.goHere(this._soundHere);
	//	}
	//	private	void			goLastFireSound()
	//	{
	//		Vector3 tmp;
	//		if (GameManager.fireTime + 10f < Time.realtimeSinceStartup || GameManager.fireTime == 0f)
	//		{
	//			this.sound = false;
	//			return ;
	//		}
	//		tmp = new Vector3(GameManager.firePos.x - this.transform.position.x, GameManager.firePos.y - this.transform.position.y, 0f);
	//		if (tmp.magnitude > 10f)
	//		{
	//			this.sound = false;
	//			return ;
	//		}
	//		RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, tmp);
	//		foreach (RaycastHit2D hit in hits)
	//		{
	//			if (hit.collider.gameObject.tag == "wall")
	//			{
	//				this.findDoor(tmp);
	//				this.sound = true;
	//			}
	//			else if (hit.collider.gameObject.tag == "Player")
	//			{
	//				this._soundHere = GameManager.firePos;
	//				this.sound = true;
	//			}
	//		}
	//		this.goHere(this._soundHere);
	//	}

}
