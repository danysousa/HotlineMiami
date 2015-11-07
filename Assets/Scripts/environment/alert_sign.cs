using UnityEngine;
using System.Collections;

public class alert_sign : MonoBehaviour {

	public SpriteRenderer sprite;
	public Color newColor;
	private Color initialColor;
	private float time = 0f;
	private bool state = false;
	// Use this for initialization
	void Start () {
		initialColor = sprite.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (time >= 1f) {
			time = 0f;
			if (state)
				sprite.color = newColor;
			else
				sprite.color = initialColor;
			state = !state;

		}
		time += Time.deltaTime;
	}
}
