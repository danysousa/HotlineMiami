using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Image background;

	public Text title1;
	public Text title2;
	private Vector3 initialPositionTitle2;
	private bool direction = false;
	private float stepRotation = 0.005f;
	private bool left = true;

	public Text subtilteText;
	private bool subtile = true;

	public Vector3[] list;

	public Button	start;
	public Text	start1;
	public Text	start2;

	public Button	exit;
	public Text	exit1;
	public Text	exit2;

	public Image eiffel;


	private float time = 0f;
	private float step = 0.001f;
	private float step2 = 0.01f;
	// Use this for initialization
	void Start () {
		initialPositionTitle2 = title2.transform.position;
		StartCoroutine(subtitle());
	}

	private void modifyBackground()
	{
		Color tmp = background.color;
		if (tmp.g >= 0.6f || tmp.g < 0f)
			step *= -1;
		tmp.g += step;
		background.color = tmp;
	}

	public void OnclickStart()
	{
		Debug.Log ("start");
	}

	public void OnClickExit()
	{
		Debug.Log ("exit");
	}

	private IEnumerator        titleEffect()
	{
		Vector3 pos = title2.transform.position;
		if (pos.x - initialPositionTitle2.x > 4f)
			direction = true;
		else if (pos.x - initialPositionTitle2.x < 0f)
			direction = false;
		if (!direction)
			pos.x = pos.x + 0.02f;
		else
			pos.x = pos.x - 0.02f;
		title2.transform.position = pos;
		yield return new WaitForSeconds(0.1f);
	}

	private IEnumerator        subtitle()
	{
		while (true) {
			if (subtile)
				subtilteText.text = "Error: invalid instruction";
			else
				subtilteText.text = "Error: invalid instruction _";
			subtile = !subtile;

			yield return new WaitForSeconds (1f);
		}
	}

	private void modifyTitle()
	{
		Color tmp = title2.color;

		if (tmp.g >= 0.7f || tmp.g < 0.2f)
			step2 *= -1;
		tmp.g += step2;

		if (tmp.b >= 0.7f || tmp.b < 0.2f)
			step2 *= -1;
		tmp.b += step2;
		title2.color = tmp;

		Quaternion rot1 = title1.transform.rotation;
		if (rot1.z >= 0.12f || rot1.z <= -0.12f)
			stepRotation *= -1f;
		rot1.z += stepRotation;

		title1.transform.rotation = rot1;
		title2.transform.rotation = rot1;

	}


	public void OnOverStart()
	{
		start1.text = "- Start -";
		start2.text = "- Start -";
	}

	public void OnExitStart()
	{
		start1.text = "Start";
		start2.text = "Start";
	}

	public void OnOverExit()
	{
		exit1.text = "- Exit -";
		exit2.text = "- Exit -";
	}
	
	public void OnExitExit()
	{
		exit1.text = "Exit";
		exit2.text = "Exit";
	}

	public void eiffelMove()
	{

		Vector3 scale = eiffel.transform.localScale;

		scale.x += 0.08f;
		scale.y += 0.08f;


		if (scale.x >= 2f) {
			scale.x = 0.001f;
			scale.y = 0.001f;
		}

		eiffel.transform.localScale = scale;
	}

	// Update is called once per frame
	void Update () {
		modifyBackground ();
		StartCoroutine(this.titleEffect());
		eiffelMove ();
		modifyTitle ();
	}
}
