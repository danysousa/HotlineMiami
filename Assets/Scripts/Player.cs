using UnityEngine;
using System.Collections;

public class Player : Characters {

	void Start ()
	{
		this.init();	
	}

	void Update ()
	{
		this.checkMove();
		this.updateCharacters();
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
}
