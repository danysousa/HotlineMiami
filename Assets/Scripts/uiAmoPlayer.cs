using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiAmoPlayer : MonoBehaviour {

	public Player			player;
	public GameObject		weapon;
	public GameObject		amo;

	private Text			_weaponText;
	private Text			_amoText;

	void Start ()
	{
		_weaponText = this.weapon.GetComponent<Text> ();
		_amoText = this.amo.GetComponent<Text> ();
	}

	void Update () {
		if (this.player.equiped) {
			_weaponText.text = this.player.weapon.name;
			_amoText.text = this.player.weapon.amo.ToString ();
		} else {
			_weaponText.text = "No Weapon";
			_amoText.text = "0";
		}
	}
}
