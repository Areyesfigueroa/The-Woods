using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class _UiManager : MonoBehaviour {

	//Canvas References
	public Canvas _mCanvas;
	public Canvas _sCanvas;
	public Canvas _cCanvas;

	// Use this for initialization
	void Start () 
	{
		_sCanvas.enabled = false;
		_cCanvas.enabled = false;
		_mCanvas.enabled = true;
	}
		
	public void onPlayButton()
	{
		SceneManager.LoadScene (1);
	}
	public void onStoryButton()
	{
		_mCanvas.enabled = false;
		_cCanvas.enabled = false;
		_sCanvas.enabled = true;
	}
	public void onCreditsButton()
	{
		_mCanvas.enabled = false;
		_sCanvas.enabled = false;
		_cCanvas.enabled = true;
	}

	public void onBackButton()
	{
		_sCanvas.enabled = false;
		_cCanvas.enabled = false;
		_mCanvas.enabled = true;
	}
}
