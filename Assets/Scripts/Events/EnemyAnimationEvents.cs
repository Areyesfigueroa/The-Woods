using UnityEngine;
using System.Collections;

public class EnemyAnimationEvents : MonoBehaviour {

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
