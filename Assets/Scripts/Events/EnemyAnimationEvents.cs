using UnityEngine;
using System.Collections;

public class EnemyAnimationEvents : MonoBehaviour {

    //instance

    public static EnemyAnimationEvents Instance { get { return Instance; } }
    public static EnemyAnimationEvents instance;

	// Use this for initialization
	void Awake ()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an instance of EnemyAnimationEventManager, Deleting old and instantiating a new one");
            Destroy(EnemyAnimationEvents.Instance.gameObject);
            instance = null;
        }
        else
        {
            instance = this;
        }
    }

    //Enemy Animation events, Works
    public void onEnemyStep()
    {
        Debug.Log("Enemy Move event Fired");
        AudioEventSystem.EnemyStep();
    }

    public void onEnemyIdle()
    {
        Debug.Log("Enemy Idle event Fired");
        AudioEventSystem.EnemyIdle();
    }

    public void onEnemyAlert()
    {
        Debug.Log("Enemy Alert event Fired");
        AudioEventSystem.EnemyAlert();
    }

    public void onEnemyEscape()
    {
        Debug.Log("Enemy Escape Fired");
        AudioEventSystem.EnemyEscape();
    }

}
