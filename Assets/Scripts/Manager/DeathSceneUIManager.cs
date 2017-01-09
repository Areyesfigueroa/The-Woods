using UnityEngine;
using System.Collections;

public class DeathSceneUIManager : MonoBehaviour {

	//Death Scene
	public void onTryAgainButton()
	{
		ScenesManager.Instance.LoadScene (1);
	}

	public void onMainMenuButton()
	{
		ScenesManager.Instance.LoadScene (0);
	}
}
