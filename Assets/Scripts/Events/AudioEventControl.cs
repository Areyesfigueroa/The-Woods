using UnityEngine;
using System.Collections;

/// <summary>
/// This script plays the audio files at the given events. 
/// Each function will be subscribed to their corresponding event. 
/// Triggers have already been placed, just excute audio on the functions given for the events
/// </summary>

public class AudioEventControl : MonoBehaviour
{

    //Prevents audio override
    public bool playAudio = true;

    public static AudioEventControl Instance { get { return instance; } }
    static protected AudioEventControl instance;

    [HideInInspector]
    public AudioSource audioSource;
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
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        AddSubscribers();

    }
    void OnDisable()
    {
        RemoveSubscribers();
    }

    #endregion

    #region Game Functions

    public void AddSubscribers()
    {
        //Player Events, Set Up Done, Waiting on Animations
        AudioEventSystem.onPlayerStep += this.PlayerStep;
        AudioEventSystem.onPlayerIdle += this.PlayerIdle;
        AudioEventSystem.onPlayerJump += this.PlayerJumping;
        AudioEventSystem.onPlayerDeath += this.PlayerDeath;
        AudioEventSystem.onPlayerAttack += this.PlayerAttack;

        //Testing Enemy Events
        AudioEventSystem.onEnemyStep += this.EnemyStep;
        AudioEventSystem.onEnemyIdle += this.EnemyIdle;
        AudioEventSystem.onEnemyEscape += this.EnemyEscape;
        AudioEventSystem.onEnemyAlert += this.EnemyAlert;
       
    }

    public void RemoveSubscribers()
    {
        //Player Events
        AudioEventSystem.onPlayerStep -= this.PlayerStep;
        AudioEventSystem.onPlayerIdle -= this.PlayerIdle;
        AudioEventSystem.onPlayerJump -= this.PlayerJumping;
        AudioEventSystem.onPlayerDeath -= this.PlayerDeath;
        AudioEventSystem.onPlayerAttack -= this.PlayerDeath;

        //Enemy Events
        AudioEventSystem.onEnemyStep -= this.EnemyStep;
        AudioEventSystem.onEnemyIdle -= this.EnemyIdle;
        AudioEventSystem.onEnemyEscape -= this.EnemyEscape;
        AudioEventSystem.onEnemyAlert -= this.EnemyAlert;

    }
    //Audio Event From Wise sound
    //He will add AKSoundEngine.PostEvent(Calls my event EventName, gameObject);
    //Player Audio Event functions

    #region Player Events Functionality

    void PlayerStep()
    {
        Debug.Log("Stepping Sound");
    }
    void PlayerIdle()
    {
        Debug.Log("Idle Sound");
    }
    void PlayerJumping()
    {
        Debug.Log("Jumping Sound");
    }

    void PlayerDeath()
    {
        Debug.Log("Death Sound");
    }

    void PlayerAttack()
    {
        Debug.Log("Attacking Sound");
    }
    #endregion

    #region Enemy Events Functionality

    void EnemyStep()
    {
        Debug.Log("Stepping Sound");
    }

    void EnemyIdle()
    {
        Debug.Log("Idle Sound");
    }

    void EnemyAlert()
    {
        Debug.Log("Alert Sound");
    }

    void EnemyEscape()
    {
        Debug.Log("Enemy Escape");
    }

    #endregion



    #region Helper Functions
    //Keeps audio from being overwritten
    IEnumerator PlayAudio(float audioLength)
    {
        playAudio = false; //keeps it from overriding
        audioSource.Play();
        yield return new WaitForSeconds(audioLength + .03f); //Error margin
        playAudio = true;
          
    }

    #endregion

    #endregion
}
