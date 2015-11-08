using UnityEngine;
using System.Collections;

public class DeadMenu : MonoBehaviour {

	public void		Restart()
	{
		Application.LoadLevel(1);
	}

	public void		Quit()
	{
		Application.Quit();
	}
}
