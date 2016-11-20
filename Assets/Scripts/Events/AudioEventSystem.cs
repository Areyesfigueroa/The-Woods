using UnityEngine;
using System.Collections;

/// <summary>
/// Initializes events and 
/// </summary>
namespace Audio
{
    public class AudioEventSystem : MonoBehaviour
    {
        //Delegate
        public delegate void AudioEventHandler();
        //TODO:

        //Player Movement Events
        public static event AudioEventHandler onPlayerMove; //Animation Frame, Not implemented
        public static event AudioEventHandler onPlayerIdle; //Player Script
        public static event AudioEventHandler onPlayerJump; //Player Script
        public static event AudioEventHandler onPlayerFall; //Player Script
        public static event AudioEventHandler onPlayerDeath; //Sun Burning, HealthManager Script, Not implemented
        public static event AudioEventHandler onPlayerAttack; //PlayerAbilities Script, Not implemented
        public static event AudioEventHandler onPlayerPowerUp; //PlayerAbilities Script, Not implemented
        public static event AudioEventHandler onPlayerVisibleWarning; //ConeOfVision Script
        public static event AudioEventHandler onPlayerLand; //Player Script

        //Need to be implemented, Player Enviroment Interaction Events
        public static event AudioEventHandler onPlayerHide; //PlayerAbilities Script, Not implemented
        public static event AudioEventHandler onPlayerExitHide; //PlayerAbilities Script, Not implemented
        public static event AudioEventHandler onPlayerPowerUpPickUp; //PowerUpPickUp Script, Not implemented
        public static event AudioEventHandler onPlayerLadderClimb; //Ladders Script

        //NPC Events
        public static event AudioEventHandler onEnemyMoving; //EnemyMovement Script
        public static event AudioEventHandler onEnemyIdle; //EnemyMovement Script
        public static event AudioEventHandler onEnemyAlert; //ConeOfVision Script
        public static event AudioEventHandler onEnemyEscape; //EnemyMovement Script, Not Implemented

        //Enviroment
        public static event AudioEventHandler onCabinLightsOn; //Cabin Lights Script
        public static event AudioEventHandler onCabinLightsOff; //Cabin Lights Script
        public static event AudioEventHandler onMovingPlatform; //Moving Platform Script
        public static event AudioEventHandler onPowerUp; //power up idle sound, PowerUpPickUp Script, Not Implemented
        public static event AudioEventHandler onLockedDoor; //LockedDoor Script, Not implemented

        //SoundTrack, in-game
        public static event AudioEventHandler onGameBeginSoundTrack; //level manager Script, Not implemented

        //Main Menu
        public static event AudioEventHandler onButtonPress; //MainMenu Script, not implemented
        public static event AudioEventHandler onGameMenuSoundTrack; //MainMenu Script, not implemented


        #region Init PlayerTriggeredEvents

        //NOT ALL EVENTS CALLS ARE IMPLEMENTED. WAITING ON ANIMATION CLIPS TO TIME THE FRAMES
        //Init Player Movement Event Triggers
        public static void PlayerMove()
        {
            if (onPlayerMove != null) //check if there are any subscribers, Player Animation Event, TO BE IMPLEMENTED
            {
                onPlayerMove();
            }
        }
        public static void PlayerIdle() //Player Animation Event, TO BE IMPLEMENTED
        {
            if (onPlayerIdle != null)
            {
                onPlayerIdle();
            }
        }
        public static void PlayerJump() //Player Script
        {
            if (onPlayerJump != null)
            {
                onPlayerJump();
            }
        }
        public static void PlayerFall() //Player Script
        {
            if (onPlayerFall != null)
            {
                onPlayerFall();
            }
        }
        public static void PlayerDeath() //Health Script, TO BE IMPLEMETED
        {
            if (onPlayerDeath != null)
            {
                onPlayerDeath();
            }
        }
        public static void PlayerAttack() //Undetermined, TO BE IMPLEMENTED
        {
            if (onPlayerAttack != null)
            {
                onPlayerAttack();
            }
        }
        #endregion

        #region Fire Events
        //Fire Events
        //Will Be Triggered based on Animation Events When I get the Animation Clips, Not in Update
        void Update()
        {
            //Play Once

            //Movement and Idle, TO BE IMPLEMENTED ON ANIMATION EVENTS
            if (Player.Instance.isPlayerMoving() && Player.Instance.isPlayerGrounded()) //if player is moving and on the ground
            {
                PlayerMove();
            }
            else if (!Player.Instance.isPlayerMoving() && Player.Instance.isPlayerGrounded()) //if player is not moving and is grounded
            {
                PlayerIdle();
            }

            //Jumping
            if (Player.Instance.isPlayerJumping())
            {
                PlayerJump();
            }

            //Falling
            if (Player.Instance.isPlayerFalling())
            {
                PlayerFall();
            }
        }
        #endregion
    }
}
