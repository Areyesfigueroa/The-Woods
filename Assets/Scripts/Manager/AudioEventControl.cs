using UnityEngine;
using System.Collections;

/// <summary>
/// This script plays the audio files at the given events. 
/// Each function will be subscribed to their corresponding event. 
/// Triggers have already been placed, just excute audio on the functions given for the events
/// </summary>
public class AudioEventControl : MonoBehaviour {


    public static AudioEventControl Instance { get { return instance; } }
    static protected AudioEventControl instance;

    AudioSource audioSource;
    public AudioClip[] audioClip;

    #region Engine Functions
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an instance of InputManager, Deleting old and instantiating a new one");
            Destroy(AudioEventControl.Instance.gameObject);
            instance = null;
        }
        else
        {
            instance = this;
        }

        AddSubscribers();
    }

    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }

    #endregion

    #region Game Functions

    public void AddSubscribers()
    {
        AudioEventSystem.onPlayerMoving += this.PlayerMoving;
        AudioEventSystem.onPlayerIdle += this.PlayerIdle;
        AudioEventSystem.onPlayerJumping += this.PlayerJumping;
        AudioEventSystem.onPlayerDeath += this.PlayerDeath;
    }

    public void RemoveSubscribers()
    {
        AudioEventSystem.onPlayerMoving -= this.PlayerMoving;
        AudioEventSystem.onPlayerIdle -= this.PlayerIdle;
        AudioEventSystem.onPlayerJumping -= this.PlayerJumping;
        AudioEventSystem.onPlayerDeath -= this.PlayerDeath;
    }
    //Audio Event From Wise sound
    //Needs AKSoundEngine.PostEvent(EventName, gameObject);
    //Player Audio Event functions
    void PlayerMoving()
    {
        //Call audio
        
        //testing
        audioSource.clip = audioClip[0];
    }

    void PlayerIdle()
    {
        //Call audio
        //testing
        audioSource.Stop();
    }

    void PlayerJumping()
    {
        //Call audio

    }

    void PlayerDeath()
    {
        //Call audio

    }

    #endregion
}
