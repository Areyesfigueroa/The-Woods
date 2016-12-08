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
        AudioEventSystem.onPlayerFall += this.PlayerFall;
        AudioEventSystem.onPlayerDeath += this.PlayerDeath;
        AudioEventSystem.onPlayerAttack += this.PlayerAttack;
        AudioEventSystem.onPlayerInivisible += this.PlayerInvisible;
        AudioEventSystem.onPlayerVisibleWarning += this.PlayerVisibleWarning;
        AudioEventSystem.onPlayerLand += this.PlayerLand;

        //Player Enviroment 
        AudioEventSystem.onPlayerHide += this.PlayerHide;
        AudioEventSystem.onPlayerExitHide += this.PlayerExitHide;
        AudioEventSystem.onPlayerPowerUpPickUp += this.PlayerPowerUpPickUp;
        AudioEventSystem.onPlayerLadderClimb += this.PlayerLadderClimb;

        //Testing Enemy Events
        AudioEventSystem.onEnemyStep += this.EnemyStep;
        AudioEventSystem.onEnemyIdle += this.EnemyIdle;
        AudioEventSystem.onEnemyEscape += this.EnemyEscape;
        AudioEventSystem.onEnemyAlert += this.EnemyAlert;

        //Enviroment Events
        AudioEventSystem.onCabinLightsOn += this.CabinLightsOn;
        AudioEventSystem.onCabinLightsOff += this.CabinLightsOff;
        AudioEventSystem.onMovingPlatform += this.MovingPlatform;
        AudioEventSystem.onPowerUpIdle += this.PowerUpIdle;
        AudioEventSystem.onLockedDoor += this.LockedDoor;

        //Soundtrack events
        AudioEventSystem.onInGameSoundTrack += this.InGameSoundTrack;
        AudioEventSystem.onMainMenuSoundTrack += this.MainMenuSoundTrack;

        //Button Press Events
        AudioEventSystem.onButtonPress += this.ButtonPress;

    }

    public void RemoveSubscribers()
    {
        //Player Events, Set Up Done, Waiting on Animations
        AudioEventSystem.onPlayerStep -= this.PlayerStep;
        AudioEventSystem.onPlayerIdle -= this.PlayerIdle;
        AudioEventSystem.onPlayerJump -= this.PlayerJumping;
        AudioEventSystem.onPlayerFall -= this.PlayerFall;
        AudioEventSystem.onPlayerDeath -= this.PlayerDeath;
        AudioEventSystem.onPlayerAttack -= this.PlayerAttack;
        AudioEventSystem.onPlayerInivisible -= this.PlayerInvisible;
        AudioEventSystem.onPlayerVisibleWarning -= this.PlayerVisibleWarning;
        AudioEventSystem.onPlayerLand -= this.PlayerLand;

        //Player Enviroment 
        AudioEventSystem.onPlayerHide -= this.PlayerHide;
        AudioEventSystem.onPlayerExitHide -= this.PlayerExitHide;
        AudioEventSystem.onPlayerPowerUpPickUp -= this.PlayerPowerUpPickUp;
        AudioEventSystem.onPlayerLadderClimb -= this.PlayerLadderClimb;

        //Testing Enemy Events
        AudioEventSystem.onEnemyStep -= this.EnemyStep;
        AudioEventSystem.onEnemyIdle -= this.EnemyIdle;
        AudioEventSystem.onEnemyEscape -= this.EnemyEscape;
        AudioEventSystem.onEnemyAlert -= this.EnemyAlert;

        //Enviroment Events
        AudioEventSystem.onCabinLightsOn -= this.CabinLightsOn;
        AudioEventSystem.onCabinLightsOff -= this.CabinLightsOff;
        AudioEventSystem.onMovingPlatform -= this.MovingPlatform;
        AudioEventSystem.onPowerUpIdle -= this.PowerUpIdle;
        AudioEventSystem.onLockedDoor -= this.LockedDoor;

        //Soundtrack events
        AudioEventSystem.onInGameSoundTrack -= this.InGameSoundTrack;
        AudioEventSystem.onMainMenuSoundTrack -= this.MainMenuSoundTrack;

        //Button Press Events
        AudioEventSystem.onButtonPress -= this.ButtonPress;
    }
    //Audio Event From Wise sound
    //He will add AKSoundEngine.PostEvent(Calls my event EventName, gameObject);
    //Player Audio Event functions

    #region Player Events Functionality

    void PlayerStep()
    {
        Debug.Log("Stepping Sound");
		AkSoundEngine.PostEvent ("PlayerDefeat", gameObject);

    }
    void PlayerIdle()
    {
        Debug.Log("Idle Sound");
    }
    void PlayerJumping()
    {
        Debug.Log("Jumping Sound");
    }

    void PlayerFall()
    {
        Debug.Log("Fall sound");
    }

    void PlayerDeath()
    {
        Debug.Log("Death Sound");
		AkSoundEngine.PostEvent ("Death_Player", gameObject);
    }

    void PlayerAttack()
    {
        Debug.Log("Attacking Sound");
    }

    void PlayerInvisible()
    {
        Debug.Log("Invisible sound");
    }

    void PlayerVisibleWarning()
    {
        Debug.Log("Warning Visibility Sound");
    }

    void PlayerLand()
    {
        Debug.Log("Landing Sound");
    }

    #endregion

    #region Enemy Events Functionality

    void EnemyStep()
    {
        Debug.Log("Stepping Sound");
		AkSoundEngine.PostEvent ("PlayerDefeat", gameObject);

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

    #region Player Enviroment Interactions Functionality

    void PlayerPowerUpPickUp()
    {
        Debug.Log("PowerUp PickUp Sound Functionality");
    }

    void PlayerHide()
    {
        Debug.Log("Player Hide Sound");
    }

    void PlayerExitHide()
    {
        Debug.Log("Player Exit Sound");
    }

    void PlayerLadderClimb()
    {
        Debug.Log("Player Ladded Climb Sound");
    }

    #endregion

    #region Enviroment Event Functionality

    void CabinLightsOn()
    {
        Debug.Log("Cabin Lights on Sound");
    }

    void CabinLightsOff()
    {
        Debug.Log("Cabin Lights Off Sound");
    }

    void MovingPlatform()
    {
        Debug.Log("Moving Platform Sound");
    }

    void PowerUpIdle()
    {
        Debug.Log("PowerUpIdle Sound");
    }

    void LockedDoor()
    {
        Debug.Log("Locked");
    }

    #endregion

    #region SoundTracks Event Functionality

    void InGameSoundTrack()
    {
        Debug.Log("In Game Sound");
    }

    void MainMenuSoundTrack()
    {
        Debug.Log("Main Menu Sound");
    }

    #endregion

    #region UI Button Functionality

    void ButtonPress()
    {
        Debug.Log("Button Pressed Sound");
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
