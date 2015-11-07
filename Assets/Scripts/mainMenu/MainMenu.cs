using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Image background;

	private float time = 0f;
	private float step = 0.001f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Color tmp = background.color;
		if (tmp.g >= 0.6f || tmp.g < 0f)
			step *= -1;
		tmp.g += step;
		background.color = tmp;
	}
}
