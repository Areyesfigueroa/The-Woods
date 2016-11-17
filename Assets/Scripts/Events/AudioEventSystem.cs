using UnityEngine;
using System.Collections;

/// <summary>
/// Initializes events and 
/// </summary>
public class AudioEventSystem : MonoBehaviour {

    //Delegate
    public delegate void AudioEventHandler(); 

    //Player Events
    public static event AudioEventHandler onPlayerMoving;
    public static event AudioEventHandler onPlayerIdle;
    public static event AudioEventHandler onPlayerJumping;
    public static event AudioEventHandler onPlayerDeath;

    //Init Player Movement Event Triggers
    public static void PlayerMoving()
    {
        if (onPlayerMoving != null) //check if there are any subscribers
        {
            onPlayerMoving();
        }
    }

    public static void PlayerIdle()
    {
        if (onPlayerIdle != null)
        {
            onPlayerIdle();
        }
    }

    public static void PlayerJumping()
    {
        if (onPlayerJumping != null)
        {
            onPlayerJumping();
        }
    }

    public static void PlayerDeath()
    {
        if (onPlayerDeath != null)
        {
            onPlayerDeath();
        }
    }

    //Call Event triggers. Testing
    void Update()
    {
        if (Player.Instance.input.x == 0)
        {
            PlayerMoving();
        }
        else if (Player.Instance.input.x > 1)
        {
            PlayerIdle();
        }
    }


}
