using UnityEngine;
using System.Collections;

/// <summary>
/// This script plays the audio files at the given events. 
/// Each function will be subscribed to their corresponding event. 
/// Triggers have already been placed, just excute audio on the functions given for the events
/// </summary>
namespace Audio
{
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
            AudioEventSystem.onPlayerMove += this.PlayerMoving;
            AudioEventSystem.onPlayerIdle += this.PlayerIdle;
            AudioEventSystem.onPlayerJump += this.PlayerJumping;
            AudioEventSystem.onPlayerDeath += this.PlayerDeath;
            AudioEventSystem.onPlayerAttack += this.PlayerAttack;
        }

        public void RemoveSubscribers()
        {
            AudioEventSystem.onPlayerMove -= this.PlayerMoving;
            AudioEventSystem.onPlayerIdle -= this.PlayerIdle;
            AudioEventSystem.onPlayerJump -= this.PlayerJumping;
            AudioEventSystem.onPlayerDeath -= this.PlayerDeath;
            AudioEventSystem.onPlayerAttack -= this.PlayerDeath;
        }
        //Audio Event From Wise sound
        //He will add AKSoundEngine.PostEvent(Calls my event EventName, gameObject);
        //Player Audio Event functions

        #region Player Delegate Functions

        void PlayerMoving()
        {
            Debug.Log("Event: PlayerMovement Fired");

        }
        void PlayerIdle()
        {
            Debug.Log("Event: PlayerIdle Fired");

        }
        void PlayerJumping()
        {
            Debug.Log("Event: PlayerJumping Fired");
        }

        void PlayerDeath()
        {
             Debug.Log("Event: PlayerDeath Fired");
        }

        void PlayerAttack()
        {
            Debug.Log("Event: PlayerAttack Fired");
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
}