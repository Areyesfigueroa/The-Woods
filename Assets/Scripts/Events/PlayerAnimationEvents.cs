using UnityEngine;
using System.Collections;

public class PlayerAnimationEvents : MonoBehaviour {

    //instance

    public static PlayerAnimationEvents Instance { get { return Instance; } }
    public static PlayerAnimationEvents instance;

    // Use this for initialization
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an instance of PlayerAnimationEvents, Deleting old and instantiating a new one");
            Destroy(PlayerAnimationEvents.Instance.gameObject);
            instance = null;
        }
        else
        {
            instance = this;
        }
    }

    //Player Animation events, Waiting on Animations
    public void onPlayerStep() 
    {
        Debug.Log("Player Move event Fired");
        AudioEventSystem.PlayerStep();

    }

    public void onPlayerIdle()
    {
        if (!Player.Instance.isPlayerMoving() && Player.Instance.isPlayerGrounded()) //if player is not moving and is grounded
        {
            Debug.Log("Player Idle event Fired");
            AudioEventSystem.PlayerIdle();
        }
    }

    public void onPlayerJump()
    {
        //Falling
        if (Player.Instance.isPlayerJumping())
        {
            Debug.Log("Player Jumping Event Fired");
			AkSoundEngine.PostEvent ("Jumping", gameObject);
            AudioEventSystem.PlayerJump();
        }
    }

    public void onPlayerFall()
    {
        if (Player.Instance.isPlayerFalling())
        {
            Debug.Log("Player Falling Event Fired");
			AkSoundEngine.PostEvent ("Jumping", gameObject);
            AudioEventSystem.PlayerFall();
        }
    }

    //Sun Rises
    public void onPlayerDeath()
    {
        Debug.Log("Player Death Event Fired");
		AkSoundEngine.PostEvent ("PlayerDefeat", gameObject);
        //AudioEventSystem.PlayerDeath();
    }

    public void onPlayerAttack()
    {
        Debug.Log("Player Attack Event Fired");
        //AudioEventSystem.PlayerAttack();
    }

}
