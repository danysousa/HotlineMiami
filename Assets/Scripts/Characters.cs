using UnityEngine;
using System.Collections;

public class Characters : MonoBehaviour
{
	public float			speedMove;
	public weapon			weapon;

	protected Rigidbody2D	_rbody;
	protected Animator		_anim;

	protected void		init()
	{
		this._rbody = GetComponent<Rigidbody2D>();
		this._anim = GetComponentInChildren<Animator>();
	}

	protected void		move(Vector2 direction)
	{
		if (this._anim.GetBool("walk") == false)
			this._anim.SetBool("walk", true);
		this._rbody.velocity = direction;
	}

	protected void		updateCharacters()
	{
		if ( this._rbody.velocity.magnitude < this.speedMove / 6 )
			this._anim.SetBool("walk", false);
		this._rbody.velocity *= 0.8f;
	}
}
