using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static public int		nbEnemies;
	private bool			end = false;
	public GameObject		panelWin;

	void Start ()
	{
		GameManager.nbEnemies = GameObject.FindGameObjectsWithTag("enemy").GetLength(0) / 2 - 1;
	}

	void Update()
	{
		if (GameManager.nbEnemies == 0 && end == false)
		{
			GameObject.Instantiate(panelWin);
			SoundBox.playWin();
			end = true;
		}
	}
}
