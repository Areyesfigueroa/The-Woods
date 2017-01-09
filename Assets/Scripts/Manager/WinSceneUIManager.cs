using UnityEngine;
using System.Collections;

public class WinSceneUIManager : MonoBehaviour {

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
