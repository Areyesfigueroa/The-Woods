using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance { get { return instance; } } //getter for instance
    static protected PlayerManager instance; //declaring instance variable

    private bool isDead = false;
    public float playerMaxSpeed = 10;
    public Animator anim;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is alreade a PlayerManager in play. Deleting old, instantiating new");
            Destroy(PlayerManager.Instance.gameObject);
            instance = null;
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        anim.SetBool("isDead", isDead);
        anim.SetFloat("Speed", Mathf.Abs(Player.Instance.Velocity.x) / playerMaxSpeed);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Attack();
        }
        if (Player.Instance.isPlayerJumping())
        {
            
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }

}
