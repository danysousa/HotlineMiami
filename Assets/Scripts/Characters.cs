using UnityEngine;
using System.Collections;

public class Characters : MonoBehaviour
{
	public float			speedMove;

	protected Rigidbody2D	_rbody;

	protected void		init()
	{
		this._rbody = GetComponent<Rigidbody2D>();
	}

	protected void		move(Vector2 direction)
	{
		this._rbody.velocity = direction;
	}

	protected void		updateCharacters()
	{
		this._rbody.velocity *= 0.9f;
	}
}
