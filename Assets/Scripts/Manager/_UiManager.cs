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
		AkSoundEngine.PostEvent ("Menu_Music", gameObject);
		_sCanvas.enabled = false;
		_cCanvas.enabled = false;
		_mCanvas.enabled = true;
	}
		
	public void onPlayButton()
	{
		AkSoundEngine.PostEvent ("Night", gameObject);
		AkSoundEngine.PostEvent ("Menu_Button", gameObject);
		SceneManager.LoadScene (1);

	}
	public void onStoryButton()
	{
		AkSoundEngine.PostEvent ("Menu_Button", gameObject);
		_mCanvas.enabled = false;
		_cCanvas.enabled = false;
		_sCanvas.enabled = true;
	}
	public void onCreditsButton()
	{
		AkSoundEngine.PostEvent ("Menu_Button", gameObject);
		_mCanvas.enabled = false;
		_sCanvas.enabled = false;
		_cCanvas.enabled = true;
	}

	public void onBackButton()
	{
		AkSoundEngine.PostEvent ("Menu_Button", gameObject);
		_sCanvas.enabled = false;
		_cCanvas.enabled = false;
		_mCanvas.enabled = true;
	}
}
